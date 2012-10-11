<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<IList<ReportModel.StationModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>收费站管理</h1>
    <hr />
    <div class="table">
    	<table>
        	<thead>
            	<tr>
                	<td>收费站</td>
                    <td>操作</td>
                </tr>
            </thead>
            <tbody>   
            <%foreach (var item in Model)
              { %>                
            	<tr>
                	<td><a href="/station/details/<%=item.StationID %>"><%=item.StationName %></a></td>
                    <td><a href="/station/CollectionClasses/<%=item.StationID %>">管理收费班</a>&nbsp;<a href="/station/delete/<%=item.StationID %>">删除</a></td>
                </tr> 
                <%} %>
                
            </tbody>        
        </table>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
