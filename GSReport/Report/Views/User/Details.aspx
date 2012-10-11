<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<ReportModel.UserModel>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <h2>用户管理</h2>
    <hr />
        <%using (Html.BeginForm("update", "user", FormMethod.Post))
      { %>
            <%=Html.HiddenFor(m=>m.UserID) %>

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
    	<div class="title">所属班</div>
        <div class="content">
            <select name="stationid" >
                <option value=0>收费科</option>
                <%foreach (var item in (IList<ReportModel.StationModel>)ViewBag.Stations)
                  { %>
                    <option value="<%=item.StationID %>" <%if (item.StationID==Model.StationID){ %>selected="selected"<%} %> ><%=item.StationName%></option>
                <%} %>
            </select>
        </div>
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

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
