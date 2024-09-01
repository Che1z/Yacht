using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace Yacht0402.FrontPage
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindDL1();
                bindDL2();
            }
        }

        public void bindDL1()
        {
            DbHelper db = new DbHelper();

            string sql = "SELECT AreaName FROM DealerArea";

            using (SqlDataReader rd = db.SearchDB(sql))
            {
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string areaName = rd["AreaName"].ToString();
                        DropDownList1.Items.Add(new ListItem(areaName,areaName));
                    }
                }
            }
            db.CloseDB();

        }

        public void bindDL2()
        {
            DbHelper db = new DbHelper();

            string sql = "SELECT yachtName FROM YachtList";

            using (SqlDataReader rd = db.SearchDB(sql))
            {
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string modelName = rd["yachtName"].ToString();
                        DropDownList2.Items.Add(new ListItem(modelName, modelName));
                    }
                }
            }
            db.CloseDB();

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            sendGmail();
            Response.Write("<script>alert('Thank you for contacting us!');location.href='Contact.aspx';</script>");

        }

        public void sendGmail()
        {
            //宣告使用 MimeMessage
            var message = new MimeMessage();
            //設定發信地址 ("發信人", "發信 email")
            message.From.Add(new MailboxAddress("TayanaYacht", "XXXXXXX@gmail.com"));
            //設定收信地址 ("收信人", "收信 email")
            message.To.Add(new MailboxAddress(TextBox1.Text.Trim(), TextBox2.Text.Trim()));
            //寄件副本email
            message.Cc.Add(new MailboxAddress("收信人名稱", "XXXXXXX@gmail.com"));
            //設定優先權
            //message.Priority = MessagePriority.Normal;
            //信件標題
            message.Subject = "TayanaYacht Auto Email";
            //建立 html 郵件格式
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody =
                "<h1>Thank you for contacting us!</h1>" +
                $"<h3>Name : {TextBox1.Text.Trim()}</h3>" +
                $"<h3>Email : {TextBox2.Text.Trim()}</h3>" +
                $"<h3>Phone : {TextBox3.Text.Trim()}</h3>" +
                $"<h3>Country : {DropDownList1.SelectedValue}</h3>" +
                $"<h3>Type : {DropDownList2.SelectedValue}</h3>" +
                $"<h3>Comments : </h3>" +
                $"<p>{TextBox4.Text.Trim()}</p>";
            //設定郵件內容
            message.Body = bodyBuilder.ToMessageBody(); //轉成郵件內容格式

            using (var client = new SmtpClient())
            {
                //有開防毒時需設定 false 關閉檢查
                client.CheckCertificateRevocation = false;
                //設定連線 gmail ("smtp Server", Port, SSL加密) 
                client.Connect("smtp.gmail.com", 587, false); // localhost 測試使用加密需先關閉 

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("yacht20240423@gmail.com", "bgtr aumj bnoq bjkd");
                //發信
                client.Send(message);
                //結束連線
                client.Disconnect(true);
            }
        }
    }
}