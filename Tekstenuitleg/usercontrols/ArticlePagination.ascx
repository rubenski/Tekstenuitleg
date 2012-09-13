<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticlePagination.ascx.cs" Inherits="Tekstenuitleg.usercontrols.ArticlePagination" %>
<%@ Register src="ArticlePaginationItem.ascx" tagPrefix="tu" tagName="paginationItem" %>

<script language="C#" runat="Server">
//needed as cannot get Container.ItemIndex directly
int GetItemIndex(int index)
{
    return index;
}
</script>

<% if (ShowPagination)
   { %>
<div id="pagination">
    <asp:repeater ID="ArticlePaginationRepeater" runat="server">
        <HeaderTemplate>
            <ol>
        </HeaderTemplate>
        <ItemTemplate>
            <tu:paginationItem runat="server" ListItem="<%#Container.DataItem %>" PageNumber="<%#GetItemIndex(Container.ItemIndex) + 1 %>"/>
        </ItemTemplate>
        <FooterTemplate>
            </ol>
        </FooterTemplate>
    </asp:repeater>
</div>

<% } %>
