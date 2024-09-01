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
    public partial class NewsContents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/BackPage/LogIn.aspx");
            }
            if (!Page.IsPostBack)
            {
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
                        Label2.Text = userName;
                    }
                }
            }
        }
        public void showGV1()
        {
            DbHelper db = new DbHelper();

            string sqlCommand = $"Select  nc.Id, n.Title,nc.Contents " +
                $"From NewsLists n " +
                $"Inner Join NewsContents nc on nc.NewsListId=n.Id Order by n.PinTop DESC ";


            SqlDataReader rd = db.SearchDB(sqlCommand);
            if (rd.HasRows)
            {
                gridview1.DataSource = rd;
                gridview1.DataBind();

            }

            rd.Close();
            db.CloseDB();
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            // lb為Id
            Label lb = gridview1.Rows[rowIndex].FindControl("Label1") as Label;
            TextBox titletb = gridview1.Rows[rowIndex].FindControl("TextBox2") as TextBox;
            TextBox contentstb = gridview1.Rows[rowIndex].FindControl("TextBox3") as TextBox;
            string id = lb.Text;
            string title = titletb.Text;
            string contents = contentstb.Text;

            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            //更新 NewsLists表格
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"UPDATE NewsLists SET title = @title WHERE Id = @Id";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@Id", id);
            sqlcommand.Parameters.AddWithValue("@title", title);
            int result1 = sqlcommand.ExecuteNonQuery();

            // 更新 NewsContents 表格
            SqlCommand sqlcommand1 = new SqlCommand();
            sqlcommand1.Connection = connection;
            string sqlCommand1 = $"UPDATE NewsContents SET Contents = @contents WHERE NewsListId = @Id";
            sqlcommand1.CommandText = sqlCommand1;
            sqlcommand1.Parameters.AddWithValue("@Id", id);
            sqlcommand1.Parameters.AddWithValue("@contents", contents);
            int result2 = sqlcommand1.ExecuteNonQuery();

            if (result1 > 0 && result2 > 0)
            {
                Response.Write($"<script>alert('更新資料成功')</script>");
                gridview1.EditIndex = -1;
                showGV1();
            }
            connection.Close();            
        }

        protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //設定Button的PostBackUrl
                Button btn = e.Row.FindControl("Button2") as Button;
                Label lb = e.Row.FindControl("Label1") as Label;
                btn.PostBackUrl = "NewsPhotos?album=" + lb.Text;
            }
        }

        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview1.EditIndex = e.NewEditIndex;
            Button btn = gridview1.Rows[e.NewEditIndex].FindControl("Button2") as Button;
            btn.Visible = false;
            showGV1();
        }

        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            showGV1();
        }

        protected void gridview1_DataBound(object sender, EventArgs e)
        {

        }
    }
}