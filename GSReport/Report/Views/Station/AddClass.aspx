<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>添加收费班</h2>
    <hr />
        <%using (Html.BeginForm("AddClass", "station", FormMethod.Post))
      { %>
      <input type="hidden" name="id" value="<%=ViewBag.StationID %>" />
    <div class="item">
    	<div class="title">收费班</div>
        <div class="content"><input type="text" name="classname" /></div>
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
