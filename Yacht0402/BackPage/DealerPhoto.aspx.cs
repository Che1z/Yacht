using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht0402.BackPage
{
    public partial class DealerPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/BackPage/LogIn.aspx");
            }

            if (!Page.IsPostBack)
            {
                dropdownlistbind();
                showGV1();
                showUserName();
            }
        }

        public void showUserName()
        {
            HttpCookie authCookie = Request.Cookies[".ASPXAUTH"];
            if (authCookie != null)
            {
                // 解密驗證票
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (ticket != null && !string.IsNullOrEmpty(ticket.UserData))
                {
                    // 解析 userData
                    string userData = ticket.UserData;
                    // 解析 userData
                    string[] userDataParts = userData.Split(';');
                    if (userDataParts.Length >= 2)
                    {
                        string userName = userDataParts[1]; // 第二個元素是 userName                      
                        Label3.Text = userName;
                    }
                }
            }
        }
        public void showGV1()
        {
            DbHelper db = new DbHelper();
            string sqlCommand = "";
            if (DropDownList1.SelectedValue != "")
            {
                string selectedArea = DropDownList1.SelectedValue;
                //d.cellNumber, d.faxNumber, d.telNumber, d.coverPhotoId移除
                sqlCommand = $"Select d.Id, da.AreaName, d.cityName, d.companyName " +
                    $"From Dealer d Inner Join DealerArea da on d.areaId = da.Id Where da.AreaName = '{selectedArea}' ";
            }
            else
            {
                sqlCommand = $"Select d.Id, da.AreaName, d.cellNumber, d.faxNumber, d.telNumber From Dealer d Inner Join DealerArea da on d.areaId = da.Id";

            }
            SqlDataReader rd = db.SearchDB(sqlCommand);
            if (rd.HasRows)
            {
                gridview1.DataSource = rd;
                gridview1.DataBind();
            }
            rd.Close();
            db.CloseDB();

        }

        protected void dropdownlistbind()
        {
            DbHelper db = new DbHelper();
            string sqlCommand = $"Select AreaName From DealerArea";
            SqlDataReader rd = db.SearchDB(sqlCommand);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    DropDownList1.Items.Add(new ListItem(rd["AreaName"].ToString()));
                    //DropDownList2.Items.Add(new ListItem(rd["AreaName"].ToString()));

                }
            }
            rd.Close();
            db.CloseDB();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showGV1();

        }

        protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;

            // 綁定dropdownlist
            DbHelper db1 = new DbHelper();
            string dealerId = e.Row.Cells[4].Text;

            string sqlCommand1 = $" SELECT dp.fileName " +
                $"FROM DealerPhoto dp " +
                $"Where dp.dealerId = '{dealerId}' ";

            SqlDataReader rd1 = db1.SearchDB(sqlCommand1);

            if (rd1.HasRows)
            {
                while (rd1.Read()) // Use a loop to iterate through all rows
                {
                    string fileName = rd1["fileName"].ToString();
                    DropDownList dropdownlist = (DropDownList)e.Row.FindControl("DropDownList2");
                    dropdownlist.Items.Add(new ListItem(fileName, fileName));
                }
            }
            rd1.Close();
            db1.CloseDB();

            //DropDownList預設值
            DbHelper db3 = new DbHelper();

            string sqlCommand3 = $" SELECT dp.fileName " +
                $"FROM DealerPhoto dp " +
                $"Where dp.dealerId = '{dealerId}' And IsCover = 1 ";

            SqlDataReader rd3 = db1.SearchDB(sqlCommand3);

            if (rd3.HasRows)
            {
                while (rd3.Read()) // Use a loop to iterate through all rows
                {
                    string fileName = rd3["fileName"].ToString();
                    DropDownList dropdownlist = (DropDownList)e.Row.FindControl("DropDownList2");
                    dropdownlist.SelectedValue = fileName;
                }
            }
            rd3.Close();
            db3.CloseDB();


            //綁定封面圖位置
            Image image = (Image)e.Row.FindControl("Image1");

            DbHelper db2 = new DbHelper();


            string sqlCommand2 = $" SELECT dp.imgPath " +
                $"FROM DealerPhoto dp " +
                $"Where dp.dealerId = '{dealerId}' And IsCover = 1";

            SqlDataReader rd2 = db2.SearchDB(sqlCommand2);

            if (rd2.HasRows)
            {
                while (rd2.Read()) // Use a loop to iterate through all rows
                {
                    string imgPath = rd2["imgPath"].ToString();
                    image.ImageUrl = imgPath;

                }
            }
            rd2.Close();
            db2.CloseDB();
        }

        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview1.EditIndex = e.NewEditIndex;           
            showGV1();
        }

        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            showGV1();
        }

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IndexRow = e.RowIndex;
            string IDkey = gridview1.DataKeys[IndexRow].Value.ToString();
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"DELETE FROM Dealer Where Id = @Id";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@Id", IDkey);
            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('刪除{result}筆資料成功')</script>");
                showGV1();
            }
            connection.Close();
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;

            // Cells[2]為Id，該欄位已經隱藏
            DropDownList dropdown = gridview1.Rows[rowIndex].FindControl("DropDownList2") as DropDownList;
            TextBox cityName = gridview1.Rows[rowIndex].Cells[6].Controls[0] as TextBox;
            TextBox companyName = gridview1.Rows[rowIndex].Cells[7].Controls[0] as TextBox;
          
            String IDkey = gridview1.DataKeys[rowIndex].Value.ToString();
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Update Dealer " +
                $"SET   " +
                $"companyName = @companyName, cityName= @cityName " +        
                $"Where Id = @Id";
            string sqlCommand1 = $" Update DealerPhoto SET IsCover = 0 Where dealerId = @Id " + 
                $"Update DealerPhoto SET IsCover = 1 Where dealerId = @Id And fileName = @fileName";
            sqlcommand.CommandText = sqlCommand+sqlCommand1;
            sqlcommand.Parameters.AddWithValue("@cityName", cityName.Text);
            sqlcommand.Parameters.AddWithValue("@companyName", companyName.Text);           
            sqlcommand.Parameters.AddWithValue("@Id", IDkey);
            sqlcommand.Parameters.AddWithValue("@fileName", dropdown.SelectedValue);

            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('更新資料成功')</script>");
                gridview1.EditIndex = -1;
                showGV1();
            }
            connection.Close();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ServerFolderPath = Server.MapPath("~/BackPage/DealerImages/");
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;

            //觸發事件的button
            Button button = (Button)sender;
            // Find the parent GridViewRow of the Button
            GridViewRow row = (GridViewRow)button.NamingContainer;

            // Get the index of the row
            int rowIndex = row.RowIndex;
            FileUpload FileUpload1 = (FileUpload)row.FindControl("FileUpload2");
            Image image = (Image)row.FindControl("Image1");
            string dealerId = gridview1.Rows[rowIndex].Cells[4].Text;


            if (FileUpload1.HasFiles)
            {
                connection.Open();  // 在迴圈之外開啟連線

                foreach (var postfile in FileUpload1.PostedFiles)
                {
                    int fileMemory = postfile.ContentLength;
                    string fileName = Path.GetFileName(postfile.FileName);
                    string fileExtention = Path.GetExtension(postfile.FileName);
                    string filePath = Path.Combine(ServerFolderPath, fileName);

                    if (fileMemory > 10000000 || fileExtention != ".jpg")
                    {
                        continue;
                    }

                    string pathStore = "/BackPage/DealerImages/" + fileName;
                    string sql = $"INSERT INTO DealerPhoto(fileName, imgPath, dealerId) VALUES('{fileName}', '{pathStore}', '{dealerId}' ) ";

                    sqlCommand.CommandText = sql;

                    int result = sqlCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        postfile.SaveAs(filePath);
                        Response.Write($"<script>alert('已上傳{result}個檔案')</script>");
                        showGV1();
                    }
                }

                connection.Close();  // 在迴圈之外關閉連線
            }
            else
            {
                Response.Write("<script>alert('沒有選擇任何檔案')</script>");
            }
        }


        
    }
}