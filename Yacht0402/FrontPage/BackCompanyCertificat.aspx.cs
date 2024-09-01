using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht0402.FrontPage
{
    public partial class BackCompanyCertificat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/BackPage/LogIn.aspx");
            }
            if (!Page.IsPostBack)
            {
                labelBind();
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
                        Label1.Text = userName;
                    }
                }
            }
        }
        public void labelBind()
        {
            DbHelper db = new DbHelper();
            string sqlCommand = $"Select * From CompanyCertificat";
            SqlDataReader rd = db.SearchDB(sqlCommand);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    CKEditorControl1.Text = rd["editorContent"].ToString(); ;
                }
            }
            rd.Close();
            db.CloseDB();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string decodedHtml = HttpUtility.HtmlDecode(CKEditorControl1.Text); // 解碼 HTML 內容
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Update CompanyCertificat " +
                $"SET   " +
                $"editorContent = @editorContent " +
                $"Where Id = 1";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@editorContent", decodedHtml); // 儲存解碼後的 HTML 內容
            int result = sqlcommand.ExecuteNonQuery();
            if (result > 0)
            {
                Response.Write($"<script>alert('更新資料成功')</script>");
            }
            connection.Close();
        }
    }
}