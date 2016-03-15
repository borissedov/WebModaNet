<%@ Page Title='<%$ Resources: Resources, ImpostazioniApplicazione %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImpostazioniApplicazione.aspx.cs" Inherits="EW.WebModaNet.ImpostazioniApplicazione" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="ImpostazioniApplicazioneLiteral" Text='<%$ Resources: Resources, ImpostazioniApplicazione %>' runat="server"></asp:Literal>
    </h2>

    <p id="impostazioniSalvate" class="success" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="ImpostazioniSalvateLiteral" Text='<%$ Resources: Resources, MessaggioImpostazioniSalvate %>' runat="server"></asp:Literal>
    </p>

    <asp:Panel ID="ImpostazioniExpertwebPanel" CssClass="divField impostazioniSicurezza" DefaultButton="SalvaImpostazioniExpertwebButton" runat="server">
        <fieldset>
            <legend><asp:Literal ID="ImpostazioniExpertwebLiteral" Text='<%$ Resources: Resources, ImpostazioniExpertweb %>' runat="server"></asp:Literal></legend>

            <asp:ValidationSummary ID="ImpostazioniExpertwebValidationSummary" ValidationGroup="SalvaImpostazioniExpertweb"
                HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' runat="server" />

            <div class="fieldNumeroMassimoUtenti">
                <asp:Label ID="NumeroMassimoUtentiLabel" AssociatedControlID="NumeroMassimoUtentiTextBox" Text='<%$ Resources: Resources, NumeroMassimoUtenti %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="NumeroMassimoUtentiValidator" ControlToValidate="NumeroMassimoUtentiTextBox" ValidationGroup="SalvaImpostazioniExpertweb"
                    runat="server"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="NumeroMassimoUtentiRegexValidator" ControlToValidate="NumeroMassimoUtentiTextBox" ValidationExpression="\d+"
                    ValidationGroup="SalvaImpostazioniExpertweb" ErrorMessage='<%$ Resources: Resources, NumeroMassimoUtenti %>' runat="server"></asp:RegularExpressionValidator>
                <asp:TextBox ID="NumeroMassimoUtentiTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldSalvaImpostazioniExpertweb">
                <asp:Button ID="SalvaImpostazioniExpertwebButton" Text='<%$ Resources: Resources, Salva %>' ValidationGroup="SalvaImpostazioniExpertweb"
                    CssClass="confirm" data-message='<%$ Resources: Resources, MessaggioConferma %>' OnClick="SalvaImpostazioniExpertwebButton_Click" runat="server" />
            </div>
        </fieldset>
    </asp:Panel>

    <div class="divField impostazioniSicurezza">
        <fieldset>
            <legend><asp:Literal ID="ImpostazioniSicurezzaLiteral" Text='<%$ Resources: Resources, ImpostazioniSicurezza %>' runat="server"></asp:Literal></legend>

            <div class="fieldSospensione">
                <asp:ImageButton ID="SospensioneButton" AlternateText='<%$ Resources: Resources, SospensioneApplicazione %>' ToolTip='<%$ Resources: Resources, SospensioneApplicazione %>'
                    CssClass="confirm" data-message='<%$ Resources: Resources, MessaggioConfermaSospensione %>' OnClick="SospensioneButton_Click" runat="server" />
                <asp:Label ID="SospensioneLabel" AssociatedControlID="SospensioneButton" Text='<%$ Resources: Resources, SospensioneApplicazione %>' runat="server"></asp:Label>
            </div>
        </fieldset>
    </div>

    <asp:ValidationSummary ID="ImpostazioniDittaValidationSummary" ValidationGroup="SalvaImpostazioniDitta" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' runat="server" />

    <asp:Panel ID="ImpostazioniDittaPanel" CssClass="divField impostazioniDitta" DefaultButton="SalvaImpostazioniDittaButton" runat="server">
        <fieldset>
            <legend>
                <asp:Literal ID="ImpostazioniDittaLiteral" Text='<%$ Resources: Resources, ImpostazioniDitta %>' runat="server"></asp:Literal>
            </legend>

            <div class="fieldCodiceDitta">
                <asp:Label ID="CodiceDittaLabel" AssociatedControlID="CodiceDittaTextBox" Text='<%$ Resources: Resources, CodiceDitta %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="CodiceDittaValidator" ControlToValidate="CodiceDittaTextBox"
                    ValidationGroup="SalvaImpostazioniDitta" ErrorMessage='<%$ Resources: Resources, CodiceDitta %>' runat="server"></asp:RequiredFieldValidator>
                <asp:TextBox ID="CodiceDittaTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldRagioneSociale">
                <asp:Label ID="RagioneSocialeLabel" AssociatedControlID="RagioneSocialeTextBox" Text='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="RagioneSocialeValidator" ControlToValidate="RagioneSocialeTextBox"
                    ValidationGroup="SalvaImpostazioniDitta" ErrorMessage='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:RequiredFieldValidator>
                <asp:TextBox ID="RagioneSocialeTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldIndirizzo">
                <asp:Label ID="IndirizzoLabel" AssociatedControlID="IndirizzoTextBox" Text='<%$ Resources: Resources, Indirizzo %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="IndirizzoValidator" ControlToValidate="IndirizzoTextBox" runat="server"
                    ValidationGroup="SalvaImpostazioniDitta" ErrorMessage='<%$ Resources: Resources, Indirizzo %>'></asp:RequiredFieldValidator>
                <asp:TextBox ID="IndirizzoTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldCap">
                <asp:Label ID="CapLabel" AssociatedControlID="CapTextBox" Text='<%$ Resources: Resources, Cap %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="CapValidator" ControlToValidate="CapTextBox"
                    ValidationGroup="SalvaImpostazioniDitta" ErrorMessage='<%$ Resources: Resources, Cap %>' runat="server"></asp:RequiredFieldValidator>
                <asp:TextBox ID="CapTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldCitta">
                <asp:Label ID="CittaLabel" AssociatedControlID="CittaTextBox" Text='<%$ Resources: Resources, Citta %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="CittaValidator" ControlToValidate="CittaTextBox"
                    ValidationGroup="SalvaImpostazioniDitta" ErrorMessage='<%$ Resources: Resources, Citta %>' runat="server"></asp:RequiredFieldValidator>
                <asp:TextBox ID="CittaTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldProvincia">
                <asp:Label ID="ProvinciaLabel" AssociatedControlID="ProvinciaList" Text='<%$ Resources: Resources, Provincia %>' runat="server"></asp:Label>
                <asp:DropDownList ID="ProvinciaList" DataValueField="Codice" DataTextField="Descrizione" runat="server"></asp:DropDownList>
            </div>

            <div class="fieldTelefono">
                <asp:Label ID="TelefonoLabel" AssociatedControlID="TelefonoTextBox" Text='<%$ Resources: Resources, Telefono %>' runat="server"></asp:Label>
                <asp:TextBox ID="TelefonoTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldFax">
                <asp:Label ID="FaxLabel" AssociatedControlID="FaxTextBox" Text='<%$ Resources: Resources, Fax %>' runat="server"></asp:Label>
                <asp:TextBox ID="FaxTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldEmail">
                <asp:Label ID="EmailLabel" AssociatedControlID="EmailTextBox" Text='<%$ Resources: Resources, Email %>' runat="server"></asp:Label>
                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldSitoWeb">
                <asp:Label ID="SitoWebLabel" AssociatedControlID="SitoWebTextBox" Text='<%$ Resources: Resources, SitoWeb %>' runat="server"></asp:Label>
                <asp:TextBox ID="SitoWebTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="fieldPartitaIVA">
                <asp:Label ID="PartitaIvaLabel" AssociatedControlID="PartitaIVATextBox" Text='<%$ Resources: Resources, PartitaIVA %>' runat="server"></asp:Label>
                <asp:TextBox ID="PartitaIVATextBox" runat="server"></asp:TextBox>
            </div>

			<div class="perc50 inserisciLogo">
                <div class="fieldLogo perc100">
                    <asp:Label ID="LogoLabel" AssociatedControlID="LogoFileUpload" CssClass="file-label" Text='<%$ Resources: Resources, Logo %>' runat="server"></asp:Label><br />
                    <asp:CustomValidator ID="LogoSizeValidator" ErrorMessage='<%$ Resources: Resources, ErroreDimensioneLogo %>'
                        ValidationGroup="SalvaImpostazioniDitta" OnServerValidate="LogoSizeValidator_ServerValidate" runat="server"></asp:CustomValidator>
                    <asp:CustomValidator ID="LogoExtensionValidator" ErrorMessage='<%$ Resources: Resources, ErroreEstensioneNonValida %>'
                        ValidationGroup="SalvaImpostazioniDitta" OnServerValidate="LogoExtensionValidator_ServerValidate" runat="server"></asp:CustomValidator>
                    <asp:FileUpload ID="LogoFileUpload" runat="server" />
                </div>
                <div class="imgLogo perc100">
                    <asp:Image ID="LogoImage" ImageUrl="~/Images/Logo.jpg" AlternateText='<%$ Resources: Resources, AnteprimaLogo %>'
                        ToolTip='<%$ Resources: Resources, AnteprimaLogo %>' runat="server" />
                </div>
            </div>

            <div class="fieldSalvaImpostazioniDitta buttonWrap">
                <asp:Button ID="SalvaImpostazioniDittaButton" Text='<%$ Resources: Resources, Salva %>' ValidationGroup="SalvaImpostazioniDitta" OnClick="SalvaImpostazioniDittaButton_Click" runat="server" />
            </div>
        </fieldset>
    </asp:Panel>

    <asp:ValidationSummary ID="ImpostazioniGeneraliValidationSummary" ValidationGroup="SalvaImpostazioniGenerali" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' runat="server" />

    <div class="divField impostazioniGenerali">
        <fieldset>
            <legend><asp:Literal ID="ImpostazioniGeneraliLiteral" Text='<%$ Resources: Resources, ImpostazioniGenerali %>' runat="server"></asp:Literal></legend>

            <div class="fieldTipiOrdineAnullamento perc70">
                <asp:Label ID="TipiOrdineAnnullamentoLabel" Text='<%$ Resources: Resources, TipiOrdineAnnullamento %>' runat="server"></asp:Label>
                <asp:CheckBoxList ID="TipiOrdineAnnullamentoCheckBoxList" DataValueField="Id" DataTextField="Descrizione" runat="server"></asp:CheckBoxList>
            </div>

            <div class="fieldNumeroGiorniAnnullamentoOrdiniSospesi perc50">
                <asp:Label ID="NumeroGiorniAnnullamentoOrdiniSospesiLabel" AssociatedControlID="NumeroGiorniAnnullamentoOrdiniSospesiTextBox" Text='<%$ Resources: Resources, NumeroGiorniAnnullamentoOrdiniSospesi %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="NumeroGiorniAnnullamentoOrdiniSospesiValidator" ControlToValidate="NumeroGiorniAnnullamentoOrdiniSospesiTextBox" ValidationGroup="SalvaImpostazioniGenerali"
                    runat="server"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="NumeroGiorniAnnullamentoOrdiniSospesiRegexValidator" ControlToValidate="NumeroGiorniAnnullamentoOrdiniSospesiTextBox"
                    ValidationExpression="\d+" ValidationGroup="SalvaImpostazioniGenerali" ErrorMessage='<%$ Resources: Resources, NumeroGiorniAnnullamentoOrdiniSospesi %>'
                    runat="server"></asp:RegularExpressionValidator>
                <asp:TextBox ID="NumeroGiorniAnnullamentoOrdiniSospesiTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldNumeroDecimali perc30">
                <asp:Label ID="NumeroDecimaliLabel" AssociatedControlID="NumeroDecimaliTextBox" Text='<%$ Resources: Resources, NumeroDecimali %>' runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="NumeroDecimaliValidator" ControlToValidate="NumeroDecimaliTextBox" ValidationGroup="SalvaImpostazioniGenerali" runat="server"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="NumeroDecimaliRegexValidator" ControlToValidate="NumeroDecimaliTextBox"
                    ValidationExpression="\d+" ValidationGroup="SalvaImpostazioniGenerali" ErrorMessage='<%$ Resources: Resources, NumeroDecimali %>'
                    runat="server"></asp:RegularExpressionValidator>
                <asp:TextBox ID="NumeroDecimaliTextBox" runat="server"></asp:TextBox>
            </div>

            <br style="clear: both" />

            <div class="fieldMostraGalleriaImmagini perc20">
                <asp:CheckBox ID="MostraGalleriaImmaginiCheckBox" Text='<%$ Resources: Resources, MostraGalleriaImmagini %>' runat="server" />
            </div>

            <div class="fieldMostraImmaginiNonTrovate perc20">
                <asp:CheckBox ID="MostraImmaginiNonTrovateCheckBox" Text='<%$ Resources: Resources, MostraImmaginiNonTrovate %>' runat="server" />
            </div>

            <div class="fieldLimitiIconeDisponibilita perc20" runat="server" id="divLimitiIconeDisponibilita">
                <asp:Label ID="DisponibilitaIconaLabel" Text='<%$ Resources: Resources, DisponibilitaIconaTitolo %>' runat="server"></asp:Label>
                <asp:Label ID="DisponibilitaLimiteInferioreLabel" AssociatedControlID="DisponibilitaLimiteInferioreTextBox" Text='<%$ Resources: Resources, Inferiore %>' runat="server"></asp:Label>
                <asp:TextBox ID="DisponibilitaLimiteInferioreTextBox" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="DisponibilitaLimiteInferioreRegexValidator" ControlToValidate="DisponibilitaLimiteInferioreTextBox"
                    ValidationExpression="[0-9]{0,}" ValidationGroup="SalvaImpostazioniGenerali" ErrorMessage='<%$ Resources: Resources, ErroreNumeroInteroNoCampo %>'
                    runat="server"></asp:RegularExpressionValidator>
                <asp:Label ID="DisponibilitaLimiteSuperioreLabel" AssociatedControlID="DisponibilitaLimiteSuperioreTextBox" Text='<%$ Resources: Resources, Superiore %>' runat="server"></asp:Label>
                <asp:TextBox ID="DisponibilitaLimiteSuperioreTextBox" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="DisponibilitaLimiteSuperioreRegexValidator" ControlToValidate="DisponibilitaLimiteSuperioreTextBox"
                    ValidationExpression="[0-9]{0,}" ValidationGroup="SalvaImpostazioniGenerali" ErrorMessage='<%$ Resources: Resources, ErroreNumeroInteroNoCampo %>'
                    runat="server"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="LimitiDisponibilitaValidator" Text='<%$ Resources: Resources, ErroriLimitiDisponibilita %>'
                    ValidationGroup="SalvaImpostazioniGenerali" OnServerValidate="LimitiDisponibilitaValidator_ServerValidate" runat="server"></asp:CustomValidator>
                    
            </div>

            <div class="fieldSalvaImpostazioniGenerali buttonWrap">
                <asp:Button ID="SalvaImpostazioniGeneraliButton" Text='<%$ Resources: Resources, Salva %>' ValidationGroup="SalvaImpostazioniGenerali"
                    OnClick="SalvaImpostazioniGeneraliButton_Click" runat="server" />
            </div>
        </fieldset>
    </div>
    
    <asp:ValidationSummary ID="ImpostazioniTipiOrdineValidationSummary" ValidationGroup="SalvaImpostazioniTipiOrdine" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' runat="server" />
    <asp:CustomValidator ID="ImpostazioniTipiOrdineValidator" Text='<%$ Resources: Resources, ErroriImpostazioniTipiOrdine %>'
                                ValidationGroup="SalvaImpostazioniTipiOrdine" OnServerValidate="ImpostazioniTipiOrdineValidator_ServerValidate" runat="server"></asp:CustomValidator>
    <asp:Panel ID="ImpostazioniTipiOrdinePanel" CssClass="divField impostazioniTipiOrdine" DefaultButton="SalvaImpostazioniTipiOrdineButton" runat="server">
        <fieldset>
            <legend><asp:Literal ID="impostazioniTipiOrdineLiteral" Text='<%$ Resources: Resources, impostazioniTipiOrdine %>' runat="server"></asp:Literal></legend>
            <table class="tabellaLista">
                <thead>
                    <tr>
                        <th>
                            <asp:Literal ID="TipoOrdineLiteral" Text='<%$ Resources: Resources, TipoOrdine %>' runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="ListinoLiteral" Text='<%$ Resources: Resources, Listino %>' runat="server"></asp:Literal>
                        </th>
                        <th>
                            <asp:Literal ID="MetodoPagamentoLiteral" Text='<%$ Resources: Resources, MetodoPagamento %>' runat="server"></asp:Literal>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr id="rigaImpostazioneOrdine" runat="server">
                        <td>
                            <asp:DropDownList ID="TipiOrdineList" DataValueField="Id" DataTextField="DescrizioneCompleta"
                                AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaTipoOrdineLista %>'></asp:ListItem>
                             </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ListiniList" AppendDataBoundItems="true" runat="server">
                                <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaListinoLista %>'></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="MetodiPagamentoList" DataValueField="Codice" DataTextField="DescrizioneCompleta" AppendDataBoundItems="true" runat="server">
                                <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaMetodoPagamentoLista %>'></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="fieldSalvaImpostazioniTipiOrdine buttonWrap">
                <asp:Button ID="SalvaImpostazioniTipiOrdineButton" ValidationGroup="SalvaImpostazioniTipiOrdine" Text='<%$ Resources: Resources, Salva %>' OnClick="SalvaImpostazioniTipiOrdine_Click" runat="server" />
            </div>
        </fieldset>
    </asp:Panel>

    <div class="divField impostazioniBlocchi">
        <fieldset>
            <legend><asp:Literal ID="ImpostazioniBlocchiLiteral" Text='<%$ Resources: Resources, ImpostazioniBlocchi %>' runat="server"></asp:Literal></legend>

            <div class="fieldBloccoNuoviClienti">
                <asp:CheckBox ID="BloccoNuoviClientiCheckBox" Text='<%$ Resources: Resources, BloccoNuoviClienti %>' runat="server" />
            </div>

            <div class="fieldBloccoIndirizziNuoviClientiVecchi">
                <asp:CheckBox ID="BloccoIndirizziNuoviClientiVecchiCheckBox" Text='<%$ Resources: Resources, BloccoIndirizziNuoviClientiVecchi %>' runat="server" />
            </div>

            <div class="fieldBloccoDataConsegnaManualeTestata">
                <asp:CheckBox ID="BloccoDataConsegnaManualeTestataCheckBox" Text='<%$ Resources: Resources, BloccoDataConsegnaManualeTestata %>' runat="server" />
            </div>

            <div class="fieldSalvaImpostazioniBlocchi buttonWrap">
                <asp:Button ID="SalvaImpostazioniBlocchiButton" Text='<%$ Resources: Resources, Salva %>' OnClick="SalvaImpostazioniBlocchiButton_Click" runat="server" />
            </div>
        </fieldset>
    </div>

    <asp:Panel ID="ImpostazioniStampaPanel" CssClass="divField impostazioniStampa" runat="server">
        <fieldset>
            <legend><asp:Literal ID="ImpostazioniStampaLiteral" Text='<%$ Resources: Resources, ImpostazioniStampa %>' runat="server"></asp:Literal></legend>

            <div class="fieldIntestazione perc50">
                <asp:Label ID="IntestazioneLabel" AssociatedControlID="IntestazioneTextBox" Text='<%$ Resources: Resources, Header %>' runat="server"></asp:Label>
                <asp:TextBox ID="IntestazioneTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>

            <div class="fieldPiede perc50">
                <asp:Label ID="PiedeLabel" AssociatedControlID="PiedeTextBox" Text='<%$ Resources: Resources, Footer %>' runat="server"></asp:Label>
                <asp:TextBox ID="PiedeTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>

            <div class="fieldCondizioniVendita perc50">
                <asp:Label ID="CondizioniVenditaLabel" AssociatedControlID="CondizioniVenditaTextBox" Text='<%$ Resources: Resources, CondizioniVendita %>' runat="server"></asp:Label>
                <asp:TextBox ID="CondizioniVenditaTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>

            <div class="fieldSalvaImpostazioniStampa buttonWrap">
                <asp:Button ID="SalvaImpostazioniStampaButton" Text='<%$ Resources: Resources, Salva %>' OnClick="SalvaImpostazioniStampaButton_Click" runat="server"  />
            </div>
        </fieldset>
    </asp:Panel>

    <asp:Panel ID="ImpostazioniMessaggiPanel" CssClass="divField impostazioniMessaggi" runat="server">
        <fieldset>
            <legend><asp:Literal ID="ImpostazioniMessaggiLiteral" Text='<%$ Resources: Resources, ImpostazioniMessaggi %>' runat="server"></asp:Literal></legend>

            <div class="fieldMessaggio perc70">
                <asp:Label ID="MessaggioLabel" AssociatedControlID="MessaggioTextBox" Text='<%$ Resources: Resources, MessaggioHome %>' runat="server"></asp:Label>
                <asp:TextBox ID="MessaggioTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>

            <div class="fieldSalvaImpostazioniMessaggi buttonWrap">
                <asp:Button ID="SalvaImpostazioniMessaggiButton" Text='<%$ Resources: Resources, Salva %>' OnClick="SalvaImpostazioniMessaggiButton_Click" runat="server"  />
            </div>
        </fieldset>
    </asp:Panel>

    <asp:ValidationSummary ID="ImpostazioniAreaDocumentaleValidationSummary" ValidationGroup="SalvaImpostazioniAreaDocumentale" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' runat="server" />

    <div class="divField impostazioniAreaDocumentale">
        <fieldset>
            <legend><asp:Literal Text='<%$ Resources: Resources, ImpostazioniAreaDocumentale %>' runat="server"></asp:Literal></legend>

            <div class="fieldAttivaAreaDocumentale">
                <asp:CheckBox ID="AttivaAreaDocumentaleCheckBox" Text='<%$ Resources: Resources, AttivaAreaDocumentale %>' runat="server" />
            </div>

            <div class="fieldCartellaDocumentiPdf">
                <asp:Label AssociatedControlID="CartellaDocumentiPdfTextBox" Text='<%$ Resources: Resources, CartellaDocumentiPdf %>' runat="server"></asp:Label>
                <asp:TextBox ID="CartellaDocumentiPdfTextBox" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="CartellaDocumentiPdfValidator" ControlToValidate="CartellaDocumentiPdfTextBox" Text='<%$ Resources: Resources, ErrorePercorsoNonTrovato %>'
                    ValidationGroup="SalvaImpostazioniAreaDocumentale" OnServerValidate="PathValidator_ServerValidate" runat="server"></asp:CustomValidator>
            </div>

            <div class="fieldSalvaImpostazioniAreaDocumentale buttonWrap">
                <asp:Button ID="SalvaImpostazioniAreaDocumentaleButton" Text='<%$ Resources: Resources, Salva %>' ValidationGroup="SalvaImpostazioniAreaDocumentale"
                    OnClick="SalvaImpostazioniAreaDocumentaleButton_Click" runat="server" />
            </div>
        </fieldset>
    </div>

    <div class="divField impostazioniNuoviClienti">
        <fieldset>
            <legend><asp:Literal Text='<%$ Resources: Resources, ImpostazioniNuoviClienti %>' runat="server"></asp:Literal></legend>

            <div class="fieldPartitaIvaObbligatoria">
                <asp:CheckBox ID="PartitaIvaObbligatoriaCheckbox" Text='<%$ Resources: Resources, PartitaIvaObbligatoria %>' runat="server" />
            </div>

            <div class="fieldCodiceFiscaleObbligatorio">
                <asp:CheckBox ID="CodiceFiscaleObbligatorioCheckBox" Text='<%$ Resources: Resources, CodiceFiscaleObbligatorio %>' runat="server" />
            </div>

            <div class="fieldAbiObbligatorio">
                <asp:CheckBox ID="AbiObbligatorioCheckBox" Text='<%$ Resources: Resources, AbiObbligatorio %>' runat="server" />
            </div>

            <div class="fieldCabObbligatorio">
                <asp:CheckBox ID="CabObbligatorioCheckBox" Text='<%$ Resources: Resources, CabObbligatorio %>' runat="server" />
            </div>

            <div class="fieldIbanObbligatorio">
                <asp:CheckBox ID="IbanObbligatorioCheckBox" Text='<%$ Resources: Resources, IbanObbligatorio %>' runat="server" />
            </div>

            <div class="fieldTelefonoObbligatorio">
                <asp:CheckBox ID="TelefonoObbligatorioCheckBox" Text='<%$ Resources: Resources, TelefonoObbligatorio %>' runat="server" />
            </div>

            <div class="fieldCapSedeLegaleObbligatorio">
                <asp:CheckBox ID="CapSedeLegaleObbligatorioCheckBox" Text='<%$ Resources: Resources, CapSedeLegaleObbligatorio %>' runat="server" />
            </div>

            <div class="fieldCapIndirizzoObbligatorio">
                <asp:CheckBox ID="CapIndirizzoObbligatorioCheckBox" Text='<%$ Resources: Resources, CapIndirizzoObbligatorio %>' runat="server" />
            </div>

            <div class="fieldSalvaImpostazioniNuoviClienti buttonWrap">
                <asp:Button ID="SalvaImpostazioniNuoviClientiButton" Text='<%$ Resources: Resources, Salva %>' ValidationGroup="SalvaImpostazioniNuoviClienti"
                    OnClick="SalvaImpostazioniNuoviClientiButton_Click" runat="server" />
            </div>
        </fieldset>
    </div>

    <asp:ValidationSummary ID="ImpostazioniNuoviOrdiniValidationSummary" ValidationGroup="SalvaImpostazioniNuoviOrdini" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' runat="server" />

    <div class="divField impostazioniNuoviOrdini">
        <fieldset>
            <legend><asp:Literal Text='<%$ Resources: Resources, ImpostazioniNuoviOrdini %>' runat="server"></asp:Literal></legend>

            <div class="fieldNascondiSconto">
                <asp:CheckBox ID="NascondiScontoCheckBox" Text='<%$ Resources: Resources, NascondiSconto %>' runat="server" />
            </div>

            <div class="fieldMostraPdfArticoli">
                <asp:CheckBox ID="MostraPdfArticoliCheckBox" Text='<%$ Resources: Resources, MostraPdfArticoli %>' runat="server" />
            </div>

            <div class="fieldCartellaPdfArticoli">
                <asp:Label AssociatedControlID="CartellaPdfArticoliTextBox" Text='<%$ Resources: Resources, CartellaPdfArticoli %>' runat="server"></asp:Label>
                <asp:TextBox ID="CartellaPdfArticoliTextBox" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="CartellaPdfArticoliValidator" ControlToValidate="CartellaPdfArticoliTextBox" Text='<%$ Resources: Resources, ErrorePercorsoNonTrovato %>'
                    ValidationGroup="SalvaImpostazioniNuoviOrdini" OnServerValidate="PathValidator_ServerValidate" runat="server"></asp:CustomValidator>
            </div>

            <div class="fieldSalvaImpostazioniNuoviClienti buttonWrap">
                <asp:Button ID="SalvaImpostazioniNuoviOrdiniButton" Text='<%$ Resources: Resources, Salva %>' ValidationGroup="SalvaImpostazioniNuoviOrdini"
                    OnClick="SalvaImpostazioniNuoviOrdiniButton_Click" runat="server" />
            </div>
        </fieldset>
    </div>
</asp:Content>
