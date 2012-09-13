<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedContentItem.ascx.cs" Inherits="Tekstenuitleg.usercontrols.RelatedContentItem" %>

<div class="relatedNode">
<a href="<%= RelatedNode.NiceUrl %>"><%=RelatedNode.GetProperty("pageTitle") %></a>

<%if (Description != null)
  { %>
    <span><%= Description %></span>    
<% } %>

</div>