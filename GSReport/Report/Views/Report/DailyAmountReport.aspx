<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<ReportModel.DailyAmountReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>日收费录入</h2>
    <hr />
        <%using (Html.BeginForm("DailyAmountReport", "report", FormMethod.Post))
      { %>
    <div class="item">
    	<div class="title">日期</div>
        <div class="content"><%=Html.TextBoxFor(m=>m.ReportDate,new{@class="inp2"} )%>
        <%: Html.ValidationMessageFor(m => m.ReportDate)%>
        </div>
        <div class="clear"></div>
    </div>
    <div class="item">
    	<div class="title">班次</div>
        <div class="content">
            <select name="Schedue">
                <option value="1">白班</option>
                <option value="2">中班</option>
                <option value="3">夜班</option>
            </select>
        </div>
        <div class="clear"></div>
    </div>
    <div class="item">
    	<div class="title">收费额</div>
        <div class="content"><%=Html.TextBoxFor(m=>m.Amount,new{@class="inp2" }) %>
        <%: Html.ValidationMessageFor(m => m.Amount)%></div>
        <div class="clear"></div>
    </div>
        <div class="item">
    	<div class="title">绿色通道收费额</div>
        <div class="content"><%=Html.TextBoxFor(m=>m.EasyAccessAmount,new{@class="inp2"}) %>
         <%: Html.ValidationMessageFor(m => m.EasyAccessAmount)%></div></div>
        <div class="clear"></div>
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
