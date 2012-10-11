<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<ReportModel.NewUserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <h2>添加用户</h2>
    <hr />
        <%using (Html.BeginForm("add", "user", FormMethod.Post))
      { %>
    <div class="item">
    	<div class="title">用户名</div>
        <div class="content"><%=Html.TextBoxFor(m=>m.UserName,new{@class="inp2"} )%></div>
        <div class="clear"></div>
    </div>
    <div class="item">
    	<div class="title">密码</div>
        <div class="content"><%=Html.TextBoxFor(m=>m.Password,new{@class="inp2"} )%></div>
        <div class="clear"></div>
    </div>
    <div class="item">
    	<div class="title">所属站</div>
        <div class="content">
            <select name="CollectionClassID" >
                <option value=0>收费科</option>
                <%foreach (var item in (IList<ReportModel.StationModel>)ViewBag.Stations)
                  { %>
                    <option value="<%=item.StationID %>"><%=item.StationName%></option>
                <%} %>
            </select>
        </div>
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
