<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="yachtLayout.aspx.cs" Inherits="Yacht0402.FrontPage.yachtLayout" %>

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

        <link href="../CSS/Frontyachtoverview.css" rel="stylesheet" />
        <link href="css/homestyle.css" rel="stylesheet" type="text/css">
        <link href="css/reset.css" rel="stylesheet" type="text/css">
        <link href="css/overview.css" rel="stylesheet" type="text/css">

        <link href="css/style2.css" rel="stylesheet" type="text/css">
    </head>

    <body>
        <div class="contain">
            <div class="sub">
                <p><a href="#">Home</a></p>
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
                                <asp:Repeater ID="Repeater5" runat="server" >
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%#Eval("imgPath ")%>'  class="ad-thumb1">
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
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <li><a href='<%# $"?model={Eval("Id")}" %>'>
                                        <%#Eval("yachtName ")%>
                                        <%# IsNewDesignText(Eval("isNewDesign").ToString()) %>
                                        <%# IsNewBuildingText(Eval("isNewBuilding").ToString()) %>
                                    </a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>



                    </div>




                </div>







                <!--------------------------------左邊選單結束---------------------------------------------------->

                <!--------------------------------右邊選單開始---------------------------------------------------->
                <div id="crumb">
                    <a href="MainPage.aspx">Home</a> &gt;&gt; <a href="#">Yachts</a> &gt;&gt; <a href="#">
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

                        <!--------------------------------內容開始---------------------------------------------------->

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

                        <div class="box6">
                            <p>Layout &amp; deck plan</p>
                            <ul>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <img style="max-width: 660px; max-height: 500px;" src='<%#Eval("imgPath")%>' alt="file no find..">
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--                                <li>
                                    <img src="images/deckplan01.jpg" alt="&quot;&quot;"></li>
                                <li>
                                    <img src="images/deckplan01.jpg" alt="&quot;&quot;"></li>--%>
                            </ul>
                        </div>


                        <div class="clear"></div>
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

        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>

    </body>
    </html>
</asp:Content>
