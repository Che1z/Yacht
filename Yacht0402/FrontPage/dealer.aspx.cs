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
    public partial class dealer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showRP1();
                showRP2();
                showRP3();
                showRP4();
                showRP5();
                showRP6();
                showRP7();
            }
        }
        public void showRP1()
        {
            DbHelper db = new DbHelper();

            string sql = "";


            sql = "SELECT  * FROM DealerArea";


            SqlDataReader rd = db.SearchDB(sql);
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
            //Page
            string pageQueryString = Request.QueryString["page"];
            string pageNumber = string.IsNullOrEmpty(pageQueryString) ? "1" : pageQueryString;
            //Area
            string areaQueryString = Request.QueryString["dealer"];
            string areaNumber = string.IsNullOrEmpty(areaQueryString) ? "1" : areaQueryString;
            int pageNumberInt = Convert.ToInt32(pageNumber);
            int pageSize = 3;
            int offsetNumber = (pageNumberInt - 1) * pageSize;

            //若是Dictionary使用<string,string>會導致得到非整數結果問題
            //改用object直接傳入int進行計算確保結果為整數
            sql = $"Select * From Dealer d " +
                "Inner Join DealerArea da on da.Id = d.areaId " +
                "LEFT Join DealerPhoto dp on dp.dealerId = d.Id and dp.IsCover = 1 " +
                $"Where da.Id = @areaNumber " +
                $" ORDER BY d.createAt ASC  OFFSET @offsetNumber ROWS FETCH NEXT @pageSize ROWS ONLY  ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@areaNumber"] = areaNumber;
            parameters["@offsetNumber"] = offsetNumber;
            parameters["@pageSize"] = pageSize;

            SqlDataReader rd = db.SearchDB(sql, parameters);
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
            if (Request.QueryString["dealer"] != null)
            {
                string areaNumber = Request.QueryString["dealer"];
                sql = $"Select Top 1 da.AreaName From Dealer d " +
                "Inner Join DealerArea da on da.Id = d.areaId " +
                "LEFT Join DealerPhoto dp on dp.dealerId = d.Id and dp.IsCover = 1 " +
                $"Where da.Id = {areaNumber} ";

            }
            else
            {
                sql = "Select Top 1 da.AreaName From Dealer d " +
                    "Inner Join DealerArea da on da.Id = d.areaId " +
                    "LEFT Join DealerPhoto dp on dp.dealerId = d.Id and dp.IsCover = 1 " +
                    "Where da.Id = 1";
            }

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
            if (Request.QueryString["dealer"] != null)
            {
                string areaNumber = Request.QueryString["dealer"];
                sql = $"Select Top 1 da.AreaName From Dealer d " +
                "Inner Join DealerArea da on da.Id = d.areaId " +
                "LEFT Join DealerPhoto dp on dp.dealerId = d.Id and dp.IsCover = 1 " +
                $"Where da.Id = {areaNumber} ";

            }
            else
            {
                sql = "Select Top 1 da.AreaName From Dealer d " +
                    "Inner Join DealerArea da on da.Id = d.areaId " +
                    "LEFT Join DealerPhoto dp on dp.dealerId = d.Id and dp.IsCover = 1 " +
                    "Where da.Id = 1";
            }

            SqlDataReader rd = db.SearchDB(sql);
            if (rd.HasRows)
            {
                Repeater4.DataSource = rd;
                Repeater4.DataBind();
            }
            db.CloseDB();
        }

        public void showRP5()
        {
            DbHelper db = new DbHelper();
            string sql = "";
            if (Request.QueryString["dealer"] != null)
            {
                string areaNumber = Request.QueryString["dealer"];
                sql = "Select Count(d.Id) as Count " +
                     "From Dealer d " +
                     $"Where d.areaId = {areaNumber}";

            }
            else
            {
                sql = "Select Count(d.Id) as Count " +
                    "From Dealer d " +
                    "Where d.areaId = 1";
            }

            SqlDataReader rd = db.SearchDB(sql);
            if (rd.HasRows)
            {
                Repeater5.DataSource = rd;
                Repeater5.DataBind();
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
                if (Request.QueryString["dealer"] != null)
                {
                    newUrl = $"dealer?dealer={Request.QueryString["dealer"]}&page={i + 1}";
                }

                anchors.Append($" | <a href='{newUrl}'>{i + 1}</a>");
            }
            return anchors.ToString();
        }
        protected int TrimPage(int count)
        {
            if (count % 3 != 0)
            {
                return count / 3 + 1;
            }
            else
            {
                return count / 3;
            }
        }

        public void showRP6()
        {
            DbHelper db = new DbHelper();
            string sql = "";
            if (Request.QueryString["dealer"] != null)
            {
                string areaNumber = Request.QueryString["dealer"];
                sql = "Select Count(d.Id) as totalCount " +
                     "From Dealer d " +
                     $"Where d.areaId = {areaNumber} ";

            }
            else
            {
                sql = "Select Count(d.Id) as totalCount " +
                    "From Dealer d " +
                    "Where d.areaId = 1";
            }

            SqlDataReader rd = db.SearchDB(sql);
            if (rd.HasRows)
            {
                Repeater6.DataSource = rd;
                Repeater6.DataBind();
            }
            db.CloseDB();

        }
        public void showRP7()
        {
            DbHelper db = new DbHelper();
            string sql = "";
            if (Request.QueryString["dealer"] != null)
            {
                string areaNumber = Request.QueryString["dealer"];
                sql = "Select Count(d.Id) as Count " +
                     "From Dealer d " +
                     $"Where d.areaId = {areaNumber}";

            }
            else
            {
                sql = "Select Count(d.Id) as Count " +
                    "From Dealer d " +
                    "Where d.areaId = 1";
            }

            SqlDataReader rd = db.SearchDB(sql);
            if (rd.HasRows)
            {
                Repeater7.DataSource = rd;
                Repeater7.DataBind();
            }
            db.CloseDB();

        }



    }
}