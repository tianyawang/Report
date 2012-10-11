<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>添加收费站</h2>
    <hr />
        <%using (Html.BeginForm("add", "station", FormMethod.Post))
      { %>
    <div class="item">
    	<div class="title">收费站</div>
        <div class="content"><input type="text" name="stationname" /></div>
        <div class="clear"></div>
    </div>
    <div class="item">
        <div class="title">
            &nbsp;</div>
        <div class="content">
            <input type="submit" value="添加" /></div>
        <div class="clear">
        </div>
    </div>
    <%} %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
