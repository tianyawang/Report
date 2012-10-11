<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>收费站报表</h2>
<%BLReport.BLReports blreports = new BLReport.BLReports(); %>
<div class="item">
    <h2>日收费统计</h2>
    <div class="table">
        <ul>
            
            <% var date=DateTime.Now;
                var dailyamountreport=blreports.ListStationDailyAmountReport(CurrentUserModel.Current.StationID,date);
                foreach (var item in dailyamountreport)
              { %>
            <li><%=date.ToString("yyyy-MM-dd") %><%=item.SchedueName %>收费<%=item.Amount %>元</li>
            <%} %>
            <li><%=date.ToString("yyyy-MM-dd") %>共计收费<%=dailyamountreport.Sum(t=>t.Amount)%>元</li>
        </ul>
    </div>

</div>

<div class="item">
    <h2>月收费统计</h2>
    <div class="table">
        <ul>
            <li><%=DateTime.Now.ToString("yyyy年MM月")%></li>
            <% 
                var monthamountreport=blreports.GetDailyAmountMonthReport(CurrentUserModel.Current.StationID,DateTime.Now);%>
            <li>当月实收<%=monthamountreport.CurrentAmount%>元</li>
            <li>累计实收<%=monthamountreport.TotalAmount%>元</li>
        </ul>
    </div>

</div>
<div class="item">
    <h2>日发卡统计</h2>
    <div class="table">
    <table>
        <tr>
            <th><%=date.ToString("yyyy-MM-dd")%></th>
            <th>发卡</th>
            <th>错卡</th>
            <th>回收卡</th>
            <th>坏卡数量</th>
        </tr>
        <%foreach (var item in blreports.ListStationDailyCardReports(CurrentUserModel.Current.StationID, date))
          { %>
           <tr>
            <td><%=item.CollectionClassName %></td>
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
    <h2>通行卡月统计</h2>
    <div class="table">
        <ul>
            <li><%=DateTime.Now.ToString("yyyy年MM月")%></li>
            <% 
                var monthcardreport=blreports.GetDailyCardMonthReport(CurrentUserModel.Current.StationID,DateTime.Now);%>
            <li>月发卡<%=monthcardreport.SentCards%></li>
            <li>月回收卡<%=monthcardreport.ReceivedCards%></li>
            <li>月错卡<%=monthcardreport.WrongCards%></li>
            <li>月坏卡<%=monthcardreport.BrokenCards %></li>
        </ul>
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
        <%foreach (var item in blreports.ListStationDailyTrafficReports(CurrentUserModel.Current.StationID))
          { %>
           <tr>
            <td><%=item.ReportDate %></td>
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


</asp:Content>
