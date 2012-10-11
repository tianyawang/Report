<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Reports.Master" Inherits="System.Web.Mvc.ViewPage<IList<ReportModel.CollectionClassModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>收费班管理</h1>
    <hr />
    <div>
        <a href="/station/addclass/<%=ViewBag.StationID %>">添加收费班</a>
    </div>
    <div class="table">
    	<table>
        	<thead>
            	<tr>
                	<td>收费班</td>
                    <td>操作</td>
                </tr>
            </thead>
            <tbody>   
            <%foreach (var item in Model)
              { %>                
            	<tr>
                	<td><a href="/station/classdetails/<%=item.ClassID %>"><%=item.ClassName %></a></td>
                    <td><a href="/station/deleteclass/<%=item.ClassID %>?stationid=<%=ViewBag.StationID %>">删除</a></td>
                </tr> 
                <%} %>
                
            </tbody>        
        </table>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
