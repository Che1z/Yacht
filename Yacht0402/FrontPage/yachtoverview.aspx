<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="yachtoverview.aspx.cs" Inherits="Yacht0402.FrontPage.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
        <title>TtayanaWorld (DEMO)</title>

        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
        <script type="text/javascript" src="Scripts/jquery.ad-gallery.js"></script>
        <script type="text/javascript">
            $(function () {

                var galleries = $('.ad-gallery').adGallery();
                galleries[0].settings.effect = 'slide-hori';



            });
  </script>
        <script type="text/javascript">
            $(function () {
                $('.topbuttom').click(function () {
                    $('html, body').scrollTop(0);

                });
            });
  </script>
        <%--        <script type="text/javascript">
            $(document).ready(function () {
                $('.slideshow').cycle({
                    fx: 'fade' // choose your transition type, ex: fade, scrollUp, shuffle, etc...
                });
            });
        </script>
        <script type="text/javascript">
            $(function () {
                $('.topbuttom').click(function () {
                    $('html, body').scrollTop(0);

                });
            });
  </script>--%>
        <!--[if lt IE 7]>
<script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
<![endif]-->
        <link href="../CSS/Frontyachtoverview.css" rel="stylesheet" />
        <link href="css/homestyle.css" rel="stylesheet" type="text/css">
        <link href="css/reset.css" rel="stylesheet" type="text/css">
        <link href="css/style2.css" rel="stylesheet" type="text/css">
        <link href="css/overview.css" rel="stylesheet" type="text/css">
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
                <img src="images/banner01_masks.png" alt="&quot;&quot;">
            </div>
            <!--遮罩結束-->
            <div class="banner">
                <div id="gallery" class="ad-gallery">
                    <div class="ad-image-wrapper">
                        <div class="ad-image" style="width: 914.707px; height: 371px; top: 0px; left: 26px;">
                            <img src="images/test002.jpg" width="914.7068965517242" height="371">
                        </div>
                        <img class="ad-loader" src="images/loader.gif" style="display: none;"><div class="ad-next">
                            <div class="ad-next-image" style="opacity: 0.7;"></div>
                        </div>
                        <div class="ad-prev">
                            <div class="ad-prev-image" style="opacity: 0.7;"></div>
                        </div>
                    </div>
                    <div class="ad-controls" style="display: none">
                        <p class="ad-info">6 / 11</p>
                        <div class="ad-slideshow-controls"><span class="ad-slideshow-start">Start</span><span class="ad-slideshow-stop">Stop</span><span class="ad-slideshow-countdown" style="display: none;">(1)</span></div>
                    </div>
                    <div class="ad-nav">
                        <div class="ad-back" style="opacity: 0.6;"></div>
                        <div class="ad-thumbs">
                            <ul class="ad-thumb-list" style="width: 1221px;">
                                <%--                                                                <li>
                                    <a href="images/dealers003.jpg" class="ad-thumb0">
                                        <img src="images/test1.jpg" style="width: 103px; height: 63px; opacity: 0.7;">
                                    </a>
                                </li>
                                <li>
                                    <a href="images/test002.jpg" class="ad-thumb0">
                                        <img src="images/test002.jpg" style="width: 103px; height: 63px; opacity: 0.7;">
                                    </a>
                                </li>--%>
                                <asp:Repeater ID="Repeater5" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%#Eval("imgPath ")%>' class="ad-thumb1">
                                                <img src='<%#Eval("imgPath ")%>' style="opacity: 0.7; width: 103px; height: 63px;">
                                            </a>
                                        </li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="ad-forward" style="opacity: 0.6;"></div>
                    </div>
                </div>
            </div>


            <!--小圖開始-->

            <!--小圖結束-->




            <!--------------------------------換圖開始---------------------------------------------------->


            <!--------------------------------換圖結束---------------------------------------------------->




            <div class="conbg">
                <!--------------------------------左邊選單開始---------------------------------------------------->
                <div class="left">

                    <div class="left1">
                        <p><span>YACHTS</span></p>
                        <ul>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <li><a href='<%# $"?model={Eval("Id")}" %>'>
                                        <%#Eval("yachtName ")%>
                                        <%# IsNewDesignText(Eval("isNewDesign").ToString()) %>
                                        <%# IsNewBuildingText(Eval("isNewBuilding").ToString()) %>
                                    </a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <%--                            <li><a href="#">Dynasty 72</a></li>
                            <li><a href="#">Tayana 64</a></li>
                            <li><a href="#">Tayana 58</a></li>
                            <li><a href="#">Tayana 55</a></li>--%>
                        </ul>



                    </div>




                </div>







                <!--------------------------------左邊選單結束---------------------------------------------------->

                <!--------------------------------右邊選單開始---------------------------------------------------->
                <div id="crumb">
                    <a href="#">Home</a> &gt;&gt; <a href="#">Yachts</a> &gt;&gt; <a href="#">
                        <span class="on1">
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </span>

                    </a>
                </div>
                <div class="right">
                    <div class="right1">
                        <div class="title">
                            <span>

                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

                            </span>
                        </div>

                        <!--------------------------
                            ------內容開始---------------------------------------------------->

                        <!--次選單-->
                        <div class="menu_y">
                            <ul>
                                <li class="menu_y00">
                                    <img src="images/menu_y1_03.jpg" />
                                    YACHTS</li>
                                <li>
                                    <asp:HyperLink ID="HyperLink2" runat="server">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="images/menu_y1_04.jpg" />
                                    </asp:HyperLink>
                                    <%--                                    <a class="menu_yli01" href="yachtoverview.aspx">
                                        <img src="images/menu_y1_04.jpg" />
                                        Interior
                                    </a>--%>
                                </li>
                                <li>
                                    <%--                                    <a class="menu_yli02" href="yachtLayout.aspx">
                                    <img src="images/menu_y1_05.jpg" />
                                    Layout &amp; deck pla</a>n--%>
                                    <asp:HyperLink ID="HyperLink1" runat="server">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="images/menu_y1_05.jpg" />
                                    </asp:HyperLink>



                                </li>
                                <li>
                                    <asp:HyperLink ID="HyperLink3" runat="server">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="images/menu_y1_06.jpg" />
                                    </asp:HyperLink>

                                    <%--                                    <a class="menu_yli03" href="#">
                                        <img src="images/menu_y1_06.jpg" />
                                        Specification</a>--%>

                                </li>
                            </ul>
                        </div>
                        <!--次選單-->

                        <div class="box1">
                            <%--                            With the world renowned pedigree combination of Ta Yang Yacht Builders, Andrew Winch Designs, and Bill Dixon Naval Architects, the Tayana Dynasty 72 ranks as an exceptional high performance cruising yacht. Space abounds in the Dynasty 72, with two spacious cockpits and a sunbathing area on the deck. The central cockpit houses twin steering positions with outdoor dining for eight and access forward into the pilothouse. All control and command equipment is readily available for minimal crew handling. The aft cockpit is accessed from the large owner's cabin and provides a pleasant seating area which opens out through a drop-down transom to the bathing platform. The Dynasty is very much a semi-custom yacht. The interior styling, furniture, and fabrics will reflect the owner's ideals and will blend with an extensive range of high quality fittings and equipment. The technical specification of the yacht will be to a very high standard. Three interior styles have been developed by Andrew Winch. Two owner versions each have four staterooms but different positions for the galley; a charter version has six double cabins with en suite heads. All versions have separate crew quarters, and all versions have the magnificent split level pilot house connecting the forward and aft lower accommodation levels. Custom interiors are available to fit the needs of you and your crew. Ta Yang has been constructing first class yachts for many years. The reputation of Chinese craftsmen over thousands of years is renowned, and it is the combination of their skills with modern design and naval architecture that has created the Tayana Dynasty 72.<br>
                            <br>--%>
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        </div>

                        <div class="box3">
                            <h4>PRINCIPAL DIMENSION</h4>
                            <table class="table02">
                                <tbody>
                                    <tr>
                                        <td class="table02td01">
                                            <table>
                                                <tbody>
                                                    <asp:Repeater ID="Repeater2" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <th><%# Eval("Name") %></th>
                                                                <td><%# Eval("Value") %></td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td>
                                            <asp:Repeater ID="Repeater3" runat="server">
                                                <ItemTemplate>
                                                    <img src='<%# Eval("DimensionImgPath") %>' alt="Not uploaded!!" width="278" height="345">
                                                </ItemTemplate>

                                            </asp:Repeater>
                                        </td>
                                        <%--                                        <td>
                                            <img src="images/ya01.jpg" alt="&quot;&quot;" width="278" height="345">
                                        </td>--%>
                                    </tr>
                                </tbody>
                            </table>


                        </div>
                        <p class="topbuttom">
                            <img src="images/top.gif" alt="top">
                        </p>

                        <!--下載開始-->
                        <div class="downloads">
                            <p>
                                <img src="images/downloads.gif" alt="&quot;&quot;">
                            </p>
                            <ul>
                                <asp:Repeater ID="Repeater4" runat="server">
                                    <ItemTemplate>
                                        <li><a href='<%# Eval("downloadFilePath") %>' download='<%# Eval("downloadFileName") %>'><%# Eval("downloadFileName") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--                                <li><a href="#">Downloads 001</a></li>
                                <li><a href="#">Downloads 001</a></li>
                                <li><a href="#">Downloads 001</a></li>
                                <li><a href="#">Downloads 001</a></li>
                                <li><a href="#">Downloads 001</a></li>--%>
                            </ul>
                        </div>
                        <!--下載結束-->


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
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
</asp:Content>
