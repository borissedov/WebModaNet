<%@ Page Title='<%$ Resources: Resources, IndirizziCliente %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuoviIndirizzi.aspx.cs" Inherits="EW.WebModaNet.NuoviIndirizzi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, IndirizziCliente %>' runat="server"></asp:Literal>
    </h2>

    <asp:Panel ID="RicercaClientePanel" CssClass="divField divFieldRicerca ricercaCliente" runat="server">
        <fieldset>
            <legend>
                <asp:Literal ID="RicercaClienteLiteral" Text='<%$ Resources: Resources, RicercaCliente %>' runat="server"></asp:Literal>
            </legend>

            <div class="fieldRagioneSocialeCliente">
                <asp:Label ID="RagioneSocialeLabel" AssociatedControlID="RagioneSocialeTextBox" Text='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:Label>
                <asp:TextBox ID="RagioneSocialeTextBox" CssClass="textbox-clienti" runat="server"></asp:TextBox>
            </div>

            <div class="fieldListaClienti">
                <asp:Label ID="ClienteLabel" AssociatedControlID="ClientiList" Text='<%$ Resources: Resources, SelezionaCliente %>' runat="server"></asp:Label>
                <asp:DropDownList ID="ClientiList" DataValueField="Codice" DataTextField="Descrizione" AutoPostBack="true" AppendDataBoundItems="true"
                    CssClass="lista-clienti" OnSelectedIndexChanged="ClientiList_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaClienteLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>
        </fieldset>
    </asp:Panel>

    <p id="clienteNonTrovato" class="warning" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="ErroreClienteNonTrovatoLiteral" runat="server"></asp:Literal>
    </p>
    
    <asp:ValidationSummary ID="IndirizziValidationSummary" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' ValidationGroup="AggiungiIndirizzo" runat="server" />

    <asp:Panel ID="IndirizziPanel" Visible="false" DefaultButton="AggiungiIndirizzoButton" runat="server" cssclass="divField indirizziCliente">
        <fieldset>
            <legend><asp:Literal ID="IndirizziClienteLiteral" Text='<%$ Resources: Resources, IndirizziCliente %>' runat="server"></asp:Literal></legend>

            <div>
                <asp:Label ID="RagioneSocialeIndirizzoLabel" AssociatedControlID="RagioneSociale1IndirizzoTextBox" Text='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RagioneSociale1IndirizzoTextBox" ValidationGroup="AggiungiIndirizzo" 
                    ErrorMessage='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:RequiredFieldValidator>
                <asp:TextBox ID="RagioneSociale1IndirizzoTextBox" MaxLength="30" runat="server"></asp:TextBox>
            </div>

            <div>
                <label><span class="hidn">RagioneSociale2</span></label>
                <asp:TextBox ID="RagioneSociale2IndirizzoTextBox" MaxLength="30" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="ViaLabel" AssociatedControlID="Via1TextBox" Text='<%$ Resources: Resources, Via %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="ViaValidator" ControlToValidate="Via1TextBox" ValidationGroup="AggiungiIndirizzo" 
                    ErrorMessage='<%$ Resources: Resources, Via %>' runat="server"></asp:RequiredFieldValidator>
                <asp:TextBox ID="Via1TextBox" MaxLength="35" runat="server"></asp:TextBox>
            </div>

            <div>
                <label><span class="hidn">Via 2</span></label>
                <asp:TextBox ID="Via2TextBox" MaxLength="35" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="CapLabel" AssociatedControlID="CapTextBox" Text='<%$ Resources: Resources, Cap %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="CapValidator" ControlToValidate="CapTextBox" ValidationGroup="AggiungiIndirizzo"
                    ErrorMessage='<%$ Resources: Resources, Cap %>' runat="server"></asp:RequiredFieldValidator>
                <asp:TextBox ID="CapTextBox" MaxLength="10" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="CittaLabel" AssociatedControlID="Citta1TextBox" Text='<%$ Resources: Resources, Citta %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="CittaValidator" ControlToValidate="Citta1TextBox" ValidationGroup="AggiungiIndirizzo"
                    ErrorMessage='<%$ Resources: Resources, Citta %>' runat="server"></asp:RequiredFieldValidator>
                <asp:TextBox ID="Citta1TextBox" MaxLength="25" runat="server"></asp:TextBox>
            </div>

            <div>
                <label><span class="hidn">Citta2</span></label>
                <asp:TextBox ID="Citta2TextBox" MaxLength="25" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="NazioneLabel" AssociatedControlID="NazioniList" Text='<%$ Resources: Resources, Nazione %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="NazioneValidator" ControlToValidate="NazioniList" ValidationGroup="AggiungiIndirizzo"
                    ErrorMessage='<%$ Resources: Resources, Nazione %>' runat="server"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="NazioniList" DataValueField="Codice" DataTextField="Descrizione" AutoPostBack="true" OnSelectedIndexChanged="NazioniList_SelectedIndexChanged"
                    AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaNazioneLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div>
                <asp:Label ID="ProvinciaLabel" AssociatedControlID="ProvinceList" Text='<%$ Resources: Resources, Provincia %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="ProvinciaValidator" ControlToValidate="ProvinceList" ValidationGroup="AggiungiIndirizzo"
                    ErrorMessage='<%$ Resources: Resources, Provincia %>' Enabled="false" runat="server"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="ProvinceList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" Enabled="false" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaProvinciaLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div>
                <asp:Button ID="AggiungiIndirizzoButton" Text='<%$ Resources: Resources, AggiungiIndirizzo %>' ValidationGroup="AggiungiIndirizzo"
                    OnClick="AggiungiIndirizzoButton_Click" runat="server" />
            </div>
 
            <asp:Repeater ID="IndirizziRepeater" Visible="false" runat="server">
                <HeaderTemplate>
                    <div class="listaIndirizzi">
                        <h3>
                            <asp:Literal ID="LIstaIndirizziLiteral" Text='<%$ Resources: Resources, ListaIndirizzi %>' runat="server"></asp:Literal>
                        </h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="singoloIndirizzo">
                        <p><%# Container.DataItem %></p>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

        </fieldset>
    </asp:Panel>
</asp:Content>
