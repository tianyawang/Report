<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<ReportModel.SplitBillReport>" %>

    <asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h2>
            6轴车录入</h2>
        <hr />
        <%using (Html.BeginForm("SpiltBill", "report", FormMethod.Post))
      { %>
        <div class="item">
            <div class="title">
                月份</div>
            <div class="content">
                <select name="Month">
                    <%for (int i = 1;i<12; i++){ %>
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
                金额</div>
            <div class="content">
                <%=Html.TextBoxFor(m=>m.Amount,new{@class="inp2" }) %>
                <%: Html.ValidationMessageFor(m => m.Amount)%></div>
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
</asp:Content>
