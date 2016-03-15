<%@ Page Title='<%$ Resources: Resources, InserisciNuovoCliente %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserisciModificaCliente.aspx.cs" Inherits="EW.WebModaNet.InserisciModificaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, InserisciNuovoCliente %>' runat="server"></asp:Literal>
    </h2>

    <div class="pulsantiera">
        <asp:HyperLink ID="TornaIndietroLink" CssClass="pulsante linkTorna" NavigateUrl="~/Clienti.aspx" Text='<%$ Resources: Resources, TornaElencoClienti %>' runat="server"></asp:HyperLink>
    </div>

    <asp:ValidationSummary ID="MainValidationSummary" ValidationGroup="InserisciCliente" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' runat="server" />

    <asp:Panel ID="ClientePanel" DefaultButton="InserisciModificaClienteButton" runat="server">
        <div class="divField datiCliente">
            <fieldset>
                <legend>
                    <asp:Literal ID="DatiClienteLiteral" Text='<%$ Resources: Resources, DatiCliente %>' runat="server"></asp:Literal>
                </legend>

                <div class="fieldCodiceCliente">
                    <asp:Label ID="CodiceClienteLabel" AssociatedControlID="CodiceClienteTextBox" Text='<%$ Resources: Resources, Codice %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="CodiceClienteValidator" ControlToValidate="CodiceClienteTextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Codice %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="CodiceClienteTextBox" Enabled="false" MaxLength="26" runat="server"></asp:TextBox>
                </div>

                <div class="fieldRagioneSociale1">
                    <asp:Label ID="RagioneSocialeLabel" AssociatedControlID="RagioneSociale1TextBox" Text='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="RagioneSocialeValidator" ControlToValidate="RagioneSociale1TextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="RagioneSociale1TextBox" MaxLength="30" runat="server"></asp:TextBox>
                </div>

                <div class="fieldRagioneSociale2">
                	<label><span class="hidn">Ragione sociale 2</span></label>
                    <asp:TextBox ID="RagioneSociale2TextBox" MaxLength="30" runat="server"></asp:TextBox>
                </div>

                <div class="fieldReferente">
                    <asp:Label ID="ReferenteLabel" AssociatedControlID="ReferenteTextBox" Text='<%$ Resources: Resources, Referente %>' runat="server"></asp:Label>
                    <asp:TextBox ID="ReferenteTextBox" MaxLength="30" runat="server"></asp:TextBox>
                </div>

                <div class="fieldPartitaIva">
                    <asp:Label ID="PartitaIvaLabel" AssociatedControlID="PartitaIvaTextBox" Text='<%$ Resources: Resources, PartitaIva %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="PartitaIvaValidator" ControlToValidate="PartitaIvaTextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, PartitaIva %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="PartitaIvaCustomValidator" ControlToValidate="PartitaIvaTextBox" ValidationGroup="InserisciCliente"
                        ErrorMessage='<%$ Resources: Resources, PartitaIva %>' OnServerValidate="PartitaIvaCustomValidator_ServerValidate" runat="server"></asp:CustomValidator>
                    <asp:TextBox ID="PartitaIvaTextBox" MaxLength="11" runat="server"></asp:TextBox>
                </div>

                <div class="fieldCodiceFiscale">
                    <asp:Label ID="CodiceFiscaleLabel" AssociatedControlID="CodiceFiscaleTextBox" Text='<%$ Resources: Resources, CodiceFiscale %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="CodiceFiscaleValidator" ControlToValidate="CodiceFiscaleTextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, CodiceFiscale %>' runat="server"></asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="CodiceFiscaleRegexValidator" ControlToValidate="CodiceFiscaleTextBox"
                        ValidationExpression="[a-zA-Z]{6}\d{2}[a-zA-Z]\d{2}[0-9a-zA-Z]{4}[a-zA-Z]" ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, CodiceFiscale %>' runat="server"></asp:RegularExpressionValidator>--%>
                    <asp:TextBox ID="CodiceFiscaleTextBox" MaxLength="16" runat="server"></asp:TextBox>
                </div>

                <div class="fieldListino">
                    <asp:Label ID="ListinoLabel" AssociatedControlID="ListiniList" Text='<%$ Resources: Resources, Listino %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="ListinoValidator" ControlToValidate="ListiniList"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Listino %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ListiniList" runat="server"></asp:DropDownList>
                </div>

                <div class="fieldValuta">
                    <asp:Label ID="ValutaLabel" AssociatedControlID="ValuteList" Text='<%$ Resources: Resources, Valuta %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="ValutaValidator" ControlToValidate="ValuteList"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Valuta %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ValuteList" DataValueField="Codice" DataTextField="Descrizione" runat="server"></asp:DropDownList>
                </div>

                <div class="fieldMetodoPagamento">
                    <asp:Label ID="MetodoPagamentoLabel" AssociatedControlID="MetodiPagamentoList" Text='<%$ Resources: Resources, MetodoPagamento %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="MetodoPagamentoValidator" ControlToValidate="MetodiPagamentoList"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, MetodoPagamento %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="MetodiPagamentoList" DataValueField="Codice" DataTextField="DescrizioneCompleta" runat="server"></asp:DropDownList>
                </div>

                <div class="fieldAbi">
                    <asp:Label ID="AbiLabel" AssociatedControlID="AbiTextBox" Text='<%$ Resources: Resources, Abi %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="AbiValidator" ControlToValidate="AbiTextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Abi %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="AbiRegexValidator" ControlToValidate="AbiTextBox" ValidationExpression="\d{1,5}"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Abi %>' runat="server"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="AbiTextBox" MaxLength="5" runat="server"></asp:TextBox>
                </div>

                <div class="fieldCab">
                    <asp:Label ID="CabLabel" AssociatedControlID="CabTextBox" Text='<%$ Resources: Resources, Cab %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="CabValidator" ControlToValidate="CabTextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Cab %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CabRegexValidator" ControlToValidate="CabTextBox" ValidationExpression="\d{1,5}"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Cab %>' runat="server"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="CabTextBox" MaxLength="5" runat="server"></asp:TextBox>
                </div>

                <div class="fieldIban">
                    <asp:Label ID="IbanLabel" AssociatedControlID="IbanTextBox" Text='<%$ Resources: Resources, Iban %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="IbanValidator" ControlToValidate="IbanTextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Iban %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="IbanTextBox" MaxLength="50" runat="server"></asp:TextBox>
                </div>

                <div class="fieldTelefono">
                    <asp:Label ID="TelefonoLabel" AssociatedControlID="TelefonoTextBox" Text='<%$ Resources: Resources, Telefono %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="TelefonoValidator" ControlToValidate="TelefonoTextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Telefono %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="TelefonoTextBox" MaxLength="20" runat="server"></asp:TextBox>
                </div>

                <div class="fieldCellulare">
                    <asp:Label ID="CellulareLabel" AssociatedControlID="CellulareTextBox" Text='<%$ Resources: Resources, Cellulare %>' runat="server"></asp:Label>
                    <asp:TextBox ID="CellulareTextBox" MaxLength="20" runat="server"></asp:TextBox>
                </div>

                <div class="fieldFax">
                    <asp:Label ID="FaxLabel" AssociatedControlID="FaxTextBox" Text='<%$ Resources: Resources, Fax %>' runat="server"></asp:Label>
                    <asp:TextBox ID="FaxTextBox" MaxLength="20" runat="server"></asp:TextBox>
                </div>

                <div class="fieldEmail">
                    <asp:Label ID="EmailLabel" AssociatedControlID="EmailTextBox" Text='<%$ Resources: Resources, Email %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="EmailValidator" ControlToValidate="EmailTextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Email %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="EmailRegexValidator" ControlToValidate="EmailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Email %>' runat="server"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="EmailTextBox" MaxLength="200" runat="server"></asp:TextBox>
                </div>
            </fieldset>
        </div>

        <div class="divField indirizzoSedeLegale">
            <fieldset>
                <legend><asp:Literal ID="IndirizzoSedeLegaleLiteral" Text='<%$ Resources: Resources, IndirizzoSedeLegale %>' runat="server"></asp:Literal></legend>
				<div class="perc100">
                    <div>
                        <asp:Label ID="ViaSedeLegaleLabel" AssociatedControlID="ViaSedeLegale1TextBox" Text='<%$ Resources: Resources, Via %>' runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="ViaSedeLegaleValidator" ControlToValidate="ViaSedeLegale1TextBox"
                            ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Via %>' runat="server"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="ViaSedeLegale1TextBox" MaxLength="35" runat="server"></asp:TextBox>
                    </div>
    
                    <div>
                        <label><span class="hidn">Via 2</span></label>
                        <asp:TextBox ID="ViaSedeLegale2TextBox" MaxLength="35" runat="server"></asp:TextBox>
                    </div>
    
                    <div>
                        <asp:Label ID="CapSedeLegaleLabel" AssociatedControlID="CapSedeLegaleTextBox" Text='<%$ Resources: Resources, Cap %>' runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="CapSedeLegaleValidator" ControlToValidate="CapSedeLegaleTextBox"
                            ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Cap %>' runat="server"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="CapSedeLegaleTextBox" MaxLength="10" runat="server"></asp:TextBox>
                    </div>
				</div>
                <div>
                    <asp:Label ID="CittaSedeLegaleLabel" AssociatedControlID="CittaSedeLegale1TextBox" Text='<%$ Resources: Resources, Citta %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="CittaSedeLegaleValidator" ControlToValidate="CittaSedeLegale1TextBox"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Citta %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="CittaSedeLegale1TextBox" MaxLength="25" runat="server"></asp:TextBox>
                </div>

                <div>
                	<label><span class="hidn">Citta 2</span></label>
                    <asp:TextBox ID="CittaSedeLegale2TextBox" MaxLength="25" runat="server"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="NazioneSedeLegaleLabel" AssociatedControlID="NazioniSedeLegaleList" Text='<%$ Resources: Resources, Nazione %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="NazioneSedeLegaleLabelValidator" ControlToValidate="NazioniSedeLegaleList"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Nazione %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="NazioniSedeLegaleList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" AutoPostBack="true"
                        OnSelectedIndexChanged="NazioniSedeLegaleList_SelectedIndexChanged" runat="server">
                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaNazioneLista %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div>
                    <asp:Label ID="ProvinciaSedeLegaleLabel" AssociatedControlID="ProvinceSedeLegaleList" Text='<%$ Resources: Resources, Provincia %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="ProvinciaSedeLegaleValidator" ControlToValidate="ProvinceSedeLegaleList"
                        ValidationGroup="InserisciCliente" ErrorMessage='<%$ Resources: Resources, Provincia %>' Enabled="false" runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ProvinceSedeLegaleList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" Enabled="false" runat="server">
                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaProvinciaLista %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </fieldset>
        </div>

        <asp:ValidationSummary ID="IndirizziValidationSummary" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' ValidationGroup="AggiungiIndirizzo" runat="server" />

        <div class="divField indirizziCliente">
            <fieldset>
                <legend><asp:Literal ID="IndirizziClienteLiteral" Text='<%$ Resources: Resources, IndirizziCliente %>' runat="server"></asp:Literal></legend>

                <div>
                    <asp:Label ID="RagioneSocialeIndirizzoLabel" AssociatedControlID="RagioneSociale1IndirizzoTextBox" Text='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RagioneSociale1IndirizzoTextBox" ValidationGroup="AggiungiIndirizzo" 
                        ErrorMessage='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="RagioneSociale1IndirizzoTextBox" MaxLength="30" runat="server"></asp:TextBox>
                </div>

                <div>
                	<label><span class="hidn">&nbsp;RagioneSociale2</span></label>
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

                <div class="fieldCheckPredefinito">
                    <asp:CheckBox ID="PredefinitoCheckBox" Text='<%$ Resources: Resources, IndirizzoPredefinito %>' runat="server" />
                </div>

                <div>
                    <asp:Button ID="AggiungiIndirizzoButton" Text='<%$ Resources: Resources, AggiungiIndirizzo %>' ValidationGroup="AggiungiIndirizzo"
                        OnClick="AggiungiIndirizzoButton_Click" runat="server" />
                </div>

                <asp:Repeater ID="IndirizziRepeater" OnItemCommand="ListaIndirizzi_ItemCommand" Visible="false" runat="server">
                    <HeaderTemplate>
                        <div class="listaIndirizzi">
                            <h3>
                                <asp:Literal ID="LIstaIndirizziLiteral" Text='<%$ Resources: Resources, ListaIndirizzi %>' runat="server"></asp:Literal>
                            </h3>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="singoloIndirizzo">
                            <asp:Button ID="EliminaIndirizzoButton" CommandName="EliminaIndirizzo" Text='<%$ Resources: Resources, Elimina %>' runat="server" />
                            <p><%# Container.DataItem %></p>
                            <asp:Image ID="IndirizzoPredefinitoImage" ImageUrl="~/Images/default.png" AlternateText='<%$ Resources: Resources, Predefinito %>'
                                ToolTip='<%$ Resources: Resources, Predefinito %>' Visible='<%# Convert.ToBoolean(Eval("Predefinito")) %>' runat="server" />
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </fieldset>
        </div>

        <div class="buttonWrap">
            <asp:Button ID="InserisciModificaClienteButton" Text='<%$ Resources: Resources, Salva %>' ValidationGroup="InserisciCliente"
                CssClass="salva-cliente" data-message='<%$ Resources: Resources, ConfermaSalvaCliente %>' OnClick="InserisciModificaClienteButton_Click" runat="server" />
        </div>
    </asp:Panel>
</asp:Content>
