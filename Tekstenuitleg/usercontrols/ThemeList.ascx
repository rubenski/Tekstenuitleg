<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemeList.ascx.cs" Inherits="Tekstenuitleg.usercontrols.ThemeList" %>
<%@ Import Namespace="umbraco" %>
<%@ Register Src="ThemeItem.ascx" TagPrefix="OfficeCursus" TagName="ThemeItem" %>


<asp:Repeater runat="server" ID="ThemeRepeater">
    <HeaderTemplate>
        <span class="column-header"><%= library.GetDictionaryItem("ThemeListHeader")  %></span>
        <ul id="themelist">
            <li><a href="<%=Category.NiceUrl %>" class="first<%if(AllSelected){ %> selected<%}%>"><%= library.GetDictionaryItem("All Articles")  %></a></li>
    </HeaderTemplate>
    <ItemTemplate>
        <OfficeCursus:ThemeItem Theme="<%#Container.DataItem %>" runat="server"/>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
