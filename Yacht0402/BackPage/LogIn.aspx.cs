using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.Configuration;
using System.Data;

namespace Yacht0402.BackPage
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Argon2 加密
        //產生 Salt 功能
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
        // Hash 處理加鹽的密碼功能
        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            //底下這些數字會影響運算時間，而且驗證時要用一樣的值
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // 4 核心就設成 8
            argon2.Iterations = 4; // 迭代運算次數
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(16);
        }

     
        //驗證
        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash); // LINEQ
        }

        //設定驗證票
        private void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票 //需額外引入 using System.Web.Security;
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(3), false, userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立 Cookie
            HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //將 Cookie 寫入回應
            Response.Cookies.Add(authenticationCookie);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           

        }

        //Log In
        protected void Button1_Click2(object sender, EventArgs e)
        {
            // Log In
            string email = TextBox1.Text;
            string password = TextBox2.Text;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtConnectionString"].ConnectionString);
            string sqlCheckAccount = $"SELECT * FROM UserList WHERE UserEmail = @UserEmail2";
            SqlCommand command = new SqlCommand(sqlCheckAccount, connection);
            command.Parameters.AddWithValue("@UserEmail2", email);
            // 5.資料庫用 Adapter 執行指令
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            // 6.建立一個空的 Table
            DataTable dataTable = new DataTable();
            // 7.將資料放入 Table
            dataAdapter.Fill(dataTable);
            // 登入流程管理 (Cookie)
            if (dataTable.Rows.Count > 0)
            {
                // SQL 有找到資料時執行

                //將字串轉回 byte
                byte[] hash = Convert.FromBase64String(dataTable.Rows[0]["UserPassword"].ToString());
                byte[] salt = Convert.FromBase64String(dataTable.Rows[0]["UserSalt"].ToString());
                //驗證密碼
                bool success = VerifyHash(password, salt, hash);

                if (success)
                {
                    //宣告驗證票要夾帶的資料 (用;區隔)
                    string userData =  dataTable.Rows[0]["UserEmail"].ToString() + ";" + dataTable.Rows[0]["UserName"].ToString() ;
                    //設定驗證票(夾帶資料，cookie 命名) // 需額外引入using System.Web.Configuration;
                    SetAuthenTicket(userData, email);
                    //導頁至權限分流頁
                    Response.Redirect("Dealer.aspx");
                }
                else
                {
                    //資料庫裡找不到相同資料時，表示密碼有誤!
                    Response.Write($"<script>alert('密碼錯誤')</script>");

                    connection.Close();

                    return;
                }
            }
            else
            {
                //資料庫裡找不到相同資料時，表示帳號有誤!
                Response.Write($"<script>alert('Account Error')</script>");

                //終止程式
                //Response.End(); //會清空頁面
                return;
            }
            connection.Close();
        }

        //Sign Up
        protected void Button2_Click(object sender, EventArgs e)
        {
            bool haveSameAccount = false;

            //Sign Up
            string email = TextBox1.Text;
            string password = TextBox2.Text;
            string userName = TextBox3.Text;
            DbHelper db = new DbHelper();
            string sqlCheckAccount = $"SELECT * FROM UserList WHERE UserEmail = @UserEmail";
            Dictionary<string, object> parameter1 = new Dictionary<string, object>();
            parameter1["@UserEmail"] = email;
            SqlDataReader rd = db.SearchDB(sqlCheckAccount, parameter1);

            if (rd.Read())
            {
                haveSameAccount = true;
                Response.Write($"<script>alert('Email已被註冊過')</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
            db.CloseDB();

            //無重複帳號才執行加入
            if (!haveSameAccount)
            {
                //Hash 加鹽加密
                var salt = CreateSalt();
                string saltStr = Convert.ToBase64String(salt); //將 byte 改回字串存回資料表
                var hash = HashPassword(password, salt);
                string hashPassword = Convert.ToBase64String(hash);
                DbHelper db2 = new DbHelper();
                string sqlAdd = $"INSERT INTO UserList (UserName, UserEmail, UserPassword, UserSalt) " +
                    $"VALUES(@userName, @userEmail1, @userPassword, @userSalt)";
                Dictionary<string, object> parameter2 = new Dictionary<string, object>();
                parameter2["@userName"] = userName;
                parameter2["@userEmail1"] = email;
                parameter2["@userPassword"] = hashPassword;
                parameter2["@userSalt"] = saltStr;
                SqlDataReader rd2 = db.SearchDB(sqlAdd, parameter2);

                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                Response.Write("<script>alert('已新增帳戶'); window.location.href = '/BackPage/LogIn.aspx';</script>");

                db2.CloseDB();

            }


        }


    }
}