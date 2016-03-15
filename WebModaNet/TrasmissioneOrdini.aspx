<%@ Page Title='<%$ Resources: Resources, TrasmissioneOrdini %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrasmissioneOrdini.aspx.cs" Inherits="EW.WebModaNet.TrasmissioneOrdini" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, TrasmissioneOrdini %>' runat="server"></asp:Literal>
    </h2>

    <p id="necessarioAggiornamento" class="warning" enableviewstate="false" visible="false" runat="server">
        <asp:Literal ID="NecessarioAggiornamentoLiteral" runat="server"></asp:Literal>
    </p>

    <p id="infoMessage" class="info" enableviewstate="false" visible="false" runat="server">
        <asp:Literal ID="InfoMessageLiteral" runat="server"></asp:Literal>
    </p>

    <p id="connectionErrorMessage" class="error" enableviewstate="false" visible="false" runat="server">
        <asp:Literal ID="ConnectionErrorMessageLiteral" runat="server"></asp:Literal>
    </p>

    <asp:Panel ID="TrasmissioneOrdiniPanel" runat="server">
        <asp:UpdatePanel ID="TrasmissioneOrdiniUpdatePanel" runat="server">
            <ContentTemplate>
                <p id="istruzioniTrasmissione" class="info" runat="server">
                    <asp:Literal ID="IstruzioniTrasmissioneOrdiniLiteral" runat="server"></asp:Literal>
                </p>    

                <p id="successMessage" class="success" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="SuccessMessageLiteral" runat="server"></asp:Literal>
                </p>

                <p id="errorMessage" class="error" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="ErrorMessageLiteral" runat="server"></asp:Literal>
                </p>

                <div id="trasmettiButtonContainer" runat="server">
                    <asp:Button ID="TrasmettiButton" Text='<%$ Resources: Resources, Trasmetti %>' CssClass="confirm" data-message='<%$ Resources: Resources, MessaggioConferma %>' OnClick="TrasmettiButton_Click" runat="server" />
                </div>

                <!-- Ordini -->

                <p id="ordiniInfo" class="info" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="OrdiniInfoLiteral" runat="server"></asp:Literal>
                </p>

                <h3 id="esitoOrdini" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="EsitoOrdiniLiteral" Text='<%$ Resources: Resources, EsitoTrasmissioneOrdini %>' runat="server"></asp:Literal>
                </h3>

                <asp:Repeater ID="OrdiniResponseRepeater" Visible="false" runat="server">
                    <HeaderTemplate>
                        <ol class="esitoTrasmissione">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <%# Container.DataItem %>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ol>
                    </FooterTemplate>
                </asp:Repeater>

                <!-- Clienti -->

                <p id="clientiInfo" class="info" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="ClientiInfoLiteral" runat="server"></asp:Literal>
                </p>

                <h3 id="esitoClienti" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="EsitoClientiLiteral" Text='<%$ Resources: Resources, EsitoTrasmissioneClienti %>' runat="server"></asp:Literal>
                </h3>

                <asp:Repeater ID="ClientiResponseRepeater" Visible="false" runat="server">
                    <HeaderTemplate>
                        <ol class="esitoTrasmissione">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <%# Container.DataItem %>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ol>
                    </FooterTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="TrasmissioneOrdiniUpdateProgress" AssociatedUpdatePanelID="TrasmissioneOrdiniUpdatePanel" runat="server">
            <ProgressTemplate>
                <p class="loading">
                    <asp:Literal ID="AttesaTrasmissioneOrdiniLiteral" Text='<%$ Resources: Resources, AttesaTrasmissioneOrdini %>' runat="server"></asp:Literal>
                </p>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>

    <div class="pulsantiera">
        <asp:HyperLink ID="TornaIndietroLink" CssClass="pulsante linkTorna" NavigateUrl="~/Ordini.aspx" Text='<%$ Resources: Resources, TornaElencoOrdini %>' runat="server"></asp:HyperLink>
    </div>
</asp:Content>
