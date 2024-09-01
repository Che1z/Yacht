using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht0402.FrontPage
{
    public partial class newsContents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                showRP1();
                showRP2();
                showRP3();
            }
        }
        public void showRP1() {
            DbHelper db = new DbHelper();
            string sql = "";
            string ListId1 = string.IsNullOrEmpty(Request.QueryString["contents"])  ? "1" : Request.QueryString["contents"];
            string ListId = Request.QueryString["contents"];
            sql = "Select * From NewsLists nl Where nl.Id = @Id";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = ListId1;

            SqlDataReader rd = db.SearchDB(sql, parameter);
            if (rd.HasRows)
            {
                Repeater1.DataSource = rd;
                Repeater1.DataBind();
            }
            db.CloseDB();
        }

        public void showRP2()
        {
            DbHelper db = new DbHelper();
            string sql = "";
            string ListId1 = string.IsNullOrEmpty(Request.QueryString["contents"]) ? "1" : Request.QueryString["contents"];
            sql = "Select * From  NewsContents nc Where nc.NewsListId = @Id";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = ListId1;

            SqlDataReader rd = db.SearchDB(sql, parameter);
            if (rd.HasRows)
            {
                Repeater2.DataSource = rd;
                Repeater2.DataBind();
            }
            db.CloseDB();
        }

        public void showRP3()
        {
            DbHelper db = new DbHelper();
            string sql = "";
            string ListId1 = string.IsNullOrEmpty(Request.QueryString["contents"]) ? "1" : Request.QueryString["contents"];
            sql = "Select * From  NewsPhoto np Where np.newsContentsId = @Id";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = ListId1;

            SqlDataReader rd = db.SearchDB(sql, parameter);
            if (rd.HasRows)
            {
                Repeater3.DataSource = rd;
                Repeater3.DataBind();
            }
            db.CloseDB();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("news.aspx");
        }
    }
}