<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedContent.ascx.cs" Inherits="Tekstenuitleg.usercontrols.RelatedContent" %>
<%@ Import Namespace="umbraco" %>
<%@ Register src="RelatedContentItem.ascx" tagName="RelatedContentItem" tagPrefix="tu" %>

<%if (Header != null)
  { %>
  <span class="column-header"><%=Header%></span>
<% } %>
<asp:Repeater runat="server" ID="RelatedNodesRepeater">
    <ItemTemplate>
        <tu:RelatedContentItem runat="server" RelatedNode="<%#Container.DataItem %>"/>   
    </ItemTemplate>
</asp:Repeater>
