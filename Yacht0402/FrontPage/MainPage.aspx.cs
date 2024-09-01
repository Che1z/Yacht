using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht0402.FrontPage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showRP1();
                showRP2();
                showRP3();
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
            int pageSize = 3;
            int offsetNumber = 0;

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

        public string isPinTop(string order)
        {
            if (order == "True")
            {
                return " images/new_top01.png";
            }
            else
            {
                return "";
            }

        }

        public string isNewBuilding(string newbuild)
        {
            if (newbuild == "True")
            {
                return "images/new01.png";
            }
            else
            {
                return "";
            }
        }

        public string isNewDesign(string newbuild)
        {
            if (newbuild == "True")
            {
                return "images/new02.png";
            }
            else
            {
                return "";
            }
        }

        public void showRP2()
        {

            DbHelper db = new DbHelper();
            string sql = "";

            sql = "SELECT * FROM ( SELECT yt.isNewBuilding, yt.isNewDesign, yt.yachtName, yp.imgPath, ROW_NUMBER() OVER(PARTITION BY yt.yachtName ORDER BY yp.CreateAt DESC) AS RowNum FROM yachtlist yt INNER JOIN yachtphoto yp ON yt.Id = yp.ListId ) AS RankedPhotos WHERE RowNum = 1 ";


            SqlDataReader rd = db.SearchDB(sql);
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

            sql = "SELECT * FROM ( SELECT yt.isNewBuilding, yt.isNewDesign, yt.yachtName, yp.imgPath, ROW_NUMBER() OVER(PARTITION BY yt.yachtName ORDER BY yp.CreateAt DESC) AS RowNum FROM yachtlist yt INNER JOIN yachtphoto yp ON yt.Id = yp.ListId ) AS RankedPhotos WHERE RowNum = 1 ";


            SqlDataReader rd = db.SearchDB(sql);
            if (rd.HasRows)
            {
                Repeater3.DataSource = rd;
                Repeater3.DataBind();
            }
            db.CloseDB();
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            // 取得 Literal 控制項
            Literal literal = (Literal)e.Item.FindControl("Literal1");

            if (e.Item.ItemIndex == 0)
            {
                // 當 ItemIndex 為 0 時，設定 literal 的內容為指定的文字
                literal.Text = "<li class=\"info\" style=\"display:list-item\">";
            }
            else
            {
                // 其他情況設定為 display:none
                literal.Text = "<li class=\"info\" style=\"display:none\">";
            }

        }

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // 取得 Literal 控制項
            Literal literal = (Literal)e.Item.FindControl("Literal2");

            if (e.Item.ItemIndex == 0)
            {
                literal.Text = "<li class=\"on\" >";
            }
            else
            {
                literal.Text = "<li>";
            }
        }

        public string FirstModelName(string modelName) {
            string[] splitName = modelName.Split(' ');
            return splitName[0];
        }
        public string RestModelName(string modelName) {
            string[] splitName = modelName.Split(' ');
            string result = "";
            for (int i = 1; i < splitName.Length; i++)
            {
                result += splitName[i];
            }
            return result;
        }
   }
}