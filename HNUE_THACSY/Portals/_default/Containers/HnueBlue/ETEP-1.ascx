<%@ Control AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<div class="etep-1">
    <div class='container-header'>
    	<h2><dnn:TITLE runat="server" id="dnnTITLE" CssClass="title" /></h2>
    </div>
    <div class='container-content'>
    	<div id="ContentPane" runat="server"></div>
    </div>
</div>
