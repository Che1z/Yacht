using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht0402.FrontPage
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                showRP1();
                showRP2();
                showRP3();
                showRP4();
            }
        }
        public void showRP1()
        {
            DbHelper db = new DbHelper();

            string sql = "";

            //Page
            string pageQueryString = Request.QueryString["page"];
            string pageNumber = string.IsNullOrEmpty(pageQueryString) ? "1" : pageQueryString;
            //Area
            int pageNumberInt = Convert.ToInt32(pageNumber);
            int pageSize = 5;
            int offsetNumber = (pageNumberInt - 1) * pageSize;

            sql = $"SELECT nl.SetDate,nl.Id, nl.Title, nl.PinTop,nl.Description, " +
                $"IIF(EXISTS (SELECT 1 FROM NewsPhoto WHERE newsContentsId = nl.Id AND isCover = 1), " +
                $"(SELECT imgPath FROM NewsPhoto WHERE newsContentsId = nl.Id AND isCover = 1), '') " +
                $"AS imgPath " +
                $"FROM NewsLists nl Order by nl.PinTop DESC " +
                $"OFFSET @offsetNumber ROWS FETCH NEXT @pageSize ROWS ONLY";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@offsetNumber"] = offsetNumber;
            parameters["@pageSize"] = pageSize;

            SqlDataReader rd = db.SearchDB(sql, parameters);
            if (rd.HasRows)
            {
                Repeater1.DataSource = rd;
                Repeater1.DataBind();
            }
            db.CloseDB();
        }
        protected string GenerateAnchorTags(int count)
        {
            StringBuilder anchors = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                string currentUrl = Request.Url.AbsolutePath;
                string newUrl = currentUrl + $"?page={i + 1}";
                if (Request.QueryString["page"] != null)
                {
                    newUrl = $"news?page={i + 1}";
                }

                anchors.Append($" | <a href='{newUrl}'>{i + 1}</a>");
            }
            return anchors.ToString();
        }

        protected int TrimPage(int count)
        {
            if (count % 5 != 0)
            {
                return count / 5 + 1;
            }
            else
            {
                return count / 5;
            }
        }

        public void showRP2()
        {
            DbHelper db = new DbHelper();
            string sql = "";
        
                sql = "Select Count(nl.Id) as Count From NewsLists nl";
            

            SqlDataReader rd = db.SearchDB(sql);
            if (rd.HasRows)
            {
                Repeater2.DataSource = rd;
                Repeater2.DataBind();
            }
            db.CloseDB();

        }

        public void showRP3() {
            DbHelper db = new DbHelper();
            string sql = "";

            sql = "Select Count(nl.Id) as totalCount  From NewsLists nl";


            SqlDataReader rd = db.SearchDB(sql);
            if (rd.HasRows)
            {
                Repeater3.DataSource = rd;
                Repeater3.DataBind();
            }
            db.CloseDB();

        }
        public void showRP4()
        {
            DbHelper db = new DbHelper();
            string sql = "";

            sql = "Select Count(nl.Id) as Count  From NewsLists nl";


            SqlDataReader rd = db.SearchDB(sql);
            if (rd.HasRows)
            {
                Repeater4.DataSource = rd;
                Repeater4.DataBind();
            }
            db.CloseDB();

        }

    }
}