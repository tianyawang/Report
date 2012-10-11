<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<ReportModel.ShortOverReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        长短款录入</h2>
    <hr />
    <%using (Html.BeginForm("ShortOver", "report", FormMethod.Post))
      { %>
    <div class="item">
        <div class="title">
            日期</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.ReportDate,new{@class="inp2"} )%>
            <%: Html.ValidationMessageFor(m => m.ReportDate)%>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            长短款次数</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.ShortOverTimes,new{@class="inp2" }) %>
            <%: Html.ValidationMessageFor(m => m.ShortOverTimes)%></div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            收费次数</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.ChargeTimes,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.ChargeTimes)%></div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            金额</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.ShortOverAmount,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.ShortOverAmount)%></div>
        <div class="clear">
        </div>
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
    <script>
        $(document).ready(function () {
            $("#ReportDate").datepicker({ dateFormat: 'yy-mm-dd' });
        }) 
    </script>
</asp:Content>
