<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<ReportModel.StationModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>修改收费站</h2>
    <hr />
        <%using (Html.BeginForm("update", "station", FormMethod.Post))
      { %>
      <input type="hidden" name="id" value="<%=Model.StationID %>" />
    <div class="item">
    	<div class="title">收费站</div>
        <div class="content"><%=Html.TextBoxFor(m=>m.StationName) %></div>
        <div class="clear"></div>
    </div>
    <div class="item">
        <div class="title">
            &nbsp;</div>
        <div class="content">
            <input type="submit" value="修改" /></div>
        <div class="clear">
        </div>
    </div>
    <%} %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
