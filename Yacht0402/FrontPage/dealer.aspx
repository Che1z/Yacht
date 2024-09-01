<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="dealer.aspx.cs" Inherits="Yacht0402.FrontPage.dealer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <link href="../CSS/FrontDealer1.css" rel="stylesheet" />
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
                <img src="images/DEALERS1.jpg" alt="&quot;&quot;" width="967" height="371">
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
                        <p><span>DEALERS</span></p>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <ul>
                                    <li><a href='<%# $"?dealer={Eval("Id")}&page=1" %>'><%#Eval("AreaName ")%></a></li>
                                </ul>
                            </ItemTemplate>

                        </asp:Repeater>
                        <%--                        原先標籤--%>
                        <%--                        <ul>
                            <li><a href="#">Unite States</a></li>
                            <li><a href="#">Europe</a></li>
                            <li><a href="#">Asia</a></li>
                        </ul>--%>
                    </div>
                </div>

                <!--------------------------------左邊選單結束---------------------------------------------------->

                <!--------------------------------右邊選單開始---------------------------------------------------->
                <div id="crumb">
                    <a href="#">Home</a> &gt;&gt; <a href="#">Dealers </a>&gt;&gt; <a href="#">
                        <asp:Repeater ID="Repeater4" runat="server">
                            <ItemTemplate>
                                <span class="on1"><%#Eval("AreaName ")%></span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </a>
                </div>
                <div class="right">
                    <div class="right1">
                        <div class="title">
                            <asp:Repeater ID="Repeater3" runat="server">
                                <ItemTemplate>
                                    <span>
                                        <%#Eval("AreaName ")%>

                                    </span>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <!--------------------------------內容開始---------------------------------------------------->
                        <div class="box2_list">
                            <ul>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="list02">
                                                <ul>
                                                    <li class="list02li">
                                                        <div>
                                                            <p>
                                                                <img src='<%#Eval("imgPath ")%>'>&gt;
                                                            </p>
                                                        </div>
                                                    </li>
                                                    <li><span><%#Eval("CityName ")%></span><br>
                                                        <%#Eval("companyName ")%><br>
                                                        Contact：+ <%#Eval("contactName ")%>
                                                        <br>
                                                        <%# String.IsNullOrEmpty(Eval("addressName").ToString()) ? "" :  Eval("addressName") + "<br>" %>
                                                        <%# String.IsNullOrEmpty(Eval("telNumber").ToString()) ? "" : "TEL: " + Eval("telNumber") + "<br>" %>
                                                        <%# String.IsNullOrEmpty(Eval("faxNumber").ToString()) ?"" : "FAX:  " + Eval("faxNumber") + "<br>" %>
                                                        <%# String.IsNullOrEmpty(Eval("cellNumber").ToString()) ?"" : "CELL:  " + Eval("cellNumber") + "<br>" %>
                                                        <%# String.IsNullOrEmpty(Eval("email").ToString())  ?"" : "E-mail: " + Eval("email") + "<br>" %>
                                                        <a href=' <%# String.IsNullOrEmpty(Eval("link").ToString())  ?"#" : Eval("link")%>'
                                                            target="_blank"><%# String.IsNullOrEmpty(Eval("link").ToString())  ?"" : Eval("link")%>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </li>

                                    </ItemTemplate>
                                </asp:Repeater>

                                <%--                                <li>
                                    <div class="list02">
                                        <ul>
                                            <li class="list02li">
                                                <div>
                                                    <p>
                                                        <img src="images/dealers002.jpg" alt="&quot;&quot;">
                                                    </p>
                                                </div>
                                            </li>
                                            <li><span>San Francisco</span><br>
                                                Pacific Yacht Imports<br>
                                                Contact：Mr. Neil Weinberg<br>
                                                Address：Grand Marina 2051 Grand Street# 12 Alameda, CA 94501, USA<br>
                                                TEL：(510)865-2541<br>
                                                FAX：(510)865-2369<br>
                                                <a href="http://www.pacificyachtimports.net" target="_blank">www.pacificyachtimports.net</a></li>
                                        </ul>
                                    </div>
                                </li>
                                <li>
                                    <div class="list02">
                                        <ul>
                                            <li class="list02li">
                                                <div>
                                                    <img src="images/dealers003.jpg" alt="&quot;&quot;">
                                                </div>
                                            </li>
                                            <li><span>Seattle</span><br>
                                                Seattle Yachts<br>
                                                Contact：Ted Griffin<br>
                                                Address：Shilshole Bay Marina 7001 Seaview Ave NW, Suite 150 Seattle
                                                <br>
                                                WA 98117<br>
                                                TEL：(206.789.8044<br>
                                                FAX：(206.789.3976<br>
                                                Cell：(206.819.7137<br>
                                                E-mail：ted@seattleyachts.com<br>
                                                <a href="http://www.seattleyachts.com" target="_blank">www.seattleyachts.com</a><br>
                                            </li>
                                        </ul>
                                    </div>
                                </li>
                                <li>
                                    <div class="list02">
                                        <ul>
                                            <li class="list02li">
                                                <div>
                                                    <img src="images/dealers004.jpg" alt="&quot;&quot;">
                                                </div>
                                            </li>
                                            <li><span>Seattle</span><br>
                                                Seattle Yachts<br>
                                                Contact：Ted Griffin<br>
                                                Address：Shilshole Bay Marina 7001 Seaview Ave NW, Suite 150 Seattle
                                                <br>
                                                WA 98117<br>
                                                TEL：(206.789.8044<br>
                                                FAX：(206.789.3976<br>
                                                Cell：(206.819.7137<br>
                                                E-mail：ted@seattleyachts.com<br>
                                                <a href="http://www.seattleyachts.com" target="_blank">www.seattleyachts.com</a><br>
                                            </li>
                                        </ul>
                                    </div>
                                </li>--%>
                            </ul>
                            <%--                            <div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>--%>

                            <div class="pagenumber">
                                <asp:Repeater ID="Repeater5" runat="server">
                                    <ItemTemplate>
                                        <%# GenerateAnchorTags(TrimPage((int)Eval("Count"))) %>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="pagenumber1">
                                Items：
                                <asp:Repeater ID="Repeater6" runat="server">
                                    <ItemTemplate>
                                        <span>
                                            <%#Eval("totalCount")%>
                                        </span>
                                    </ItemTemplate>
                                </asp:Repeater>

                                |  Pages：
                                <asp:Repeater ID="Repeater7" runat="server">
                                    <ItemTemplate>
                                        <span>
                                            <%# $"{ (string.IsNullOrEmpty(Request.QueryString["page"]) ? "1" : Request.QueryString["page"]) }/{TrimPage((int)Eval("Count"))}" %>
                                        </span>
                                    </ItemTemplate>
                                </asp:Repeater>

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
