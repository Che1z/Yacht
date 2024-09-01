using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht0402.FrontPage
{
    public partial class yachtSpecification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindFirstData();

            if (!Page.IsPostBack) {
                HyperLink1.NavigateUrl = GenerateHref("yachtLayout.aspx");
                HyperLink2.NavigateUrl = GenerateHref("yachtoverview.aspx");
                HyperLink3.NavigateUrl = GenerateHref("yachtSpecification.aspx");

                showRP1();
                showRP5();
                showLiteral();
                showModel();
            }
        }

        public void showModel()
        {
            DbHelper db = new DbHelper();
            string sql = "";
            sql = "SELECT * FROM YachtList where Id = @Id";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = Label1.Text;

            SqlDataReader rd = db.SearchDB(sql, parameter);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    Label2.Text = rd["yachtName"].ToString();
                    Label3.Text = rd["yachtName"].ToString();
                }
            }
            db.CloseDB();

        }

        public void showRP5()
        {
            DbHelper db = new DbHelper();
            string sql = "";
            sql = "SELECT * FROM YachtPhoto where ListId = @Id";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = Label1.Text;

            SqlDataReader rd = db.SearchDB(sql, parameter);
            if (rd.HasRows)
            {
                Repeater5.DataSource = rd;
                Repeater5.DataBind();
            }
            db.CloseDB();
        }


        private string GenerateHref(string pageName)
        {
            return pageName + $"?model={Label1.Text}";  // 這裡可以根據需要動態生成 href 的值
        }

        public void showRP1()
        {
            DbHelper db = new DbHelper();

            string sql = "";


            sql = "SELECT * FROM YachtList";


            SqlDataReader rd = db.SearchDB(sql);
            if (rd.HasRows)
            {
                Repeater1.DataSource = rd;
                Repeater1.DataBind();
            }
            db.CloseDB();
        }
        public string IsNewDesignText(string newDesign)
        {
            if (newDesign == "True")
            {
                return "(New Design)";
            }
            else
            {
                return "";
            }
        }

        public string IsNewBuildingText(string newBuilding)
        {
            if (newBuilding == "True")
            {
                return "(New Building)";
            }
            else
            {
                return "";
            }
        }

        public void showLiteral() {
            DbHelper db = new DbHelper();
            string sqlCommand = $"Select * From YachtList Where Id = @Id";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter["@Id"] = Label1.Text;
            SqlDataReader rd = db.SearchDB(sqlCommand, parameter);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    //string last = $"</div>";

                    Literal1.Text =  HttpUtility.HtmlDecode(rd["specificationContent"].ToString());
                }
            }
            rd.Close();
            db.CloseDB();

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
    }
}