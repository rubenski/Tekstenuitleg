<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogComments.ascx.cs"
    Inherits="Tekstenuitleg.usercontrols.BlogComments" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="CursusIndex.util.validation" %>
<%@ Import Namespace="umbraco" %>
<%@ Register Src="BlogComment.ascx" TagName="blogcomment" TagPrefix="tu" %>
<asp:Repeater runat="server" ID="CommentsRepeater">
    <ItemTemplate>
        <tu:blogcomment runat="server" Comment="<%#Container.DataItem %>" />
    </ItemTemplate>
</asp:Repeater>
<form id="BlogForm" runat="server">
<div id="blog-comment-erros">
    <asp:Repeater ID="ErrorRepeater" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%# ((FieldValidationResult)Container.DataItem).Message %></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
<table>
    <tr>
        <td>
            <label>
                <asp:Label ID="NameLabel" runat="server"><%= library.GetDictionaryItem("BlogCommentFormNameLabel") %></asp:Label></label>
        </td>
        <td>
            <asp:TextBox ID="Name" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <label>
                <asp:Label ID="EmailLabel" runat="server"><%= library.GetDictionaryItem("BlogEmailLabel")%></asp:Label></label>
        </td>
        <td>
            <asp:TextBox ID="EmailAddress" runat="server" /><span id="valid-email-warning"><%= library.GetDictionaryItem("EmailNotShownOnSite")%></span>
        </td>
    </tr>
    <tr>
        <td>
            <label>
                <asp:Label ID="MessageLabel" runat="server"><%= library.GetDictionaryItem("BlogMessageLabel")%></asp:Label></label>
        </td>
        <td>
            <asp:TextBox ID="Message" TextMode="MultiLine" Columns="55" Rows="12" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <label>
                <asp:Label ID="AutoSubmissionPreventionLabel" runat="server"><%= library.GetDictionaryItem("BlogRobotCheck")%></asp:Label></label>
        </td>
        <td>
            <%= SubmissionPrevention.Calculation %>&nbsp;=&nbsp;<asp:TextBox ID="CalcResult"
                Width="30" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:Button ID="SubmitPost" runat="server" Text="Submit" />
        </td>
    </tr>
</table>
</form>
