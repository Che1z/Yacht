using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht0402.FrontPage
{
    public partial class CompanyCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                labelBind();
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
                    string first = $"<div class=\"right\"> <div class=\"right1\"> ";
                    string last = $"</div></div>";

                    Literal1.Text = first + HttpUtility.HtmlDecode(rd["editorContent"].ToString()) + last;
                }
            }
            rd.Close();
            db.CloseDB();


        }
    }
}