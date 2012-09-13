<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleListItemControl.ascx.cs"
    Inherits="Tekstenuitleg.usercontrols.ArticleListItemControl" %>
<div class="article-summary">
    <div class="listingimage">
        <% if (Article.ListImage != null)
           { %>
        <a href="<%=Article.Url %>">
            <img alt="" src="<%=Article.ListImage.GetImageUrl(85, 85, true, "white", "noresize", false)%>" />
        </a>
        <% } %>
    </div>
    <div class="listingcontent">
        <h3>
            <a href="<%=Article.Url %>"><%= String.IsNullOrEmpty(Article.ArticleTitle) ? Article.PageTitle : Article.ArticleTitle %></a>
        </h3> 
        <span><a href="<%=Article.Url %>"><%=Article.TeaserText %></a></span>
    </div><br style="clear:left"/>
</div>
