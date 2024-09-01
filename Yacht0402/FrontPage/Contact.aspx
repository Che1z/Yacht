<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Yacht0402.FrontPage.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/FrontContact.css" rel="stylesheet" />
    <link href="css/style1.css" rel="stylesheet" type="text/css">
    <link href="css/homestyle.css" rel="stylesheet" type="text/css">
    <link href="css/reset.css" rel="stylesheet" type="text/css">
    <html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
        <title>TtayanaWorld (DEMO)</title>
        <script type="text/javascript" src="Scripts/jquery.min.js"></script>
        <script type="text/javascript" src="Scripts/jquery.cycle.all.2.74.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $('.slideshow').cycle({
                    fx: 'fade' // choose your transition type, ex: fade, scrollUp, shuffle, etc...
                });
            });
        </script>
        <!--[if lt IE 7]>
<script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
<![endif]-->
        <link href="css/homestyle.css" rel="stylesheet" type="text/css">
        <link href="css/reset.css" rel="stylesheet" type="text/css">
    </head>

    <body>
        <div class="contain">
            <div class="sub">
                <p><a href="MainPage.aspx">Home</a></p>
            </div>

            <!--------------------------------選單開始---------------------------------------------------->
            <div class="menu">
                <ul>
                    <li class="menuli01"><a href="yachtoverview.aspx">
                        <img src="images/mmmmeeeee.gif" alt="&quot;&quot;" />Yachts</a></li>
                    <li class="menuli02"><a href="news.aspx">
                        <img src="images/mmmmeeeee.gif" alt="&quot;&quot;" />NEWS</a></li>
                    <li class="menuli03"><a href="company.aspx">
                        <img src="images/mmmmeeeee.gif" alt="&quot;&quot;" />COMPANY</a></li>
                    <li class="menuli04"><a href="dealer.aspx">
                        <img src="images/mmmmeeeee.gif" alt="&quot;&quot;" />DEALERS</a></li>
                    <li class="menuli05"><a href="contact.aspx">
                        <img src="images/mmmmeeeee.gif" alt="&quot;&quot;" />CONTACT</a></li>
                </ul>
            </div>
            <!--------------------------------選單開始結束---------------------------------------------------->

            <!--遮罩-->
            <div class="bannermasks">
                <img src="images/contact1.jpg" alt="&quot;&quot;" width="967" height="371">
            </div>
            <!--遮罩結束-->

            <!--<div id="buttom01"><a href="#"><img src="images/buttom01.gif" alt="next" /></a></div>-->

            <!--小圖開始-->
            <!--<div class="bannerimg">
<ul>
<li> <a href="#"><div class="on"><p class="bannerimg_p"><img  src="images/pit003.jpg" alt="&quot;&quot;" /></p></div></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" width="300" /></p>
</a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>

<ul>
<li> <a class="on" href="#"><p class="bannerimg_p"><img  src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <p class="bannerimg_p"><a href="#"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>


</div>-->
            <!--小圖結束-->


            <!--<div id="buttom02"> <a href="#"><img src="images/buttom02.gif" alt="next" /></a></div>-->

            <!--------------------------------換圖開始---------------------------------------------------->

            <div class="banner">
                <ul>
                    <li>
                        <img src="images/newbanner.jpg" alt="Tayana Yachts"></li>
                </ul>

            </div>
            <!--------------------------------換圖結束---------------------------------------------------->




            <div class="conbg">
                <!--------------------------------左邊選單開始---------------------------------------------------->
                <div class="left">

                    <div class="left1">
                        <p><span>CONTACT</span></p>
                        <ul>
                            <li><a href="#">contacts</a></li>
                        </ul>



                    </div>




                </div>







                <!--------------------------------左邊選單結束---------------------------------------------------->

                <!--------------------------------右邊選單開始---------------------------------------------------->
                <div id="crumb"><a href="#">Home</a> &gt;&gt; <a href="#"><span class="on1">Contact</span></a></div>
                <div class="right">
                    <div class="right1">
                        <div class="title"><span>Contact</span></div>

                        <!--------------------------------內容開始---------------------------------------------------->
                        <!--表單-->
                        <div class="from01">
                            <p>
                                Please Enter your contact information<span class="span01">*Required</span>
                            </p>
                            <br>
                            <table>
                                <tbody>
                                    <tr>
                                        <td class="from01td01">Name :</td>
                                        <td><span>*</span>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            <%--                                            <input type="text" name="textfield" id="textfield">--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="from01td01">Email :</td>
                                        <td><span>*</span>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            <%--                                            <input type="text" name="textfield" id="textfield">--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="from01td01">Phone :</td>
                                        <td><span>*</span>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                            <%--                                            <input type="text" name="textfield" id="textfield">--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="from01td01">Country :</td>
                                        <td><span>*</span>

                                            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><span>*</span>Brochure of interest  *Which Brochure would you like to view?</td>
                                    </tr>
                                    <tr>
                                        <td class="from01td01">Model :</td>
                                        <td>
                                            <%--                                                <option>Dynasty 72 </option>--%>
                                            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="from01td01">Comments:</td>
                                        <td>
                                            <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Height="54px" Width="163px"></asp:TextBox>
