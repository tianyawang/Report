<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<ReportModel.TrafficeFlowReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        车流量录入</h2>
    <hr />
    <%using (Html.BeginForm("TrafficReport", "report", FormMethod.Post))
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
            日下道车流量</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.DownAmount,new{@class="inp2" }) %>
            <%: Html.ValidationMessageFor(m => m.DownAmount)%></div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            货车总量</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.TruckAmount ,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.TruckAmount)%></div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            超载30%-100%</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.MoreThan30,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.MoreThan30)%></div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            超载100%</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.MoreThan100,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.MoreThan100)%></div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            工程车</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.EngineeringVehicles,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.EngineeringVehicles)%></div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            绿色通道</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.EasyAccess,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.EasyAccess)%></div>
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
