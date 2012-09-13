<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlePaginationItem.ascx.cs" Inherits="Tekstenuitleg.usercontrols.ArticlePaginationItem" %>
<%@ Import Namespace="umbraco.NodeFactory" %>

<li <% if(Node.getCurrentNodeId().Equals(ListItem.Id)){%>class="current"<% } %>><a href="<%= ListItem.Url %>" title="<%=ListItem.PageTitle %>"><%=PageNumber %></a></li>

