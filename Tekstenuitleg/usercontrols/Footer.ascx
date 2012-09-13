<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Tekstenuitleg.usercontrols.Footer" %>
<%@ Register Src="~/usercontrols/UmbracoRelatedLinkItem.ascx" TagName="link" TagPrefix="tu" %>
<div id="footer">
    <asp:Repeater ID="LinkRepeater" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><tu:link runat="server" Link="<%#Container.DataItem %>"></tu:link></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
            <span id="rights"><%=CopyrightMessage %></span>
        </div>