<%--                                            <textarea name="textarea" id="textarea" cols="45" rows="5"></textarea></td>--%>
                                    </tr>
                                    <tr>
                                        <td class="from01td01">&nbsp;</td>
                                        <td class="f_right"><a href="#">
                                            <asp:ImageButton ID="ImageButton1" runat="server" width="59" height="25" imageUrl="images/buttom03.gif" OnClick="ImageButton1_Click"/>
<%--                                            <img src="images/buttom03.gif" alt="submit" width="59" height="25"></a></td>--%>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!--表單-->

                        <div class="box1">
                            <span class="span02">Contact with us</span><br>
                            Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our potential customers. 
If you have any questions about our yachts or would like to take your interest a stage further, please feel free to contact us.
                        </div>

                        <div class="list03">
                            <p>
                                <span>TAYANA HEAD OFFICE</span><br>
                                NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br>
                                tel. +886(7)641 2422<br>
                                fax. +886(7)642 3193<br>
                                info@tayanaworld.com<br>
                            </p>
                        </div>


                        <div class="list03">
                            <p>
                                <span>SALES DEPT.</span><br>
                                +886(7)641 2422  ATTEN. Mr.Basil Lin<br>
                                <br>
                            </p>
                        </div>

                        <div class="box4">
                            <h4>Location</h4>
                            <p>
<%--                            <iframe width="695" height="518" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"  src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d8071.776702415669!2d120.3910824650149!3d22.504480786284777!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1sNO.60%20Haichien%20Rd.%20Chungmen%20Village%20Linyuan%20Kaohsiung%20Hsien%20832%20Taiwan%20R.O.C!5e0!3m2!1szh-TW!2stw!4v1713861465107!5m2!1szh-TW!2stw" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>--%>
                            <iframe  width="695" height="518" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"   src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d946.0080037538827!2d120.31049892242768!3d22.62825581786179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1sNO.60%20Haichien%20Rd.%20Chungmen%20Village%20Linyuan%20Kaohsiung%20Hsien%20832%20Taiwan%20R.O.C!5e0!3m2!1szh-TW!2stw!4v1713862515614!5m2!1szh-TW!2stw" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                            </p>

                        </div>
                        <!--------------------------------內容結束------------------------------------------------------>
                    </div>
                </div>

                <!--------------------------------右邊選單結束---------------------------------------------------->
            </div>


            <!--------------------------------落款開始---------------------------------------------------->
            <div class="footer">
                <p class="footerp01">© 1973-2011 Tayana Yachts, Inc. All Rights Reserved</p>
                <div class="footer01">
                    <span>No. 60, Hai Chien Road, Chung Men Li, Lin Yuan District, Kaohsiung City, Taiwan, R.O.C.</span><br>
                    <span>TEL：+886(7)641-2721</span> <span>FAX：+886(7)642-3193</span><span><a href="mailto:tayangco@ms15.hinet.net">E-mail：tayangco@ms15.hinet.net</a>.</span>
                </div>
            </div>
            <!--------------------------------落款結束---------------------------------------------------->

        </div>


    </body>
    </html>
</asp:Content>
