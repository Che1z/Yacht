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
    public partial class YachtOverview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/BackPage/LogIn.aspx");
            }
            if (!Page.IsPostBack)
            {
                bindDropDownList();
                bindFirstDataBtn();
                showCK1();
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
                        Label2.Text = userName;
                    }
                }
            }
        }
        public void bindDropDownList()
        {
            DbHelper db = new DbHelper();
            string sqlCommand = $"Select yachtName From YachtList";
            SqlDataReader rd = db.SearchDB(sqlCommand);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    DropDownList1.Items.Add(new ListItem(rd["yachtName"].ToString()));
                }
            }
            rd.Close();
            db.CloseDB();
        }

        public void bindFirstDataBtn()
        {
            DbHelper db = new DbHelper();
            string sqlCommand = $"Select Top 1 * From YachtList";
            SqlDataReader rd = db.SearchDB(sqlCommand);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    Session["model"] = rd["Id"];
                    Button1.PostBackUrl = $"YachtDimension?model={rd["Id"]}";
                    Button2.PostBackUrl = $"YachtPhoto?model={rd["Id"]}";
                    Button3.PostBackUrl = $"YachtLayout?model={rd["Id"]}";
                    Button7.PostBackUrl = $"YachtSpecification?model={rd["Id"]}";
                }
            }
            rd.Close();
            db.CloseDB();

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectModelName = DropDownList1.SelectedValue;

            DbHelper db = new DbHelper();
            string sqlCommand = $"Select * From YachtList where yachtName = @yachtName";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@yachtName"] = selectModelName;
            SqlDataReader rd = db.SearchDB(sqlCommand, parameter);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    Session["model"] = rd["Id"];
                    Button1.PostBackUrl = $"YachtDimension?model={rd["Id"]}";
                    Button2.PostBackUrl = $"YachtPhoto?model={rd["Id"]}";
                    Button3.PostBackUrl = $"YachtLayout?model={rd["Id"]}";
                    Button7.PostBackUrl = $"YachtSpecification?model={rd["Id"]}";
                }
            }
            rd.Close();
            db.CloseDB();
            showCK1();

        }

        // Download內容
        protected void Button4_Click(object sender, EventArgs e)
        {
           
            string modelId = Session["model"].ToString();           
            // albumId
            string ServerFolderPath = Server.MapPath("~/BackPage/YachtDownloads/");
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

                    if (fileMemory > 10000000 || fileExtention != ".pdf")
                    {
                        continue;
                    }

                    string pathStore = "/BackPage/YachtDownloads/" + fileName;
                    string sql = $"INSERT INTO YachtDownload(downloadFileName, downloadFilePath, ListId) VALUES(@fileName, @filePath, @listId ) ";

                    sqlCommand.Parameters.Add("@fileName", fileName);
                    sqlCommand.Parameters.Add("@filePath", pathStore);
                    sqlCommand.Parameters.Add("@listId", modelId);
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
        }

        public void showCK1() {
            DbHelper db = new DbHelper();
            string sqlCommand = $"Select * From YachtList Where Id = @Id";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = Session["model"];
            SqlDataReader rd = db.SearchDB(sqlCommand,parameter);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    CKEditorControl1.Text = rd["interiorContent"].ToString(); ;
                }
            }
            rd.Close();
            db.CloseDB();
        }



        protected void Button5_Click(object sender, EventArgs e)
        {
            // Content Session["model"]
            //Response.Write(Session["model"]);

            string decodedHtml = HttpUtility.HtmlDecode(CKEditorControl1.Text); // 解碼 HTML 內容
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Update YachtList " +
                $"SET   " +
                $"interiorContent = @editorContent " +
                $"Where Id = @Id";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@editorContent", decodedHtml); // 儲存解碼後的 HTML 內容
            sqlcommand.Parameters.AddWithValue("@Id", Session["model"]); 
            int result = sqlcommand.ExecuteNonQuery();
            if (result > 0)
            {
                Response.Write($"<script>alert('更新資料成功')</script>");
            }
            connection.Close();

        }
    }
}