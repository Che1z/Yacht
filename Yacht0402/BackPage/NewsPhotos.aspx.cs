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
    public partial class NewsPhotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/BackPage/LogIn.aspx");
            }
            if (!Page.IsPostBack)
            {
                showRP1();
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
                        Label4.Text = userName;
                    }
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // albumId
            string contentsId = Request.QueryString["album"];
            ///
            string ServerFolderPath = Server.MapPath("~/BackPage/NewsImages/");
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

                    string pathStore = "/BackPage/NewsImages/" + fileName;
                    string sql = $"INSERT INTO NewsPhoto(fileName, imgPath, newsContentsId) VALUES('{fileName}', '{pathStore}', '{contentsId}' ) ";

                    sqlCommand.CommandText = sql;

                    int result = sqlCommand.ExecuteNonQuery();
                    if (result == 1)
                    {
                        postfile.SaveAs(filePath);
                        Response.Write($"<script>alert('已上傳{result}個檔案')</script>");
                    }
                }

                connection.Close();  // 在迴圈之外關閉連線
            }
            else
            {
                Response.Write("<script>alert('沒有選擇任何檔案')</script>");
            }
            showRP1();
        }
        public void showRP1()
        {
            DbHelper db = new DbHelper();

            string sql = "";

            string Id = Request.QueryString["album"] == null ? "6" : Request.QueryString["album"];
            sql = "SELECT  * FROM NewsPhoto np Inner Join NewsLists nl on nl.Id = np.newsContentsId " +
                "Where np.newsContentsId = @Id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@Id"] = Id;
            SqlDataReader rd = db.SearchDB(sql, parameters);
            if (rd.HasRows)
            {

                Repeater1.DataSource = rd;
                Repeater1.DataBind();
            }
            db.CloseDB();

        }
        //刪除按鈕
        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox cb = item.FindControl("CheckBox1") as CheckBox;
                if (cb.Checked)
                {
                    // ID Label
                    Label lb = item.FindControl("Label1") as Label;
                    SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
                    connection.Open();
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    string sqlCommand = $"DELETE FROM NewsPhoto Where Id = @Id";
                    sqlcommand.CommandText = sqlCommand;
                    sqlcommand.Parameters.AddWithValue("@Id", lb.Text);
                    int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
                    if (result > 0)
                    {
                        Response.Write($"<script>alert('刪除{result}筆資料成功')</script>");
                    }
                    connection.Close();
                }
            }
            showRP1();
        }
    }
}