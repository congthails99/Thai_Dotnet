<%@ Control Language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="META" Src="~/Admin/Skins/Meta.ascx" %>
<%@ Register TagPrefix="dnn" TagName="MENU" Src="~/DesktopModules/DDRMenu/Menu.ascx" %>
<dnn:META ID="META1" runat="server" Name="viewport" Content="width=device-width,initial-scale=1" />
<link href="<%= SkinPath %>/css/bootstrap.min.css" rel="stylesheet" />
<link href="<%= SkinPath %>/css/bootstrap-grid.min.css" rel="stylesheet" />
<link href="<%= SkinPath %>/css/bootstrap-reboot.min.css" rel="stylesheet" />

<div class="banner">
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <dnn:LOGO runat="server" ID="dnnLOGO" cssClass="logo" />
            </div>
            <div class="col-md-4 text-right">
                <dnn:LOGIN ID="dnnLogin" CssClass="LoginLink" runat="server" LegacyMode="false" />
                <div class="search">
                    <dnn:SEARCH ID="dnnSearch" runat="server" ShowSite="false" ShowWeb="false" EnableTheming="true" Submit="Search" CssClass="SearchButton"></dnn:SEARCH>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="main-nav">
    <div class="container">
        <dnn:MENU ID="MENU" MenuStyle="Menus/MainMenu" runat="server" NodeSelector="*"></dnn:MENU>
    </div>
</div>
<div class='contentpane'>
    <div class='container'>
        <div id="ContentPane" runat="server"></div>
    </div>
</div>
<div class="footer">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <dnn:LOGO runat="server" ID="footerLOGO" cssClass="logo" />
                <p>Khoa Triết học luôn phát triển năng động, luôn sẵn sàng thử nghiệm và áp dụng các mô hình đào tạo tiên tiến trên thế giới...</p>
            </div>
            <div class="col-md-5">
                <h5>Liên hệ</h5>
                <p>Địa chỉ: Tầng 3 Nhà B - 136 Xuân Thuỷ - Cầu Giấy - Hà Nội</p>
                <p>Điện thoại: 0248.587.6474</p>
                <p>Email: k.triethoc@hnue.edu.vn</p>
                <p>Website: http://triethoc.hnue.edu.vn/</p>
            </div>
            <div class="col-md-3">
                <h5>Thống kê truy cập</h5>
                <div id="Footer" runat="server"></div>
                <hr/>
                <p>Phụ trách kỹ thuật & thiết kế web: 0965.246.968</p>
            </div>
        </div>
    </div>
</div>
<div class="copyright text-center">
    <dnn:COPYRIGHT ID="dnnCopyright" runat="server" CssClass="" />
</div>

<script src="<%= SkinPath %>/js/bootstrap.min.js"></script>
<script src="<%= SkinPath %>/js/bootstrap.bundle.min.js"></script>
<link href="https://fonts.googleapis.com/css?family=Oswald:400&amp;subset=vietnamese" rel="stylesheet">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
