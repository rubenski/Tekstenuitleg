<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderNavigation.ascx.cs" Inherits="Tekstenuitleg.usercontrols.HeaderNavigation" %>
<%@ Register tagName="headernavitem" tagPrefix="tu" src="HeaderNavItem.ascx" %>

<asp:Repeater runat="server" ID="NavigationRepeater">
    <HeaderTemplate><ul></HeaderTemplate>
    <ItemTemplate><tu:headernavitem CurrentCategory="<%# CurrentCategory%>" Category="<%#Container.DataItem %>" runat="server"/></ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>
