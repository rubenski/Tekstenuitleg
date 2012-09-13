<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderNavItem.ascx.cs" Inherits="Tekstenuitleg.usercontrols.HeaderNavItem" %>

<li><a href="<%=Category.NiceUrl %>" <% if(CurrentCategory != null && Category.Id == CurrentCategory.Id){ %>class="active"<%}%>><%= Category.Name %></a></li>


