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
    public partial class YachtDimension : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/BackPage/LogIn.aspx");
            }
            bindFirstData();

            if (!Page.IsPostBack)
            {
                showGV1();
                showImg();
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
                        Label6.Text = userName;
                    }
                }
            }
        }
        public void bindFirstData()
        {
            DbHelper db = new DbHelper();
            string sqlCommand = $"Select Top 1 * From YachtList";
            SqlDataReader rd = db.SearchDB(sqlCommand);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    string requestId = Request.QueryString["model"];
                    string Id = rd["Id"].ToString();
                    string modelId = string.IsNullOrEmpty(requestId) ? Id : requestId;
                    Label1.Text = modelId;
                }
            }
            rd.Close();
            db.CloseDB();
        }

        public void showGV1()
        {
            DbHelper db = new DbHelper();
            string sqlCommand = $"Select Id, Name, Value From YachtDimension Where ListId= @Id ";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = Label1.Text;
            SqlDataReader rd = db.SearchDB(sqlCommand, parameter);
            if (rd.HasRows)
            {
                gridview1.DataSource = rd;
                gridview1.DataBind();
            }
            rd.Close();
            db.CloseDB();
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
            string sqlCommand = $"DELETE FROM YachtDimension Where Id = @Id";
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
            //Name
            TextBox tbName = gridview1.Rows[rowIndex].FindControl("Label3") as TextBox;
            //Value
            TextBox tbValue = gridview1.Rows[rowIndex].FindControl("Labe15") as TextBox;
            String IDkey = gridview1.DataKeys[rowIndex].Value.ToString();
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Update YachtDimension " +
                $"SET Name = @Name, " +
                $"Value = @Value " +
                $"Where Id = @Id";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@Name", tbName.Text);
            sqlcommand.Parameters.AddWithValue("@Value", tbValue.Text);
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
            Panel1.Visible = false;
            Button1.Visible = true;
        }

        //新增Dimension
        protected void Button3_Click(object sender, EventArgs e)
        {
            string Name = TextBoxName.Text;
            string Value = TextBoxValue.Text;

            //讀取DB
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Insert Into YachtDimension(ListId, Name, Value) values (@ListId, @Name, @Value) ";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@ListId", Label1.Text);
            sqlcommand.Parameters.AddWithValue("@Name", Name);
            sqlcommand.Parameters.AddWithValue("@Value", Value);
            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('新增{result}筆資料成功')</script>");
                TextBoxName.Text = "";
                TextBoxValue.Text = "";

            }
            connection.Close();
            showGV1();
            Panel1.Visible = false;
            Button1.Visible = true;

        }

        //上傳圖片
        protected void Button4_Click(object sender, EventArgs e)
        {

            // albumId
            string ListId = Label1.Text;
            ///
            string ServerFolderPath = Server.MapPath("~/BackPage/YachtDimensionPhoto/");
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;

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

                    string pathStore = "/BackPage/YachtDimensionPhoto/" + fileName;
                    string sql = $"Update YachtList SET DimensionImgPath=@imgPath, DimensionFileName = @fileName Where Id = @Id ";
                    //string sql = $"INSERT INTO YachtPhoto(fileName, imgPath, ListId) VALUES('{fileName}', '{pathStore}', '{ListId}')";
                    sqlCommand.Parameters.Add("@fileName", fileName);
                    sqlCommand.Parameters.Add("@imgPath", pathStore);
                    sqlCommand.Parameters.Add("@Id", Label1.Text);
                    sqlCommand.CommandText = sql;

                    int result = sqlCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        postfile.SaveAs(filePath);
                        Response.Write($"<script>alert('已上傳{result}個檔案')</script>");
                    }
                    sqlCommand.Parameters.Clear();
                }

                connection.Close();  // 在迴圈之外關閉連線
            }
            else
            {
                Response.Write("<script>alert('沒有選擇任何檔案')</script>");
            }
            showImg();

        }

        public void showImg()
        {
            DbHelper db = new DbHelper();
            string sqlCommand = $"Select *  From YachtList Where Id= @Id ";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = Label1.Text;
            SqlDataReader rd = db.SearchDB(sqlCommand, parameter);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    string img = rd["DimensionImgPath"].ToString();
                    string imgPath = string.IsNullOrEmpty(img) ? "" : img;
                    Image1.ImageUrl = imgPath;

                }
            }
            rd.Close();
            db.CloseDB();
        }
    }
}