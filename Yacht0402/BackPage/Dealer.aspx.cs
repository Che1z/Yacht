using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht0402.BackPage
{
    public partial class Dealer1 : System.Web.UI.Page
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
                        Label8.Text = userName;
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
                sqlCommand = $"Select d.Id, da.AreaName, d.cityName, d.companyName, d.contactName,  d.addressName,  d.email, d.link " +
                    $"From Dealer d Inner Join DealerArea da on d.areaId = da.Id Where da.AreaName = '{selectedArea}' ";
            }
            else
            {
                sqlCommand = $"Select d.Id, da.AreaName, d.cityName, d.companyName, d.contactName, d.addressName, d.telNumber, d.faxNumber, d.cellNumber, d.email, d.link, d.coverPhotoId From Dealer d Inner Join DealerArea da on d.areaId = da.Id";

            }
            SqlDataReader rd = db.SearchDB(sqlCommand);


            gridview1.DataSource = rd;
            gridview1.DataBind();

            rd.Close();
            db.CloseDB();

        }

        protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //ID和AreaName
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }



        protected void gridview1_RowEditing1(object sender, GridViewEditEventArgs e)
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
                    DropDownList2.Items.Add(new ListItem(rd["AreaName"].ToString()));

                }
            }
            rd.Close();
            db.CloseDB();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showGV1();

        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;

            // Cells[2]為Id，該欄位已經隱藏
            TextBox AreaName = gridview1.Rows[rowIndex].Cells[3].Controls[0] as TextBox;
            TextBox cityName = gridview1.Rows[rowIndex].Cells[4].Controls[0] as TextBox;
            TextBox companyName = gridview1.Rows[rowIndex].Cells[5].Controls[0] as TextBox;
            TextBox contactName = gridview1.Rows[rowIndex].Cells[6].Controls[0] as TextBox;
            TextBox addressName = gridview1.Rows[rowIndex].Cells[7].Controls[0] as TextBox;
            TextBox email = gridview1.Rows[rowIndex].Cells[8].Controls[0] as TextBox;
            TextBox link = gridview1.Rows[rowIndex].Cells[9].Controls[0] as TextBox;
            String IDkey = gridview1.DataKeys[rowIndex].Value.ToString();
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Update Dealer " +
                $"SET areaId = (Select Id From DealerArea Where AreaName = @AreaName), cityName = @cityName, " +
                $"companyName = @companyName, contactName= @contactName, addressName=@addressName, " +
                $" email = @email, link = @link " +
                $"Where Id = @Id";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@AreaName", AreaName.Text);
            sqlcommand.Parameters.AddWithValue("@cityName", cityName.Text);
            sqlcommand.Parameters.AddWithValue("@companyName", companyName.Text);
            sqlcommand.Parameters.AddWithValue("@contactName", contactName.Text);
            sqlcommand.Parameters.AddWithValue("@addressName", addressName.Text);
            sqlcommand.Parameters.AddWithValue("@email", email.Text);
            sqlcommand.Parameters.AddWithValue("@link", link.Text);
            sqlcommand.Parameters.AddWithValue("@Id", IDkey);

            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('更新{result}筆資料成功')</script>");
                gridview1.EditIndex = -1;
                showGV1();
            }
            connection.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Button1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            //connection.Open();
            //SqlCommand sqlcommand = new SqlCommand();
            //sqlcommand.Connection = connection;
            //string sqlCommand = $"Insert into Dealer (areaId, cityName,companyName,contactName,addressName,email,link) " +
            //    $"Select top 1 da.id, @cityName, @companyName, @contactName, @addressName, @email, @link " +
            //    $"from DealerArea da " +
            //    $"INNER JOIN Dealer d ON da.Id = d.areaId " +
            //    $" WHERE da.AreaName = '{DropDownList2.SelectedValue}' ";
            //sqlcommand.CommandText = sqlCommand;
            //sqlcommand.Parameters.AddWithValue("@cityName", TextBox1.Text);
            //sqlcommand.Parameters.AddWithValue("@companyName", TextBox2.Text);
            //sqlcommand.Parameters.AddWithValue("@contactName", TextBox3.Text);
            //sqlcommand.Parameters.AddWithValue("@addressName", TextBox4.Text);
            //sqlcommand.Parameters.AddWithValue("@email", TextBox5.Text);
            //sqlcommand.Parameters.AddWithValue("@link", TextBox6.Text);
            //int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            //if (result > 0)
            //{
            //    Response.Write($"<script>alert('新增{result}筆資料成功')</script>");
            //    showGV1();
            //}
            //connection.Close();
            //// 清空Textbox內容
            //TextBox1.Text = "";
            //TextBox2.Text = "";
            //TextBox3.Text = "";
            //TextBox4.Text = "";
            //TextBox5.Text = "";
            //TextBox6.Text = "";
            //Button1.Visible = true;
            //Panel1.Visible = false;

            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;

            // 從 DealerArea 表格中根據 DropDownList2.SelectedValue 找到對應的 ID
            string areaIdQuery = $"SELECT TOP 1 da.id FROM DealerArea da WHERE da.AreaName = '{DropDownList2.SelectedValue}'";
            SqlCommand areaIdCommand = new SqlCommand(areaIdQuery, connection);
            int areaId = Convert.ToInt32(areaIdCommand.ExecuteScalar());

            // 如果找不到對應的 ID，則不執行 INSERT 語句
            if (areaId <= 0)
            {
                Response.Write("<script>alert('找不到對應的區域 ID')</script>");
                connection.Close();
                return;
            }

            // 構建 INSERT 語句並填入參數
            string sqlCommand = $"INSERT INTO Dealer (areaId, cityName, companyName, contactName, addressName, email, link) " +
                $"VALUES (@areaId, @cityName, @companyName, @contactName, @addressName, @email, @link)";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@areaId", areaId);
            sqlcommand.Parameters.AddWithValue("@cityName", TextBox1.Text);
            sqlcommand.Parameters.AddWithValue("@companyName", TextBox2.Text);
            sqlcommand.Parameters.AddWithValue("@contactName", TextBox3.Text);
            sqlcommand.Parameters.AddWithValue("@addressName", TextBox4.Text);
            sqlcommand.Parameters.AddWithValue("@email", TextBox5.Text);
            sqlcommand.Parameters.AddWithValue("@link", TextBox6.Text);

            int result = sqlcommand.ExecuteNonQuery();
            if (result > 0)
            {
                Response.Write($"<script>alert('新增{result}筆資料成功')</script>");
                showGV1();
            }

            connection.Close();
            // 清空Textbox內容
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            Button1.Visible = true;
            Panel1.Visible = false;

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Button1.Visible = true;

        }
    }
}