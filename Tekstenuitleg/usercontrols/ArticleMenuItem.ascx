<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleMenuItem.ascx.cs" Inherits="Tekstenuitleg.usercontrols.ArticleMenuItem" %>
<%@ Import Namespace="CursusIndex.business_logic.entitities" %>

<li>
    <a <% if(ListItem.Id == CurrentNode.Id){%> class="active" <% } %> href="<%= ListItem.Url %>"><%= ListItem.PageTitle%></a>
</li>