<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="newsContents.aspx.cs" Inherits="Yacht0402.FrontPage.newsContents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/reset.css" rel="stylesheet" type="text/css">
    <link href="css/style1.css" rel="stylesheet" type="text/css">
    <link href="../CSS/FrontNewsContents.css" rel="stylesheet" />
    <link href="css/newsContent.css" rel="stylesheet" type="text/css">
    <link href="../CSS/backboostrap.css" rel="stylesheet" />

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
                <img src="images/banner02_masks.png" alt="&quot;&quot;">
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
                        <p><span>NEWS</span></p>
                        <ul>
                            <li><a href="#">News &amp; Events</a></li>

                        </ul>



                    </div>




                </div>







                <!--------------------------------左邊選單結束---------------------------------------------------->

                <!--------------------------------右邊選單開始---------------------------------------------------->
                <div id="crumb"><a href="#">Home</a> &gt;&gt; <a href="#">News </a>&gt;&gt; <a href="#"><span class="on1">News &amp; Events</span></a></div>
                <div class="right">
                    <div class="right1">
                        <div class="title"><span>News &amp; Events</span></div>

                        <!--------------------------------內容開始---------------------------------------------------->

                        <div class="box3">
                            <h4>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <span id="ctl00_ContentPlaceHolder1_title"><%#Eval("Title")%></span>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </h4>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <p>
                                        <%#Eval("Contents")%>
                                    </p>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:Repeater ID="Repeater3" runat="server">
                                <ItemTemplate>
                                    <p>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("imgPath")%>' Width="660px" Height="495px" />
                                    </p>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div >

                            <asp:Button ID="Button1" runat="server" Text="回至Lists" CssClass="btn btn-primary mt-3" onclick="Button1_Click"/>
                            </div>

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
