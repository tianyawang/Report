<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<ReportModel.Truck5ReportModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        5轴车录入</h2>
    <hr />
    <%using (Html.BeginForm("Truck5Report", "report", FormMethod.Post))
      { %>
    <div class="item">
        <div class="title">
            月份</div>
        <div class="content">
            <select name="Month">
                <%for (int i = 1; i < 12; i++)
                  { %>
                <option value="<%=i %>" <%if (i==DateTime.Now.Month) { %>selected="selected<%} %>">
                    <%=i %></option>
                <%} %>
            </select>
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
            超载0%-30%</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.MoreThan0,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.MoreThan0)%></div>
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
            &nbsp;</div>
        <div class="content">
            <input type="submit" value="添加" /></div>
        <div class="clear">
        </div>
    </div>
    <%} %></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
