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
    public partial class yachtModel : System.Web.UI.Page
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
                        Label1.Text = userName;
                    }
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Button1.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Button1.Visible = true;
        }

        // 新增Model
        protected void Button2_Click(object sender, EventArgs e)
        {
            //yachtName: TextBox1
            string yachtName = TextBox1.Text;
            //isNewDesign: CheckBox1
            bool isNewDesign = CheckBox1.Checked;
            //isNewBuilding: CheckBox2
            bool isNewBuilding = CheckBox2.Checked;

            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Insert Into YachtList(yachtName, isNewDesign, isNewBuilding) values (@yachtName, @isNewDesign, @isNewBuilding) ";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@yachtName", yachtName);
            sqlcommand.Parameters.AddWithValue("@isNewDesign", isNewDesign);
            sqlcommand.Parameters.AddWithValue("@isNewBuilding", isNewBuilding);
            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('新增{result}筆資料成功')</script>");
                TextBox1.Text = "";
                CheckBox1.Checked = false;
                CheckBox2.Checked = false;

            }
            connection.Close();
            Panel2.Visible = false;
            Button1.Visible = true;
            showGV1();
        }

        public void showGV1()
        {

            DbHelper db = new DbHelper();
            string sqlCommand = "Select Id, yachtName, isNewDesign, isNewBuilding From YachtList";


            SqlDataReader rd = db.SearchDB(sqlCommand);


            gridview1.DataSource = rd;
            gridview1.DataBind();

            rd.Close();
            db.CloseDB();

        }

        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int rowIndex = e.NewEditIndex;
            showGV1();
        }

        protected void gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            showGV1();
        }

        protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Id
            e.Row.Cells[2].Visible = false;
        }

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string modelId = gridview1.DataKeys[e.RowIndex].Value.ToString();

            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Delete From YachtList Where Id = @id ";
            sqlcommand.CommandText = sqlCommand;           
            sqlcommand.Parameters.AddWithValue("@Id", modelId);
            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('刪除資料成功')</script>");

            }
            connection.Close();
            showGV1();
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string modelId = gridview1.DataKeys[e.RowIndex].Value.ToString();

            int rowIndex = e.RowIndex;
            // Yacht Name
            TextBox tb = gridview1.Rows[rowIndex].Cells[3].Controls[0] as TextBox;
            //isNewDesign
            CheckBox cb1 = gridview1.Rows[rowIndex].Cells[4].Controls[0] as CheckBox;
            // isNewBuild
            CheckBox cb2 = gridview1.Rows[rowIndex].Cells[5].Controls[0] as CheckBox;

            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Update YachtList SET yachtName = @yachtName, isNewDesign = @isNewDesign, isNewBuilding= @isNewBuilding Where Id = @id ";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@yachtName", tb.Text);
            sqlcommand.Parameters.AddWithValue("@isNewDesign", cb1.Checked);
            sqlcommand.Parameters.AddWithValue("@isNewBuilding", cb2.Checked);
            sqlcommand.Parameters.AddWithValue("@Id", modelId);
            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('更新資料成功')</script>");
                gridview1.EditIndex = -1;
                showGV1();

            }
            connection.Close();


        }
    }
}