﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="company.aspx.cs" Inherits="Yacht0402.FrontPage.Company" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/FrontCompany.css" rel="stylesheet" />
    <html xmlns="http://www.w3.org/1999/xhtml">
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
        <link href="css/style1.css" rel="stylesheet" type="text/css">
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
                <img src="images/company1.jpg" alt="&quot;&quot;" width="967" height="371"></div>
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
                        <p><span>COMPANY </span></p>
                        <ul>
                            <li><a href="#">About Us</a></li>
                            <li><a href="CompanyCertificate.aspx">Certificat</a></li>

                        </ul>



                    </div>




                </div>







                <!--------------------------------左邊選單結束---------------------------------------------------->

                <!--------------------------------右邊選單開始---------------------------------------------------->
                <div id="crumb"><a href="#">Home</a> &gt;&gt; <a href="#">Company  </a>&gt;&gt; <a href="#"><span class="on1">About Us</span></a></div>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
<%--                <div class="right">
                    <div class="right1">
                        <div class="title"><span>About Us</span></div>

                        <!--------------------------------內容開始---------------------------------------------------->
                        <div class="box3">
                            <h4>The Luxury Tayana 48 Pilothouse Lavish Woodwork Is Among</h4>
                            <p>
                                <img src="images/pit010.jpg" alt="&quot;&quot;" width="274" height="192"></p>
                            Founded in 1973, Ta Yang Building Co., Ltd. Has built over 1400 blue water cruising yachts to date. This world renowned custom yacht builder offers a large compliment of sailboats ranging from 37’ to 72’, many offer aft or center cockpit design, deck saloon or pilothouse options.<br>
                            <br>
                            In 2003, Tayana introduced the new Tayana 64 Deck Saloon, designed by Robb Ladd, which offers the latest in building techniques, large sail area and a beam of 18 feet.
                            <br>
                            <br>
                            Tayana Yachts have been considered the leader in building custom interiors for the last two decades, offering it`s clients the luxury of a living arrangement they prefer rather than have to settle for the compromise of a production boat. Using the finest in exotic woods, the best equipment such as Lewmar, Whitlock, Yanmar engines, Selden spars to name a few, Ta yang has achieved the reputation for building one of the finest semi custom blue water cruising yachts in the world, at an affordable price.

                            <br>
                            <br>
                            Peter Chen was recently appointed the General Manager of Tayana. Peter has a wide-ranging knowledge of the yacht building industry; as part of the TAYANA team, Peter’s vision is genuinely rooted in honesty and integrity. “Our aim is to create outstanding styling, live aboard comfort, and safety at sea for every proud Tayana owner.”<br>
                        </div>




                        <!--------------------------------內容結束------------------------------------------------------>
                    </div>
                </div>--%>

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
