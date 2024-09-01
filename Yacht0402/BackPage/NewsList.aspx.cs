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
    public partial class NewsList : System.Web.UI.Page
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
                        Label4.Text = userName;
                    }
                }
            }
        }
        public void showGV1()
        {
            DbHelper db = new DbHelper();

            string sqlCommand = $"Select Id, Title, Description, SetDate, PinTop  From NewsLists  Order by PinTop DESC";


            SqlDataReader rd = db.SearchDB(sqlCommand);
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

        protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[7].Visible = false;

            //綁定image控制項
            Image image = (Image)e.Row.FindControl("Image1");
            string Id = e.Row.Cells[4].Text;
            DbHelper db2 = new DbHelper();
            string sqlCommand2 = $"Select * From NewsPhoto np " +
                $"Where np.newsContentsId= @Id And isCover = 1";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = Id;
            SqlDataReader rd2 = db2.SearchDB(sqlCommand2, parameter);
            if (rd2.HasRows)
            {
                while (rd2.Read())
                {
                    string imgPath = rd2["imgPath"].ToString();
                    image.ImageUrl = imgPath;
                }
            }
            rd2.Close();
            db2.CloseDB();

            //綁定dropdownlist
            DbHelper db3 = new DbHelper();
            string sqlCommand = $"Select * From NewsPhoto Where newsContentsId = @Id";
            Dictionary<string, object> parameter1 = new Dictionary<string, object>();
            parameter1["@Id"] = Id;
            SqlDataReader rd3 = db3.SearchDB(sqlCommand, parameter1);
            if (rd3.HasRows)
            {
                while (rd3.Read())
                {
                    string fileName = rd3["fileName"].ToString();
                    DropDownList dropdownlist = (DropDownList)e.Row.FindControl("DropDownList1");
                    dropdownlist.Items.Add(new ListItem(fileName, fileName));
                }
            }
            rd3.Close();
            db3.CloseDB();

            // Dropdownlist預設值
            DbHelper db4 = new DbHelper();
            string sqlCommand3 = $"Select * From NewsPhoto Where newsContentsId = @Id And isCover = 1";
            Dictionary<string, object> parameter2 = new Dictionary<string, object>();
            parameter2["@Id"] = Id;
            SqlDataReader rd4 = db4.SearchDB(sqlCommand3, parameter2);
            if (rd4.HasRows)
            {
                while (rd4.Read())
                {
                    string fileName = rd4["fileName"].ToString();
                    DropDownList dropdownlist = (DropDownList)e.Row.FindControl("DropDownList1");
                    dropdownlist.SelectedValue = fileName;
                }
            }
            rd4.Close();
            db4.CloseDB();

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            GridViewRow editRow = gridview1.Rows[gridview1.EditIndex];

            // 找到編輯模式下的 TextBox 控制項
            TextBox txtSetDate = (TextBox)editRow.FindControl("txtSetDate");

            // 找到 Calendar 控制項
            Calendar calendar = (Calendar)sender;

            // 將選定的日期設定為 txtSetDate 的值
            txtSetDate.Text = calendar.SelectedDate.ToShortDateString(); // 或者使用其他格式化方法根據需求設定日期格式
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            // Cover FileName
            DropDownList dropdownlist = (DropDownList)gridview1.Rows[rowIndex].FindControl("DropDownList1");
            // Set Date
            TextBox tb = gridview1.Rows[e.RowIndex].FindControl("txtSetDate") as TextBox;
            // Title
            TextBox tb4 = gridview1.Rows[e.RowIndex].Cells[5].Controls[0] as TextBox;
            //Description
            TextBox tb5 = gridview1.Rows[e.RowIndex].Cells[6].Controls[0] as TextBox;
            //PinTop
            CheckBox cb = gridview1.Rows[e.RowIndex].Cells[8].Controls[0] as CheckBox;
            string IDkey = gridview1.DataKeys[rowIndex].Value.ToString();

            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Update NewsLists " +
                $"SET   " +
                $"SetDate = @SetDate, Title= @Title, Description=@Description, PinTop = @PinTop " +
                $"Where Id = @Id ";
            string sqlCommand2 = $"Update NewsPhoto Set isCover = 0 Where newsContentsId = @Id " +
                                $"Update NewsPhoto Set isCover = 1 Where newsContentsId = @Id And fileName = @fileName";
            ;

            sqlcommand.CommandText = sqlCommand + sqlCommand2;
            sqlcommand.Parameters.AddWithValue("@Id", IDkey);
            sqlcommand.Parameters.AddWithValue("@SetDate", tb.Text);
            sqlcommand.Parameters.AddWithValue("@Title", tb4.Text);
            sqlcommand.Parameters.AddWithValue("@Description", tb5.Text);
            sqlcommand.Parameters.AddWithValue("@PinTop", cb.Checked);
            sqlcommand.Parameters.AddWithValue("@fileName", dropdownlist.SelectedValue);

            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('更新資料成功')</script>");
                gridview1.EditIndex = -1;
                showGV1();
            }
            connection.Close();

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            calendarDate.Text = calendar.SelectedDate.ToShortDateString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Button1.Visible = false;
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Button1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string setDate = calendarDate.Text;
            string title = TextBox1.Text;
            string description = TextBox2.Text;
            bool pinTop = CheckBox1.Checked;

            // 新增Lists時，需自動新增NewsContents將兩筆資料串連在一起
            string sqlCommand = $"INSERT INTO NewsLists (SetDate, Title, Description, PinTop) VALUES (@setDate, @title, @description, @pinTop) " +
                $" DECLARE @NewID INT " +
                $"SET @NewID = SCOPE_IDENTITY() " +
                $"INSERT INTO NewsContents (NewsListId) VALUES (@NewID) ";

            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@setDate", setDate);
            sqlcommand.Parameters.AddWithValue("@title", title);
            sqlcommand.Parameters.AddWithValue("@description", description);
            sqlcommand.Parameters.AddWithValue("@pinTop", pinTop);

            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('新增資料成功')</script>");
                showGV1();
            }
            connection.Close();
            // 清空Label, Textbox內容
            calendarDate.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";

            Button1.Visible = true;
            Panel1.Visible = false;
        }

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            //Id
            string IDkey = gridview1.DataKeys[rowIndex].Value.ToString();

            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = "DELETE FROM NewsLists WHERE Id = @Id;";
            string sqlCommand2 = "DELETE FROM NewsContents WHERE NewsListId = @Id1;";

            sqlcommand.CommandText = sqlCommand + sqlCommand2;
            sqlcommand.Parameters.AddWithValue("@Id", IDkey);
            sqlcommand.Parameters.AddWithValue("@Id1", IDkey);


            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
            if (result > 0)
            {
                Response.Write($"<script>alert('刪除資料成功')</script>");
                gridview1.EditIndex = -1;
                showGV1();
            }
            connection.Close();
        }
    }
}
