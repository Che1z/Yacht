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
    public partial class DealerNumber : System.Web.UI.Page
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
                        Label7.Text = userName;
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
                sqlCommand = $"Select d.Id, da.AreaName, d.cityName, d.companyName, d.cellNumber, d.faxNumber, d.telNumber " +
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

        protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
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
            TextBox cityName = gridview1.Rows[rowIndex].Cells[4].Controls[0] as TextBox;
            TextBox companyName = gridview1.Rows[rowIndex].Cells[5].Controls[0] as TextBox;
            TextBox cellNumber = gridview1.Rows[rowIndex].Cells[6].Controls[0] as TextBox;
            TextBox faxNumber = gridview1.Rows[rowIndex].Cells[7].Controls[0] as TextBox;
            TextBox telNumber = gridview1.Rows[rowIndex].Cells[8].Controls[0] as TextBox;
            String IDkey = gridview1.DataKeys[rowIndex].Value.ToString();
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            string sqlCommand = $"Update Dealer " +
                $"SET   " +
                $"companyName = @companyName, cellNumber= @cellNumber, faxNumber=@faxNumber, " +
                $" telNumber = @telNumber " +
                $"Where Id = @Id";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@cityName", cityName.Text);
            sqlcommand.Parameters.AddWithValue("@companyName", companyName.Text);
            sqlcommand.Parameters.AddWithValue("@cellNumber", cellNumber.Text);
            sqlcommand.Parameters.AddWithValue("@faxNumber", faxNumber.Text);
            sqlcommand.Parameters.AddWithValue("@telNumber", telNumber.Text);
            
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
            string sqlCommand = $"Insert into Dealer (areaId, cityName,companyName,cellNumber,faxNumber,telNumber) " +
                $"Select top 1 da.id, @cityName, @companyName, @cellNumber, @faxNumber, @telNumber " +
                $"from DealerArea da " +
                $"INNER JOIN Dealer d ON da.Id = d.areaId " +
                $" WHERE da.AreaName = '{DropDownList2.SelectedValue}' ";
            sqlcommand.CommandText = sqlCommand;
            sqlcommand.Parameters.AddWithValue("@cityName", TextBox1.Text);
            sqlcommand.Parameters.AddWithValue("@companyName", TextBox2.Text);
            sqlcommand.Parameters.AddWithValue("@cellNumber", TextBox3.Text);
            sqlcommand.Parameters.AddWithValue("@faxNumber", TextBox4.Text);
            sqlcommand.Parameters.AddWithValue("@telNumber", TextBox5.Text);
            int result = sqlcommand.ExecuteNonQuery(); // Command物件的命令賦予SQLSentence字串
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
            Button1.Visible = true;
            Panel1.Visible = false;
        }
    }
    
}