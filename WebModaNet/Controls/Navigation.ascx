<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="EW.WebModaNet.Controls.Navigation" %>
<nav id="navigation" runat="server">
    <ul class="main">
        <li>
            <asp:HyperLink ID="OrdiniLink" NavigateUrl="~/Ordini.aspx" Text='<%$ Resources: Resources, Ordini %>' runat="server"></asp:HyperLink>
            <ul class="sub">
                <li><asp:HyperLink ID="InserisciOrdineLink" Text='<%$ Resources: Resources, Inserisci %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="ElencoOrdiniLink" NavigateUrl="~/Ordini.aspx" Text='<%$ Resources: Resources, Elenco %>' runat="server"></asp:HyperLink></li>
            </ul>
        </li>
        <li id="clientiMenu" runat="server">
            <asp:HyperLink ID="ClientiLink" NavigateUrl="~/Clienti.aspx" Text='<%$ Resources: Resources, Clienti %>' runat="server"></asp:HyperLink>
            <ul class="sub">
                <li id="inserisciCliente" runat="server"><asp:HyperLink ID="InserisciClienteLink" NavigateUrl="~/InserisciModificaCliente.aspx" Text='<%$ Resources: Resources, Inserisci %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="ElencoClientiLink" NavigateUrl="~/Clienti.aspx" Text='<%$ Resources: Resources, Elenco %>' runat="server"></asp:HyperLink></li>
            </ul>
        </li>
        <li id="areaDocumentaleMenu" runat="server">
            <asp:HyperLink ID="AreaDocumentaleLink" NavigateUrl="~/AreaDocumentale.aspx" Text='<%$ Resources: Resources, AreaDocumentale %>' runat="server"></asp:HyperLink>
        </li>
        <li id="nuoviIndirizziMenu" runat="server">
            <asp:HyperLink ID="NuoviIndirizziLink" NavigateUrl="~/NuoviIndirizzi.aspx" Text='<%$ Resources: Resources, InserisciNuovoIndirizzo %>' runat="server"></asp:HyperLink>
        </li>
        <li id="offlineMenu" runat="server">
            <asp:HyperLink ID="TrasmissioneOrdiniLink1" NavigateUrl="~/TrasmissioneOrdini.aspx" Text='<%$ Resources: Resources, TrasmissioneOrdini %>' runat="server"></asp:HyperLink>
            <ul class="sub">
                <li><asp:HyperLink ID="TrasmissioneOrdiniLink2" NavigateUrl="~/TrasmissioneOrdini.aspx" Text='<%$ Resources: Resources, TrasmissioneOrdini %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="AggiornaApplicazioneLink" NavigateUrl="~/AggiornaApplicazione.aspx" Text='<%$ Resources: Resources, AggiornaApplicazione %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="AggiornaDatabaseLink" NavigateUrl="~/AggiornaDatabase.aspx" Text='<%$ Resources: Resources, AggiornaDatabase %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="AggiornaImmaginiLink" NavigateUrl="~/AggiornaImmagini.aspx" Text='<%$ Resources: Resources, AggiornaImmagini %>' runat="server"></asp:HyperLink></li>
            </ul>
        </li>
        <li id="manualeMenu" runat="server">
            <asp:HyperLink ID="ManualeLink" Text='<%$ Resources: Resources, Manuale %>' Target="_blank" runat="server"></asp:HyperLink>
        </li>
        <li id="cataloghiMenu" runat="server">
            <asp:HyperLink ID="CataloghiLink" href="#" Text='<%$ Resources: Resources, Cataloghi %>' runat="server"></asp:HyperLink>
            <ul class="sub">
                <asp:Repeater ID="rptCartelle" runat="server" OnItemDataBound="onItemDataBoundRptCartelle">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="itemLink" href="#" runat="server"></asp:HyperLink>
                            <ul class="sub2">
                                <asp:Repeater ID="rptCataloghiSub" runat="server" OnItemDataBound="onItemDataBoundCataloghi">
                                    <ItemTemplate>
                                        <li><asp:HyperLink ID="itemLink" Target="_blank" runat="server"></asp:HyperLink></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="rptCataloghi" runat="server" OnItemDataBound="onItemDataBoundCataloghi">
                    <ItemTemplate>
                        <li><asp:HyperLink ID="itemLink" Target="_blank" runat="server"></asp:HyperLink></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </li>
        <li id="adminMenu" class="admin" runat="server">
            <asp:HyperLink ID="AdminLink" NavigateUrl="~/ImpostazioniApplicazione.aspx" Text='<%$ Resources: Resources, Amministrazione %>' runat="server"></asp:HyperLink>
            <ul class="sub">
                <li><asp:HyperLink ID="ImpostazioniApplicazione" NavigateUrl="~/ImpostazioniApplicazione.aspx" Text='<%$ Resources: Resources, ImpostazioniApplicazione %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="GestioneAgentiLink" NavigateUrl="~/Agenti.aspx" Text='<%$ Resources: Resources, GestioneAgenti %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="CreaAggiornamentiLink" NavigateUrl="~/CreaAggiornamenti.aspx" Text='<%$ Resources: Resources, CreaAggiornamenti %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="GestioneGeneraleImpostazioniOrdini" NavigateUrl="~/GestioneGeneraleImpostazioniOrdini.aspx" Text='<%$ Resources: Resources, GestioneGeneraleImpostazioniOrdini %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="GestioneOrdiniLink" NavigateUrl="~/GestioneOrdini.aspx" Text='<%$ Resources: Resources, GestioneOrdini %>' runat="server"></asp:HyperLink></li>
                <li><asp:HyperLink ID="GestioneClientiLink" NavigateUrl="~/GestioneClienti.aspx" Text='<%$ Resources: Resources, GestioneClienti %>' runat="server"></asp:HyperLink></li>
            </ul>
        </li>
    </ul>
</nav>
