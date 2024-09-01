using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Konscious.Security.Cryptography;

namespace Yacht0402.BackPage
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    bool haveSameAccount = false;

        //    //Sign Up
        //    string email = TextBox1.Text;
        //    string password = TextBox2.Text;
        //    string userName = TextBox3.Text;
        //    DbHelper db = new DbHelper();
        //    string sqlCheckAccount = $"SELECT * FROM UserList WHERE UserEmail = @UserEmail";
        //    Dictionary<string, object> parameter1 = new Dictionary<string, object>();
        //    parameter1["@UserEmail"] = email;
        //    SqlDataReader rd = db.SearchDB(sqlCheckAccount, parameter1);

        //    if (rd.Read())
        //    {
        //        haveSameAccount = true;
        //        Response.Write($"<script>alert('Email已被註冊過')</script>");
        //        TextBox1.Text = "";
        //        TextBox2.Text = "";
        //        TextBox3.Text = "";
        //    }
        //    db.CloseDB();

        //    //無重複帳號才執行加入
        //    if (!haveSameAccount)
        //    {
        //        //Hash 加鹽加密
        //        var salt = CreateSalt();
        //        string saltStr = Convert.ToBase64String(salt); //將 byte 改回字串存回資料表
        //        var hash = HashPassword(password, salt);
        //        string hashPassword = Convert.ToBase64String(hash);
        //        DbHelper db2 = new DbHelper();
        //        string sqlAdd = $"INSERT INTO UserList (UserName, UserEmail, UserPassword, UserSalt) " +
        //            $"VALUES(@userName, @userEmail1, @userPassword, @userSalt)";
        //        Dictionary<string, object> parameter2 = new Dictionary<string, object>();
        //        parameter2["@userName"] = userName;
        //        parameter2["@userEmail1"] = email;
        //        parameter2["@userPassword"] = hashPassword;
        //        parameter2["@userSalt"] = saltStr;
        //        SqlDataReader rd2 = db.SearchDB(sqlAdd, parameter2);

        //        TextBox1.Text = "";
        //        TextBox2.Text = "";
        //        TextBox3.Text = "";
        //        Response.Write("<script>alert('已新增帳戶'); window.location.href = '~/BackPage/LogIn.aspx';</script>");
        //        db2.CloseDB();

        //    }
        //}

    }
}