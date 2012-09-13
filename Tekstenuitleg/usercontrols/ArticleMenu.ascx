<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleMenu.ascx.cs" Inherits="Tekstenuitleg.usercontrols.ArticleMenu" %>
<%@ Register tagName="ArticleMenuItem" tagPrefix="OfficeCursus" src="ArticleMenuItem.ascx" %>
<%@ Import Namespace="umbraco" %>
<asp:Repeater runat="server" ID="ArticleMenuRepeater">
    <HeaderTemplate>
        <span class="column-header"><%=library.GetDictionaryItem("ArticleMenuHeader") %></span>
        <ul id="article-nav">
    </HeaderTemplate>
    <ItemTemplate>
        <OfficeCursus:ArticleMenuItem CurrentNode="<%# CurrentNode %>" ListItem="<%# Container.DataItem %>" runat="server"/>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
