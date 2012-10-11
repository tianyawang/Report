<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>收费科报表</h2>
<%BLReport.BLReports blreports = new BLReport.BLReports(); %>
<div class="item">
    <h2>日收费统计</h2>
    <div class="table">
    <table>
        <tr>
            <th>日期</th>
            <th>日不拆账收费额</th>
            <th>绿通免费额</th>
            <th>绿通所占比率</th>
        </tr>
        <%foreach (var item in blreports.ListDailyReports())
          { %>
           <tr>
            <td><%=item.ReportDate %><%=item.StationName %></td>
            <td><%=item.Amount %></td>
            <td><%=item.EasyAccessAmount %></td>
            <td><%=item.EasyPercent %></td>
        </tr>
        <%} %>
    </table>
    </div>

</div>
<div class="item">
    <h2>月收费统计</h2>
    <div class="table">
    <table>
        <tr><td colspan="3"><%=DateTime.Now.ToString("yyyy年MM月") %>收费情况</td></tr>
        <tr>
            <th>收费站</th>
            <th>未拆账</th>
            <th>已拆账</th>
        </tr>
        <%foreach (var item in blreports.ListMonthAmountReport())
          { %>
           <tr>
            <td><%=item.StationName %></td>
            <td><%=item.Amount %></td>
            <td><%=item.SplitAmount %></td>
        </tr>
        <%} %>
    </table>
     </div>
</div>
<div class="item">
    <h2>月发卡统计</h2>
    <div class="table">
    <table>
        <tr><td colspan="5"><%=DateTime.Now.ToString("yyyy年MM月") %>发卡统计</td></tr>
        <tr>
            <th>收费站</th>
            <th>发卡</th>
            <th>错卡</th>
            <th>回收卡</th>
            <th>坏卡数量</th>
        </tr>
        <%foreach (var item in blreports.ListMonthCardReports())
          { %>
           <tr>
            <td><%=item.StationName %></td>
            <td><%=item.SentCards %></td>
            <td><%=item.WrongCards %></td>
            <td><%=item.ReceivedCards %></td>
            <td><%=item.BrokenCards %></td>
        </tr>
        <%} %>
    </table>
     </div>
</div>
<div class="item">

    <h2>绿通月统计</h2>
    <div class="table">
    <table>
        <tr><td colspan="7"><%=DateTime.Now.ToString("yyyy年MM月") %>绿通统计</td></tr>
        <tr>
            <th>收费站</th>
            <th>月下道车流量</th>
            <th>绿通车流量</th>
            <th>绿通所占比率</th>
            <th>月不拆账收费额</th>
            <th>绿通免费额</th>
            <th>绿通所占比率</th>
        </tr>
        <%foreach (var item in blreports.ListMonthEasyAccessReports())
          { %>
           <tr>
            <td><%=item.StationName %></td>
            <td><%=item.DownAmount%></td>
            <td><%=item.EasyAccess %></td>
            <td><%=item.EasyPercent  %></td>
            <td><%=item.Amount %></td>
            <td><%=item.EasyAccessAmount  %></td>
            <td><%=item.EasyAmountPercent  %></td>

        </tr>
        <%} %>
    </table>
    </div>
</div>

<div class="item">

    <h2>车流量统计</h2>
    <div class="table">
    <table>
        <tr>
            <th>日期</th>
            <th>日下道车流量</th>
            <th>货车总量</th>
            <th>货车超载30-100%辆数</th>
            <th>所占比重</th>
            <th>超载100%以上辆数</th>
            <th>所占比重</th>
            <th>绿色通道车辆数</th>
            <th>所占比重</th>
            <th>工程车车辆数</th>
        </tr>
        <%foreach (var item in blreports.ListDailyTrafficReports())
          { %>
           <tr>
            <td><%=item.ReportDate %><%=item.StationName %></td>
            <td><%=item.DownAmount%></td>
            <td><%=item.TruckAmount %></td>
            <td><%=item.MoreThan30  %></td>
            <td><%=item.MoreThan30Percent.ToString("0.00%")  %></td>
            <td><%=item.MoreThan100 %></td>
            <td><%=item.MoreThan100Percent.ToString("0.00%")%></td>
            <td><%=item.EasyAccess %></td>
            <td><%=item.EasyAccessPercent.ToString("0.00%")%></td>
            <td><%=item.EngineeringVehicles  %></td>

        </tr>
        <%} %>
    </table>
    </div>
</div>
<div class="item">

    <h2>5轴车统计</h2>
    <div class="table">
    <table>
        <tr><td colspan="8"><%=DateTime.Now.ToString("yyyy年MM月") %>5轴车统计</td></tr>
        <tr>
            <th>收费站</th>
            <th>下道货车总量</th>
            <th>超载0-30%车辆数</th>
            <th>所占比重</th>
            <th>超载30-100%车辆数</th>
            <th>所占比重</th>
            <th>超载100%以上车辆数</th>
            <th>所占比重</th>
        </tr>
        <%foreach (var item in blreports.ListMonthTruck5Reports())
          { %>
           <tr>
            <td><%=item.StationName %></td>
            <td><%=item.DownAmount%></td>
            <td><%=item.MoreThan0  %></td>
            <td><%=item.MoreThan0Percent.ToString("0.00%")%></td>
            <td><%=item.MoreThan30  %></td>
            <td><%=item.MoreThan30Percent.ToString("0.00%")%></td>
            <td><%=item.MoreThan100   %></td>
            <td><%=item.MoreThan100Percent.ToString("0.00%")%></td>
        </tr>
        <%} %>
    </table>
    </div>
</div>

<div class="item">

    <h2>6轴车统计</h2>
    <div class="table">
    <table>
        <tr><td colspan="8"><%=DateTime.Now.ToString("yyyy年MM月") %>6轴车统计</td></tr>
        <tr>
            <th>收费站</th>
            <th>下道货车总量</th>
            <th>超载0-30%车辆数</th>
            <th>所占比重</th>
            <th>超载30-100%车辆数</th>
            <th>所占比重</th>
            <th>超载100%以上车辆数</th>
            <th>所占比重</th>
        </tr>
        <%foreach (var item in blreports.ListMonthTruck6Reports())
          { %>
           <tr>
            <td><%=item.StationName %></td>
            <td><%=item.DownAmount%></td>
            <td><%=item.MoreThan0  %></td>
            <td><%=item.MoreThan0Percent.ToString("0.00%")%></td>
            <td><%=item.MoreThan30  %></td>
            <td><%=item.MoreThan30Percent.ToString("0.00%")%></td>
            <td><%=item.MoreThan100   %></td>
            <td><%=item.MoreThan100Percent.ToString("0.00%")%></td>
        </tr>
        <%} %>
    </table>
    </div>
</div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
