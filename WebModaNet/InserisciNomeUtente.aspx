<%@ Page Title='<%$ Resources: Resources, InserisciNomeUtente %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserisciNomeUtente.aspx.cs" Inherits="EW.WebModaNet.InserisciNomeUtente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="InserisciNomeUtenteLiteral" Text='<%$ Resources: Resources, InserisciNomeUtente %>' runat="server"></asp:Literal>
    </h2>

    <p class="info">
        <asp:Literal ID="IstruzioniInserisciNomeUtenteLiteral" Text='<%$ Resources: Resources, IstruzioniInserisciNomeUtente %>' runat="server"></asp:Literal>
    </p>

    <div class="divField">
        <fieldset>
            <legend><asp:Literal ID="DatiUtenteLiteral" Text='<%$ Resources: Resources, DatiUtente %>' runat="server"></asp:Literal></legend>

            <div class="fieldNomeUtente">
                <asp:Label ID="NomeUtenteLiteral" AssociatedControlID="NomeUtenteTextBox" Text='<%$ Resources: Resources, NomeUtente %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="NomeUtenteValidator" ControlToValidate="NomeUtenteTextBox" ValidationGroup="InserisciNomeUtente" Text="*" runat="server"></asp:RequiredFieldValidator>
                <asp:TextBox ID="NomeUtenteTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldConferma">
                <asp:Button ID="ConfermaButton" Text='<%$ Resources: Resources, Conferma %>' ValidationGroup="InserisciNomeUtente" OnClick="ConfermaButton_Click" runat="server" />
            </div>
        </fieldset>
    </div>
</asp:Content>
