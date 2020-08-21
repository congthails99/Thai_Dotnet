<%@ Control AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="etep-3">
    <h2><dnn:TITLE runat="server" id="dnnTITLE" CssClass="title" /></h2>
    <div id="ContentPane" runat="server"></div>
</div>
