<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Report.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
        <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true) %>
                    <%: Html.LabelFor(m => m.UserName)%>
                    <%: Html.TextBoxFor(m => m.UserName, new { @class="username"})%>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
  
                    <%: Html.LabelFor(m => m.Password)%>
                    <%: Html.PasswordFor(m => m.Password, new { @class = "password" })%>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                    <input type="submit" class="submit" value="登录" />
    <% } %>
</asp:Content>
