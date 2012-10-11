<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<ReportModel.DailyCardReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        日发卡录入</h2>
    <hr />
    <%using (Html.BeginForm("DailyCardReport", "report", FormMethod.Post))
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
            收费班</div>
        <div class="content">
            <select name="CollectionClassID">
            <%foreach (var item in (IList<ReportModel.CollectionClassModel>)ViewBag.Classes)
              { %>
                <option value="<%=item.ClassID %>"><%=item.ClassName %></option>
            <%} %>
            </select>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            发卡</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.SentCards,new{@class="inp2" }) %>
            <%: Html.ValidationMessageFor(m => m.SentCards)%></div>
        <div class="clear">
        </div>
    </div>
    <div class="item">
        <div class="title">
            错卡</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.WrongCards,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.WrongCards)%></div>
    </div>
    <div class="clear">
    </div>
    <div class="item">
        <div class="title">
            回收卡</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.ReceivedCards,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.ReceivedCards)%></div>
    </div>
    <div class="clear">
    </div>
    <div class="item">
        <div class="title">
            坏卡</div>
        <div class="content">
            <%=Html.TextBoxFor(m=>m.BrokenCards,new{@class="inp2"}) %>
            <%: Html.ValidationMessageFor(m => m.BrokenCards)%></div>
    </div>
    <div class="clear">
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
