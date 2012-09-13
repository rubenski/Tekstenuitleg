<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogList.ascx.cs" Inherits="Tekstenuitleg.usercontrols.BlogList" %>
<%@ Register tagPrefix="tu" tagName="blogpost" src="BlogListItem.ascx" %>

<asp:Repeater runat="server" ID="BlogRepeater">
    <HeaderTemplate> 
        <div id="blog-list">
    </HeaderTemplate>
    <ItemTemplate>
        <tu:blogpost BlogPost="<%#Container.DataItem %>" SnippetSize="<%#SnippetSize %>" runat="server"/>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>