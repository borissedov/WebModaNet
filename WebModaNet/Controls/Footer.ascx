<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="EW.WebModaNet.Controls.Footer" %>
<footer>
    <asp:Label ID="StatoLabel" CssClass="statoApplicazione" runat="server"></asp:Label> -
    <asp:HyperLink ID="ModificaNomeUtenteLink" NavigateUrl="~/InserisciNomeUtente.aspx" runat="server"></asp:HyperLink> <asp:Literal ID="SeparatorLiteral1" runat="server">-</asp:Literal>
    <asp:Label ID="DatiDittaLabel" runat="server"></asp:Label>
    <asp:HyperLink ID="SitoWebDittaLink" runat="server" Target="_blank"></asp:HyperLink>

    <!-- - HTML5  - powered by <a href="http://www.expertweb.it" target="_blank">EXPERTWEB</a> -->
    <asp:Label ID="StatisticsLabel" Visible="false" runat="server"></asp:Label>
    <a id="showAdvancedStats" href="#" visible="false" runat="server">Adv. Stats</a>
    <asp:Literal ID="SeparatorLiteral2" runat="server">-</asp:Literal>
    <a id="showTrace" href="#" visible="false" runat="server">Trace</a>
</footer>