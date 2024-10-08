﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Yacht0402.FrontPage.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
        <title>TtayanaWorld (DEMO)</title>
        <script type="text/javascript" src="Scripts/jquery.min.js"></script>
        <script type="text/javascript" src="Scripts/jquery.cycle.all.2.74.js"></script>
        <script type="text/javascript">
            $(function () {

                // 先取得 #abgne-block-20110111 , 必要參數及輪播間隔
                var $block = $('#abgne-block-20110111'),
                    timrt, speed = 4000;


                // 幫 #abgne-block-20110111 .title ul li 加上 hover() 事件
                var $li = $('.title ul li', $block).hover(function () {
                    // 當滑鼠移上時加上 .over 樣式
                    $(this).addClass('over').siblings('.over').removeClass('over');
                }, function () {
                    // 當滑鼠移出時移除 .over 樣式
                    $(this).removeClass('over');
                }).click(function () {
                    // 當滑鼠點擊時, 顯示相對應的 div.info
                    // 並加上 .on 樣式

                    $(this).addClass('on').siblings('.on').removeClass('on');
                    $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().hide().eq($(this).index()).fadeIn(1000);
                });

                // 幫 $block 加上 hover() 事件
                $block.hover(function () {
                    // 當滑鼠移上時停止計時器
                    clearTimeout(timer);
                }, function () {
                    // 當滑鼠移出時啟動計時器
                    timer = setTimeout(move, speed);
                });

                // 控制輪播
                function move() {
                    var _index = $('.title ul li.on', $block).index();
                    _index = (_index + 1) % $li.length;
                    $li.eq(_index).click();

                    timer = setTimeout(move, speed);
                }

                // 啟動計時器
                timer = setTimeout(move, speed);

            });


        </script>
        <!--[if lt IE 7]>
