<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostReadArticleList.ascx.cs" Inherits="Tekstenuitleg.usercontrols.MostReadArticleList" %>
<%@ Register src="ArticleListItemControl.ascx" tagName="article" tagPrefix="tu" %>

<asp:Repeater runat="server" ID="HomepageArticles">
    <ItemTemplate>
        <tu:article runat="server" Article="<%# Container.DataItem %>" />
    </ItemTemplate>
</asp:Repeater>
