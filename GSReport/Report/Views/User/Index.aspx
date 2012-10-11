<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<IList<ReportModel.UserModel>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>用户管理</h1>
    <hr />
    <div class="table">
    	<table>
        	<thead>
            	<tr>
                	<td>用户名</td>
                    <td>密码</td>
                    <td>所属站</td>
                    <td>操作</td>
                </tr>
            </thead>
            <tbody>   
            <%foreach (var item in Model)
              { %>                
            	<tr>
                	<td><a href="/user/details/<%=item.UserID %>"><%=item.UserName %></a></td>
                    <td><%:item.Password%></td>
                    <td><%=item.StationName%></td>
                    <td><a href="/user/delete/<%=item.UserID %>">删除</a></td>
                </tr> 
                <%} %>
                
            </tbody>        
        </table>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
