<%@ Page Title='<%$ Resources: Resources, AggiornaApplicazione %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AggiornaApplicazione.aspx.cs" Inherits="EW.WebModaNet.AggiornaApplicazione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="aggiornaApplicazione">
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, AggiornaApplicazione %>' runat="server"></asp:Literal>
    </h2>

    <p id="applicazioneGiaAggiornata" class="info" enableviewstate="false" visible="false" runat="server">
        <asp:Literal ID="ApplicazioneGiaAggiornataLiteral" Text='<%$ Resources: Resources, ApplicazioneGiaAggiornata %>' runat="server"></asp:Literal>
    </p>

    <asp:Panel ID="DownloadPanel" runat="server">
        <p class="info">
            <asp:Literal ID="IstruzioniDownloadLiteral" Text='<%$ Resources: Resources, IstruzioniDownload %>' runat="server"></asp:Literal>
        </p>

        <asp:UpdatePanel ID="DownloadUpdatePanel" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Button ID="DownloadButton" Text='<%$ Resources: Resources, Download %>' OnClick="DownloadButton_Click" runat="server" />
                </div>

                <p id="downloadInfoMessage" class="info" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="DownloadInfoMessageLiteral" Text='<%$ Resources: Resources, AggiornamentiNonTrovati %>' runat="server"></asp:Literal>
                </p>

                <p id="downloadSuccessMessage" class="success" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="DownloadSuccessMessageLiteral" Text='<%$ Resources: Resources, DownloadCompletato %>' runat="server"></asp:Literal>
                </p>

                <p id="downloadErrorMessage" class="error" enableviewstate="false" visible="false" runat="server">
                    <asp:Literal ID="DownloadErrorMessageLiteral" runat="server"></asp:Literal>
                </p>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="DownloadUpdateProgress" AssociatedUpdatePanelID="DownloadUpdatePanel" runat="server">
            <ProgressTemplate>
                <p class="loading">
                    <asp:Literal ID="AttesaDownloadLiteral" Text='<%$ Resources: Resources, AttesaDownload %>' runat="server"></asp:Literal>
                </p>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>

    <asp:Panel ID="RipetiDownloadPanel" runat="server">
        <p class="info">
            <asp:Literal ID="RipetiDownloadLiteral" Text='<%$ Resources: Resources, MessaggioRipetiDownload %>' runat="server"></asp:Literal>
        </p>

        <div>
            <asp:Button ID="RipetiDownloadButton" Text='<%$ Resources: Resources, RipetiDownload %>' OnClick="RipetiDownloadButton_Click" runat="server" />
        </div>
    </asp:Panel>

    <asp:Panel ID="InstallazionePanel" runat="server">
        <p id="installazioneInfoMessage" class="info" runat="server">
            <asp:Literal ID="IstruzioniInstallazioneLiteral" Text='<%$ Resources: Resources, IstruzioniInstallazione %>' runat="server"></asp:Literal>
        </p>

        <p id="installazioneWarningMessage" class="warning" runat="server">
            <asp:Literal ID="InstallazioneWarningMessageLiteral" Text='<%$ Resources: Resources, WarningInstallazione %>' runat="server"></asp:Literal>
        </p>

        <div>
            <asp:Button ID="InstallaButton" Text='<%$ Resources: Resources, Installa %>' CssClass="confirm" data-message='<%$ Resources: Resources, MessaggioConferma %>' OnClick="InstallaButton_Click" runat="server" />
        </div>

        <p id="installazioneSuccessMessage" class="success" enableviewstate="false" visible="false" runat="server">
            <asp:Literal ID="InstallazioneSuccessMessageLiteral" runat="server"></asp:Literal>
        </p>

        <p id="installazionErrorMessage" class="error" enableviewstate="false" visible="false" runat="server">
            <asp:Literal ID="InstallazionErrorMessageLiteral" runat="server"></asp:Literal>
        </p>
    </asp:Panel>
</asp:Content>
