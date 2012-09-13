<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryArticleList.ascx.cs" Inherits="Tekstenuitleg.usercontrols.CategoryArticleList" %>
<%@ Register src="ArticleListItemControl.ascx" tagName="ListItem" tagPrefix="tu"  %>

<asp:Repeater ID="ArticleListRepeater" runat="server">
    <HeaderTemplate>
        <h2><%= ArticleListHeader %></h2>
        <div id="article-list">
    </HeaderTemplate>
    <ItemTemplate>
        <tu:ListItem runat="server" Article="<%#Container.DataItem %>" />
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
