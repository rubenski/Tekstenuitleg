<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogComment.ascx.cs" Inherits="Tekstenuitleg.usercontrols.BlogComment" %>
<%@ Import Namespace="CursusIndex.util" %>
<%@ Import Namespace="umbraco" %>




<p class="blogComment">
    <span class="posterDetails"><b><%=Comment.GetProperty("name") %></b> <%= library.GetDictionaryItem("AtDate") %> <%=DateUtil.GetLocalizedCreateDate(Comment)%></span>
    <%=Comment.GetProperty("message").Value %>
</p>
