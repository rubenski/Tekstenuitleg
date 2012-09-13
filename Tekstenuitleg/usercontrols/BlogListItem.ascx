<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogListItem.ascx.cs" Inherits="Tekstenuitleg.usercontrols.BlogPostItem" %>

<div class="blogPostSummary">
    <h2><a href="<%= BlogPost.NiceUrl %>"><%=BlogPost.GetProperty("pageTitle").Value %></a></h2>
    <span class="date"><%=PostDate %></span>
    <div><%=Text %>
    <%if (ShowReadMore)
      { %>
      <br/>&raquo; <a href="<%= BlogPost.NiceUrl %>">Lees verder</a>

    <%} %>
    </div>
</div>