<script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
<![endif]-->
        <link href="css/style.css?v=1" rel="stylesheet" type="text/css">
        <link href="css/reset.css" rel="stylesheet" type="text/css">
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
                <img src="images/banner00_masks.png" alt="&quot;&quot;">
            </div>
            <!--遮罩結束-->








            <!--------------------------------換圖開始---------------------------------------------------->
            <div id="abgne-block-20110111">
                <div class="bd">
                    <div class="banner">
                        <ul>
                            <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound" Visible="true">
                                <ItemTemplate>
                                    <%--                                    <li class="info" style="display:list-item">--%>
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                    <a href="#">
                                        <img src='<%#Eval("imgPath")%>' style="width: 966px; height: 363px">
                                    </a>
                                    &nbsp;&nbsp;<div class="wordtitle">
                                        <%#FirstModelName(Eval("yachtName").ToString())%>
                                        <span>
                                            <%#RestModelName(Eval("yachtName").ToString())%>
                                        </span>
                                        <br />
                                        <p>SPECIFICATION SHEET</p>
                                    </div>
                                    <div class="new">
                                        <img src="<%#isNewBuilding(Eval("isNewBuilding").ToString())%>">
                                        <img src="<%#isNewDesign(Eval("isNewDesign").ToString())%>">
                                    </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>


                            <%--                            <li class="info" style="display: list-item;"><a href="#">
                                <img src="images/banner002b.jpg"></a><!--文字開始--><div class="wordtitle">
                                    TAYANA <span>54</span><br>
                                    <p>SPECIFICATION SHEET</p>
                                </div>
                                <!--文字結束-->
                                <!--新船型開始  54型才出現其於隱藏 -->
                                <div class="new">
                                    <img src="images/new01.png" alt="new">
                                </div>
                                <!--新船型結束-->
                            </li>
                            <li class="info" style="display: none;"><a href="#">
                                <img src="images/banner003b.jpg"></a><!--文字開始--><div class="wordtitle">
                                    TAYANA <span>37</span><br>
                                    <p>SPECIFICATION SHEET</p>
                                </div>
                                <div class="new">
                                    <img src="">
                                </div>
                                <!--文字結束-->
                            </li>--%>
                        </ul>


                        <!--小圖開始-->
                        <div class="bannerimg title">
                            <ul>
                                <asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                        <div>
                                            <p class="bannerimg_p">
                                                <img src='<%#Eval("imgPath")%>' alt="Path error" style="width: 101px; height: 59px">
                                            </p>
                                        </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <%--                                <li class="on">
                                    <div>
                                        <p class="bannerimg_p">
                                            <img src="images/i002.jpg" alt="&quot;&quot;">
                                        </p>
                                    </div>
                                </li>
                                <li>
                                    <div>
                                        <p class="bannerimg_p">
                                            <img src="images/i006.jpg" alt="&quot;&quot;">
                                        </p>
                                    </div>
                                </li>--%>
                            </ul>
                        </div>
                        <!--小圖結束-->
                    </div>
                </div>
            </div>
            <!--------------------------------換圖結束---------------------------------------------------->


            <!--------------------------------最新消息---------------------------------------------------->
            <div class="news">
                <div class="newstitle">
                    <p class="newstitlep1">
                        <img src="images/news.gif" alt="news">
                    </p>
                    <p class="newstitlep2"><a href="yachtoverview.aspx">More&gt;&gt;</a></p>
                </div>

                <ul>
                    <%--                    images/new_top01.png--%>

                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="news02">
                                    <!--TOP標籤-->
                                    <div class="newstop">
                                        <img src="<%#isPinTop(Eval("PinTop").ToString())%>" alt="">
                                    </div>
                                    <!--TOP標籤結束-->
                                    <div class="news02p1">
                                        <p class="news02p1img">
                                            <img src='<%#Eval("imgPath")%>' alt="No Cover" style="width: 100px; height: 100px;">
                                        </p>
                                    </div>
                                    <p class="news02p2">
                                        <span>
                                            <a href='<%#"newsContents?contents=" + Eval("Id")%>'><%#Eval("Title")%></a>
                                        </span>
                                        <span>
                                            <%#Eval("Description ")%>
                                        </span>
                                    </p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                    <!--TOP第一則最新消息-->
                    <%--                    <li>

                        <div class="news01">
                            <!--TOP標籤-->
                            <div class="newstop">
                                <img src="images/new_top01.png" alt="&quot;&quot;"></div>
                            <!--TOP標籤結束-->
                            <div class="news02p1">
                                <p class="news02p1img">
                                    <img src="images/pit002.jpg" alt="&quot;&quot;"></p>
                            </div>
                            <p class="news02p2"><span>Tayana 54 CE Certifica..</span> <a href="#">For Tayana 54 entering the EU, CE Certificates are AVAILABLE to ensure conformity to all applicable European ...</a></p>
                        </div>
                    </li>
                    <!--TOP第一則最新消息結束-->

                    <!--第二則-->
                    <li>

                        <div class="news01">
                            <!--TOP標籤-->
                            <div class="newstop">
                                <img src="images/new_top01.png" alt="&quot;&quot;"></div>
                            <!--TOP標籤結束-->
                            <div class="news02p1">
                                <p class="news02p1img">
                                    <img src="images/pit001.jpg" alt="&quot;&quot;"></p>
                            </div>
                            <p class="news02p2">
                                <span>Tayana 58 CE Certifica..</span>
                                <a href="#">For Tayana 58 entering the EU, CE Certificates are AVAILABLE to ensure conformity to all applicable European ...</a>
                            </p>
                        </div>
                    </li>
                    <!--第二則結束-->

                    <li>
                        <div class="news02">
                            <!--TOP標籤-->
                            <div class="newstop">
                                <img src="images/new_top01.png" alt="&quot;&quot;"></div>
                            <!--TOP標籤結束-->
                            <div class="news02p1">
                                <p class="news02p1img">
                                    <img src="images/pit001.jpg" alt="&quot;&quot;"></p>
                            </div>
                            <p class="news02p2">
                                <span>Big Cruiser in a Small ..</span>
                                <a href="#">Tayana 37 is our classical product and full of skilful craftsmanship. We only plan to build TWO units in a year.</a>
                            </p>
                        </div>
                    </li>--%>
                </ul>
            </div>
            <!--------------------------------最新消息結束---------------------------------------------------->



            <!--------------------------------落款開始---------------------------------------------------->
            <div class="footer">

                <div class="footerp00">
                    <a href="#">
                        <img src="images/tog.jpg" alt="&quot;&quot;"></a>
                    <p class="footerp001">© 1973-2011 Tayana Yachts, Inc. All Rights Reserved</p>
                </div>
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
