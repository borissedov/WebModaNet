<%@ Page Title='<%$ Resources: Resources, CreaAggiornamenti %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreaAggiornamenti.aspx.cs" Inherits="EW.WebModaNet.CreaAggiornamenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="CreaAggiornamentiLiteral" Text='<%$ Resources: Resources, CreaAggiornamenti %>' runat="server"></asp:Literal>
    </h2>

    <p id="nessunAgente" class="info" enableviewstate="false" visible="false" runat="server">
        <asp:Literal ID="NessunAgenteLiteral" Text='<%$ Resources: Resources, NessunAgenteDaAggiornare %>' runat="server"></asp:Literal>
    </p>

    <asp:Panel ID="CreaAggiornamentiPanel" runat="server">
        <asp:UpdatePanel ID="CreaAggiornamentiUpdatePanel" runat="server">
            <ContentTemplate>
                <p id="creaAggiornamentiInfoMessage" class="info" runat="server">
                    <asp:Literal ID="IstruzioniCreaAggiornamentiLiteral" runat="server"></asp:Literal>
                </p>

                <div class="buttonWrap">
                    <asp:Button ID="CreaAggiornamentiButton" Text='<%$ Resources: Resources, CreaAggiornamenti %>' OnClick="CreaAggiornamentiButton_Click" runat="server" />
                </div>

                <p id="creaAggiornamentiSuccessMessage" class="success" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="CreaAggiornamentiSuccessMessageLiteral" Text='<%$ Resources: Resources, DownloadCompletato %>' runat="server"></asp:Literal>
                </p>

                <p id="creaAggiornamentiErrorMessage" class="error" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="CreaAggiornamentiErrorMessageLiteral" runat="server"></asp:Literal>
                </p>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="CreaAggiornamentiUpdateProgress" AssociatedUpdatePanelID="CreaAggiornamentiUpdatePanel" runat="server">
            <ProgressTemplate>
                <p class="loading">
                    <asp:Literal ID="OperazioneInCorsoLiteral" Text='<%$ Resources: Resources, OperazioneInCorso %>' runat="server"></asp:Literal>
                </p>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>
</asp:Content>
