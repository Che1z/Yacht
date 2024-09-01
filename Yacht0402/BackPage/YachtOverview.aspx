<%@ Page Title="" Language="C#" MasterPageFile="~/Back.Master" AutoEventWireup="true" CodeBehind="YachtOverview.aspx.cs" Inherits="Yacht0402.BackPage.YachtOverview" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS/backshreerang.css" rel="stylesheet" />
    <link href="../CSS/backboostrap.css?v=1" rel="stylesheet" />
    <div id="layout-sidenav" class="layout-sidenav sidenav sidenav-vertical bg-dark">
        <!-- Brand demo (see assets/css/demo/demo.css) -->
        <div class="app-brand demo">
            <span class="app-brand-logo demo">
                <img src="../FrontPage/images/yacht.png" alt="Yacht Logo" class="img-fluid mt-2" style="width: 50px; height: 40px;">
            </span>
            <a href="#" class="app-brand-text demo sidenav-text font-weight-normal ml-3 mt-2">Yacht Admin</a>
            <a href="javascript:" class="layout-sidenav-toggle sidenav-link text-large ml-auto">
                <i class="ion ion-md-menu align-middle"></i>
            </a>
        </div>

        <!-- Links -->
        <ul class="sidenav-inner">

            <%--                    <!-- Dashboards -->
                    <li class="sidenav-item active">
                        <a href="index.html" class="sidenav-link">
                            <i class="sidenav-icon feather icon-home"></i>
                            <div>Dashboards</div>
                            <div class="pl-1 ml-auto">
                                <div class="badge badge-danger">Hot</div>
                            </div>
                        </a>
                    </li>--%>

            <!-- Layouts -->
            <li class="sidenav-divider mb-1"></li>
            <li class="sidenav-header small font-weight-semibold">Yachts Page</li>
            <li class="sidenav-item">
                <a href="YachtModel.aspx" class="sidenav-link">
                    <i class="sidenav-icon feather icon-type"></i>
                    <div>Yacht Model</div>
                </a>
            </li>

            <!-- UI elements -->
            <li class="sidenav-item">
                <a href="YachtOverview.aspx" class="sidenav-link">
                    <i class="sidenav-icon feather icon-box"></i>
                    <div>Overview</div>
                </a>
                <ul class="sidenav-menu">
                    <li class="sidenav-item">
                        <a href="bui_alert.html" class="sidenav-link">
                            <div>Alerts</div>
                        </a>
                    </li>
                    <li class="sidenav-item">
                        <a href="bui_badges.html" class="sidenav-link">
                            <div>Badges</div>
                        </a>
                    </li>
                    <li class="sidenav-item">
                        <a href="bui_button.html" class="sidenav-link">
                            <div>Buttons</div>
                        </a>
                    </li>
                    <li class="sidenav-item">
                        <a href="charts_morrisjs.html" class="sidenav-link">
                            <div>Charts</div>
                        </a>
                    </li>
                    <li class="sidenav-item">
                        <a href="bui_dropdowns.html" class="sidenav-link">
                            <div>Dropdowns</div>
                        </a>
                    </li>
                    <li class="sidenav-item">
                        <a href="bui_pagination.html" class="sidenav-link">
                            <div>Pagination and breadcrumbs</div>
                        </a>
                    </li>
                    <li class="sidenav-item">
                        <a href="bui_progress.html" class="sidenav-link">
                            <div>Progress bars</div>
                        </a>
                    </li>

                </ul>
            </li>

            <!-- Forms & Tables -->
            <li class="sidenav-divider mb-1"></li>
            <li class="sidenav-header small font-weight-semibold">News Pages</li>
            <li class="sidenav-item">
                <a href="NewsList.aspx" class="sidenav-link ">
                    <i class="sidenav-icon feather icon-clipboard"></i>
                    <div>List</div>
                </a>
                <ul class="sidenav-menu">
                    <li class="sidenav-item">
                        <a href="forms_layouts.html" class="sidenav-link">
                            <div>Layouts and elements</div>
                        </a>
                    </li>
                    <li class="sidenav-item">
                        <a href="forms_input-groups.html" class="sidenav-link">
                            <div>Input groups</div>
                        </a>
                    </li>
                </ul>
            </li>
            <li class="sidenav-item">
                <a href="NewsContents.aspx" class="sidenav-link">
                    <i class="sidenav-icon feather icon-grid"></i>
                    <div>Contents</div>
                </a>
            </li>



            <!--  Icons -->
            <li class="sidenav-divider mb-1"></li>
            <li class="sidenav-header small font-weight-semibold">Company Pages</li>
            <li class="sidenav-item">
                <a href="../FrontPage/BackCompanyAboutus.aspx" class="sidenav-link ">
                    <i class="sidenav-icon feather icon-feather"></i>
                    <div>About Us</div>
                </a>
                <ul class="sidenav-menu">
                    <li class="sidenav-item">
                        <a href="#" class="sidenav-link">
                            <div>Feather</div>
                        </a>
                    </li>
                </ul>
                <a href="../FrontPage/BackCompanyCertificat.aspx" class="sidenav-link ">
                    <i class="sidenav-icon feather icon-feather"></i>
                    <div>Certificate</div>
                </a>
            </li>

            <!--  Icons -->
            <li class="sidenav-divider mb-1"></li>
            <li class="sidenav-header small font-weight-semibold">Dealers</li>
            <li class="sidenav-item">
                <a href="DealerArea.aspx" class="sidenav-link ">
                    <i class="sidenav-icon feather icon-feather"></i>
                    <div>Area</div>
                </a>
                <a href="Dealer.aspx" class="sidenav-link ">
                    <i class="sidenav-icon feather icon-feather"></i>
                    <div>Contact Info</div>
                </a>
                <a href="DealerNumber.aspx" class="sidenav-link ">
                    <i class="sidenav-icon feather icon-feather"></i>
                    <div>Number</div>
                </a>
                <a href="DealerPhoto.aspx" class="sidenav-link ">
                    <i class="sidenav-icon feather icon-feather"></i>
                    <div>Photo</div>
                </a>
                <ul class="sidenav-menu">
                    <li class="sidenav-item">
                        <a href="#" class="sidenav-link">
                            <div>Feather</div>
                        </a>
                    </li>
                </ul>
            </li>

            <!--  Icons -->
            <li class="sidenav-divider mb-1"></li>
            <li class="sidenav-header small font-weight-semibold">Front Pages</li>
            <li class="sidenav-item">
                <a href="../FrontPage/MainPage.aspx" class="sidenav-link ">
                    <i class="sidenav-icon feather icon-feather"></i>
                    <div>Main Pages</div>
                </a>
                <ul class="sidenav-menu">
                    <li class="sidenav-item">
                        <a href="#" class="sidenav-link">
                            <div>Feather</div>
                        </a>
                    </li>
                </ul>
            </li>

            <!-- Pages -->
            <li class="sidenav-divider mb-1"></li>
            <li class="sidenav-header small font-weight-semibold">Others</li>

           <li class="sidenav-item">
                <a href="LogOut.aspx" class="sidenav-link">
                    <i class="sidenav-icon feather icon-user"></i>
                    <div>Log Out</div>
                </a>
            </li>

            <div class="ps__rail-x" style="left: 0px; bottom: 0px;">
                <div class="ps__thumb-x" tabindex="0" style="left: 0px; width: 0px;"></div>
            </div>
            <div class="ps__rail-y" style="top: 0px; right: 4px; height: 493px;">
                <div class="ps__thumb-y" tabindex="0" style="top: 0px; height: 354px;"></div>
            </div>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <nav class="layout-navbar navbar navbar-expand-lg align-items-lg-center bg-white container-p-x" id="layout-navbar">

        <!-- Brand demo (see assets/css/demo/demo.css) -->
        <a href="index.html" class="navbar-brand app-brand demo d-lg-none py-0 mr-4">
            <span class="app-brand-logo demo">
                <img src="assets/img/logo-dark.png" alt="Brand Logo" class="img-fluid">
            </span>
            <span class="app-brand-text demo font-weight-normal ml-2">Bhumlu</span>
        </a>

        <!-- Sidenav toggle (see assets/css/demo/demo.css) -->
        <div class="layout-sidenav-toggle navbar-nav d-lg-none align-items-lg-center mr-auto">
            <a class="nav-item nav-link px-0 mr-lg-4" href="javascript:">
                <i class="ion ion-md-menu text-large align-middle"></i>
            </a>
        </div>

        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#layout-navbar-collapse">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="navbar-collapse collapse" id="layout-navbar-collapse">
            <!-- Divider -->
            <hr class="d-lg-none w-100 my-2">

            <div class="navbar-nav align-items-lg-center">
                <!-- Search -->
                <label class="nav-item navbar-text navbar-search-box p-0 active">
                    <i class="feather icon-search navbar-icon align-middle"></i>
                    <span class="navbar-search-input pl-2"></span>
                </label>
            </div>

            <div class="navbar-nav align-items-lg-center ml-auto">

                <!-- Divider -->
                <div class="nav-item d-none d-lg-block text-big font-weight-light line-height-1 opacity-25 mr-3 ml-1">|</div>
                <div class="demo-navbar-user nav-item dropdown">
                    <a class="nav-link " href="#" data-toggle="dropdown">
                        <span class="d-inline-flex flex-lg-row-reverse align-items-center align-middle">
                            <img src="assets/img/avatars/1.png" alt="" class="d-block ui-w-30 rounded-circle">
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </span>
                    </a>
                    <div class="dropdown-menu dropdown-menu-right">
                        <a href="javascript:" class="dropdown-item">
                            <i class="feather icon-user text-muted"></i>&nbsp; My profile</a>
                        <a href="javascript:" class="dropdown-item">
                            <i class="feather icon-mail text-muted"></i>&nbsp; Messages</a>
                        <a href="javascript:" class="dropdown-item">
                            <i class="feather icon-settings text-muted"></i>&nbsp; Account settings</a>
                        <div class="dropdown-divider"></div>
                        <a href="javascript:" class="dropdown-item">
                            <i class="feather icon-power text-danger"></i>&nbsp; Log Out</a>
                    </div>
                </div>
            </div>
        </div>
    </nav>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="d-flex ml-3 mt-3 ">
        <asp:Label CssClass="mt-2" ID="Label1" runat="server" Text="選擇Model:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ml-2 btn btn-default dropdown-toggle waves-effect" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    </div>
    <asp:Panel ID="Panel1" runat="server" CssClass="ml-3 mt-4">
        <div class="d-flex">
            <asp:Button ID="Button1" runat="server" Text="前往Dimension" CssClass="btn btn-secondary" />
            <asp:Button ID="Button2" runat="server" Text="前往Album" CssClass="ml-3 btn btn-secondary" />
            <asp:Button ID="Button3" runat="server" Text="前往Layout" CssClass="ml-3 btn btn-secondary" />
            <asp:Button ID="Button7" runat="server" Text="前往Specification" CssClass="ml-3 btn btn-secondary" />
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="mt-3 ml-3">
        <div>
            <asp:Label Text="Download:" runat="server" />
            <div class="mt-2 d-flex">
                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
                <asp:Button ID="Button4" runat="server" Text="上傳檔案" CssClass="btn btn-secondary" OnClick="Button4_Click" />
            </div>
        </div>
        <div style="width: 1149px; height: 281px" class="mt-2">
            <asp:Label Text="Content: " runat="server" CssClass="mt-3 " />
            <div class="mt-2">
                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/Scripts/ckeditor/"></CKEditor:CKEditorControl>
                <div class="text-center mt-2">
                    <asp:Button ID="Button5" runat="server" Text="儲存內容" CssClass="btn btn-info" Width="50%" OnClick="Button5_Click" />
                </div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
