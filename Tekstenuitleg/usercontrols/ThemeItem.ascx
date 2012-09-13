<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemeItem.ascx.cs" Inherits="Tekstenuitleg.usercontrols.ThemeItem" %>

<li><a <% if(Theme.Selected) { %>class="selected"<% } %> href="<%= Theme.Url %>"><%= Theme.Name%></a></li>
