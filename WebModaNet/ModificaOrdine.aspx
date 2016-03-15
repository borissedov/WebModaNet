<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificaOrdine.aspx.cs" Inherits="EW.WebModaNet.ModificaOrdine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="ModificaOrdineLiteral" runat="server"></asp:Literal>
    </h2>

    <script type="text/javascript">
        // indica che devono essere attivati gli script per la pagina di modifica dell'ordine
        window.isModificaOrdine = true;

        // imposta una variabile che indica se nascondere gli sconti
        window.nascondiSconto = <%= ImpostazioniGenerali.NascondiSconto ? "true" : "false" %>;
    </script>

    <div class="pulsantiera">
        <asp:HyperLink ID="ModificaTestataLink" CssClass="pulsante linkInsNuovo" NavigateUrl="~/InserisciModificaCliente.aspx" Text='<%$ Resources: Resources, ModificaTestata %>' runat="server"></asp:HyperLink>
    </div>

    <div id="tabs">
        <ul>
		    <li>
                <asp:HyperLink ID="ImpostazioniOrdineLink" Text='<%$ Resources: Resources, InserimentoArticoli %>'
                    NavigateUrl="#tabs-1" AccessKey="I" runat="server"></asp:HyperLink>
            </li>
		    <li>
                <asp:HyperLink ID="RiepilogoLink" Text='<%$ Resources: Resources, Riepilogo %>'
                    NavigateUrl="#tabs-2" AccessKey="R" runat="server"></asp:HyperLink>
            </li>
	    </ul>

        <div id="tabs-1">
            <div class="divField divFieldRicerca impostazioniOrdine">
                <fieldset>
                    <legend>
                        <asp:Literal ID="ImpostazioniOrdineLiteral" Text='<%$ Resources: Resources, ImpostazioniOrdine %>' runat="server"></asp:Literal>
                    </legend>

                    <div class="impostazioniStaticheOrdine" id="divImpostazioniStaticheOrdine" runat="server">
                        <div class="fieldTipoOrdine literal">
                            <strong><asp:Literal ID="TipoOrdineLabelLiteral" Text='<%$ Resources: Resources, TipoOrdine %>' runat="server"></asp:Literal>:</strong>
                            <asp:Literal ID="TipoOrdineLiteral" runat="server"></asp:Literal>
                        </div>

                        <div class="fieldMarchio literal">
                            <strong><asp:Literal ID="MarchioLabelLiteral" Text='<%$ Resources: Resources, Marchio %>' runat="server"></asp:Literal>:</strong>
                            <asp:Literal ID="MarchioLiteral" runat="server"></asp:Literal>
                        </div>

                        <div class="fieldCodiceListino literal">
                            <strong><asp:Literal ID="CodiceListinoLabelLiteral" Text='<%$ Resources: Resources, Tipologia %>' runat="server"></asp:Literal>:</strong>
                            <asp:Literal ID="CodiceListinoLiteral" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <!--
                        Pannello filtri
                        -->
                    <div class="filtriOrdine">
                        <div class="perc100">
                            <div class="fieldStagione">
                                <asp:Label ID="StagioneLabel" AssociatedControlID="StagioniList" Text='<%$ Resources: Resources, Stagione %>' runat="server"></asp:Label>
                                <asp:DropDownList ID="StagioniList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="StagioniList_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TutteLista %>'></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        
                            <div class="fieldLinea">
                                <asp:Label ID="LineaLabel" AssociatedControlID="LineeList" Text='<%$ Resources: Resources, Linea %>' runat="server"></asp:Label>
                                <asp:DropDownList ID="LineeList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="LineeList_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="fieldGruppo" id="divGruppo" runat="server">
                                <asp:Label ID="GruppoLabel" AssociatedControlID="GruppiList" Text='<%$ Resources: Resources, Gruppo %>' runat="server"></asp:Label>
                                <asp:DropDownList ID="GruppiList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="GruppiList_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="fieldFamiglia">
                                <asp:Label ID="FamigliaLabel" AssociatedControlID="FamiglieList" Text='<%$ Resources: Resources, Famiglia %>' runat="server"></asp:Label>
                                <asp:DropDownList ID="FamiglieList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="FamiglieList_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="fieldTessuto" id="divTessuto" runat="server">
                                <asp:Label ID="TessutoLabel" AssociatedControlID="TessutiList" Text='<%$ Resources: Resources, Tessuto %>' runat="server"></asp:Label>
                                <asp:DropDownList ID="TessutiList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="TessutiList_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="fieldGenere" id="divGeneri" runat="server">
                                <asp:Label ID="GenereLabel" AssociatedControlID="GeneriList" Text='<%$ Resources: Resources, Genere %>' runat="server"></asp:Label>
                                <asp:DropDownList ID="GeneriList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="GeneriList_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                            </div>
                            
                        </div>

                        <div class="perc100">
                            <div class="fieldBanner1" id="divBanner1" runat="server">
                                <asp:Label ID="lblBanner1" AssociatedControlID="Banner1List"  runat="server"></asp:Label>
                                <asp:DropDownList ID="Banner1List" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="BannerList_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="fieldBanner2" id="divBanner2" runat="server">
                                <asp:Label ID="lblBanner2" AssociatedControlID="Banner2List"  runat="server"></asp:Label>
                                <asp:DropDownList ID="Banner2List" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="BannerList_SelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <!--
                        Pannello date consegna
                        -->
                    <asp:Panel ID="DateConsegnaPanel" CssClass="dateConsegna" runat="server">
                        <fieldset>
                            <legend>
                                <asp:Literal ID="DateConsegnaLiteral" Text='<%$ Resources: Resources, DateConsegna %>' runat="server"></asp:Literal>
                            </legend>

                            <div class="fieldDataConsegna">
                                <asp:Label ID="DataConsegnaLabel" AssociatedControlID="DataConsegnaTextBox" Text='<%$ Resources: Resources, DataConsegna %>' runat="server"></asp:Label>
                                <asp:RequiredFieldValidator ID="DataConsegnaValidator" ControlToValidate="DataConsegnaTextBox" ValidationGroup="ConfermaQuantita"
                                    ErrorMessage='<%$ Resources: Resources, DataConsegna %>' runat="server"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="DataConsegnaCustomValidator" ControlToValidate="DataConsegnaTextBox" ValidationGroup="ConfermaQuantita"
                                    OnServerValidate="DataCustomValidator_ServerValidate" runat="server"></asp:CustomValidator>
                                <asp:TextBox ID="DataConsegnaTextBox" CssClass="date" runat="server"></asp:TextBox>
                            </div>

                            <div class="fieldDataUltimaConsegna" id="divDataUltimaConsegna" runat="server">
                                <asp:Label ID="DataUltimaConsegnaLabel" AssociatedControlID="DataUltimaConsegnaTextBox" Text='<%$ Resources: Resources, DataUltimaConsegna %>' runat="server"></asp:Label>
                                <asp:RequiredFieldValidator ID="DataUltimaConsegnaValidator" ControlToValidate="DataUltimaConsegnaTextBox" ValidationGroup="ConfermaQuantita"
                                    ErrorMessage='<%$ Resources: Resources, DataUltimaConsegna %>' runat="server"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="DataUltimaConsegnaCustomValidator" ControlToValidate="DataUltimaConsegnaTextBox" ValidationGroup="ConfermaQuantita"
                                    OnServerValidate="DataCustomValidator_ServerValidate" runat="server"></asp:CustomValidator>
                                <asp:TextBox ID="DataUltimaConsegnaTextBox" CssClass="date" runat="server"></asp:TextBox>
                            </div>

                            <div class="fieldDataDecorrenza" id="divDataDecorrenza" runat="server">
                                <asp:Label ID="DataDecorrenzaLabel" AssociatedControlID="DataDecorrenzaTextBox" Text='<%$ Resources: Resources, DataDecorrenza %>' runat="server"></asp:Label>
                                <asp:RequiredFieldValidator ID="DataDecorrenzaValidator" ControlToValidate="DataDecorrenzaTextBox" ValidationGroup="ConfermaQuantita"
                                    ErrorMessage='<%$ Resources: Resources, DataDecorrenza %>' runat="server"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="DataDecorrenzaCustomValidator" ControlToValidate="DataDecorrenzaTextBox" ValidationGroup="ConfermaQuantita"
                                    OnServerValidate="DataCustomValidator_ServerValidate" runat="server"></asp:CustomValidator>
                                <asp:TextBox ID="DataDecorrenzaTextBox" CssClass="date" runat="server"></asp:TextBox>
                            </div>
                        </fieldset>
                    </asp:Panel>
                </fieldset>
            </div>
            
            <div class="ricercaInsArticolo">

                <!--
                    Pannello ricerca articoli
                    -->
                <asp:Panel ID="ArticoliPanel" CssClass="divField divFieldRicerca articoli" DefaultButton="CercaPerCodiceButton" runat="server">
                    <fieldset>
                        <legend>
                            <asp:Literal ID="ArticoliLiteral" Text='<%$ Resources: Resources, Articoli %>' runat="server"></asp:Literal>
                        </legend>

                        
                        <p id="nessunArticolo" class="warning" visible="false" runat="server">
                            <asp:Literal ID="ArticoloNonTrovatoLiteral" Text='<%$ Resources: Resources, ErroreArticoloNonTrovato %>' runat="server"></asp:Literal>
                        </p>

                        <div class="fieldCodiceArticolo">
                            <asp:Label ID="CodiceArticoloLabel" AssociatedControlID="CodiceArticoloTextBox" Text='<%$ Resources: Resources, CodiceArticoloBarcode %>' runat="server"></asp:Label>
                            <asp:TextBox ID="CodiceArticoloTextBox" CssClass="codiceArticolo autoselect" runat="server"></asp:TextBox>
                            <asp:Button ID="CercaPerCodiceButton" Text='<%$ Resources: Resources, CercaPerCodice %>' ValidationGroup="CercaPerCodice" CssClass="cercaPerCodice" OnClick="CercaPerCodiceButton_Click" runat="server" />
                        </div>

                        <div class="checkQuantZero">    
                            <asp:CheckBox ID="NascondiQuantitaZeroCheckBox" AutoPostBack="true" Text='<%$ Resources: Resources, NascondiQuantitaZero %>'
                                AccessKey="N" OnCheckedChanged="NascondiQuantitaZeroCheckBox_CheckedChanged" Checked="false" runat="server" />
                        </div>

                        <asp:Panel ID="ListaArticoliPanel" CssClass="fieldArticolo perc100" runat="server">
                            <asp:Label ID="ArticoloLabel" AssociatedControlID="ArticoliList" Text='<%$ Resources: Resources, Articolo %>' runat="server"></asp:Label>
                            <asp:DropDownList ID="ArticoliList" DataValueField="Codice" DataTextField="DescrizioneCompleta" AutoPostBack="true" AppendDataBoundItems="true"
                                CausesValidation="true" ValidationGroup="ConfermaArticolo" CssClass="listaArticoli" size="8" OnSelectedIndexChanged="ArticoliList_SelectedIndexChanged" OnPreRender="ArticoliList_OnPreRender" runat="server">
                            </asp:DropDownList>
                        </asp:Panel>
                    </fieldset>
                </asp:Panel>
			
                <asp:Panel ID="ImmaginiPanel" CssClass="immaginiPanel" runat="server">
                    <div class="mostraNascondiImmagini" id="divMostraNascondiImmagini" runat="server">
                        <asp:LinkButton ID="MostraNascondiImmaginiButton" Text='<%# MostraNascondiImmaginiLabel %>' CssClass="mostra"
                           AccessKey="M" OnClick="MostraNascondiImmaginiButton_Click" OnPreRender="MostraNascondiImmaginiButton_PreRender" runat="server"></asp:LinkButton>
                    </div>

                    <p id="nessunaImmagineTrovata" class="warning" runat="server">
                        <asp:Literal ID="NessunaImmagineTrovataLiteral" Text='<%$ Resources: Resources, ErroreNessunaImmagineTrovata %>' runat="server"></asp:Literal>
                    </p>
                    <p id="troppiArticoli" class="warning" visible="false" runat="server">
                        <asp:Literal ID="TroppiArticoloLiteral" Text='<%$ Resources: Resources, TroppiArticoli %>' runat="server"></asp:Literal>
                    </p>

                    <asp:Repeater ID="ImmaginiRepeater" OnItemCommand="ImmaginiRepeater_ItemCommand" runat="server">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li id="immagineListItem" runat="server">
                                <asp:HiddenField ID="CodiceHiddenField" Value='<%# Eval("CodiceArticolo") %>' runat="server" />
                                <asp:LinkButton ID="ImmagineArticoloButton" CommandArgument='<%# Eval("CodiceArticolo") %>' CssClass="immagineArticolo" runat="server">
                                    <asp:Image ID="ImmagineArticoloImage" ImageUrl='<%# Eval("ImageUrl") %>' AlternateText='<%# Eval("AlternateText") %>' runat="server" CssClass="ArticoloImage" />
                                </asp:LinkButton>
                                <div>
                                    <asp:HyperLink ID="ImmagineArticoloLink" NavigateUrl='<%# Eval("ZoomUrl") %>' Text="&nbsp;" ToolTip='<%# Eval("AlternateText") %>'
                                        CssClass="nyroModal zoomArticolo" data-codiceArticolo='<%# Eval("CodiceArticolo") %>' rel="gal" runat="server">
                                    </asp:HyperLink>
                                </div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </asp:Panel>
		    </div>

            <p id="erroreListino" class="error" enableviewstate="false" visible="false" runat="server">
                <asp:Literal ID="ErroreListinoLiteral" runat="server"></asp:Literal>
            </p>
            <p id="messaggioSuperamentoDisponibilita" class="warning" enableviewstate="false" visible="false" runat="server">
                <asp:Literal ID="messaggioSuperamentoDisponibilitaLiteral" Text='<%$ Resources: Resources, WarningDisponibilitaSuperata %>' runat="server"></asp:Literal>
            </p>
            <p id="messaggioConfermaInserimento" class="success" enableviewstate="false" visible="false" runat="server">
                <asp:Literal ID="MessaggioConfermaInserimentoLiteral" runat="server"></asp:Literal>
            </p>

            <!--
                Pannello di dettaglio di un singolo articolo
                -->
            <asp:Panel ID="DettaglioArticoloPanel" Visible="false" DefaultButton="ConfermaButton" runat="server">
                <h3>
                    <asp:Literal ID="ArticoloLiteral" runat="server"></asp:Literal>
                </h3>

                <asp:Panel ID="PdfArticoloPanel" CssClass="pulsantiera" runat="server">
                    <asp:HyperLink ID="PdfArticoloLink" Text='<%$ Resources: Resources, ScaricaPdfArticolo %>' Target="_blank" CssClass="pulsante linkScaricaPdf" runat="server"></asp:HyperLink>
                </asp:Panel>

                <asp:HiddenField ID="CodiceArticoloHiddenField" runat="server" />
                <table class="prezziConferma">
                    <tr>
                        <td>
                             <div class="tabellaPrezziMsg">
                    
                                <!--
                                    Tabella dei prezzi
                                    -->
                                <table class="tabellaPrezzi">
                                    <thead>
                                        <tr>
                                            <th>
                                                <asp:Literal ID="IntestazionePrezzoAcquistoLiteral" Text='<%$ Resources: Resources, PrezziAcquisto %>' runat="server"></asp:Literal>
                                            </th>
                                            <th class="<%= HiddenClassName %>">
                                                <asp:Literal ID="IntestazionePrezzoConsigliatoLiteral" Text='<%$ Resources: Resources, PrezzoConsigliato %>' runat="server"></asp:Literal>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="PrezziRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class='<%# Eval("ClasseCssAcquisto") %>'>
                                                        <asp:Literal ID="PrezzoAcquistoLiteral1" Text='<%# Eval("PrezzoAcquistoFormattato") %>' runat="server"></asp:Literal>
                                                    </td>
                                                    <td class='<%# Eval("ClasseCssConsigliato") %>'>
                                                        <asp:Literal ID="PrezzoConsigliatoLiteral1" Text='<%# Eval("PrezzoConsigliatoFormattato") %>' runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>

                                <!--
                                    Messaggio che riporta la quantità minima da inserire
                                    -->
                                <div id="messaggioQuantitaConfezione" class="info msgOrdineMin" runat="server"></div>
                            </div>
                        </td>
                        <td class="tdDx">
                            <div class="buttonWrap">
                                <asp:Button ID="ConfermaUpButton" Text="Conferma" ValidationGroup="ConfermaQuantita" CssClass="confermaQuantita" data-confirm='<%$ Resources: Resources, MessaggioQuantitaNonCongruenti %>' OnClick="ConfermaButton_Click" runat="server" />
                            </div>
                        </td>
                    </tr>
                </table>
                
                <asp:CustomValidator ID="ConfermaQuantitaValidator" ValidationGroup="ConfermaQuantita" ErrorMessage='<%$ Resources: Resources, ErroreQuantitaZero %>'
                    CssClass="validation-error error" OnServerValidate="ConfermaQuantitaValidator_ServerValidate" runat="server"></asp:CustomValidator>

                <asp:CustomValidator ID="ImballiCustomValidator" ValidationGroup="ConfermaQuantita" ErrorMessage='<%$ Resources: Resources, ErroreQuantitaImballi %>'
                    CssClass="validation-error error" OnServerValidate="ImballiCustomValidator_ServerValidate" runat="server"></asp:CustomValidator>
                
                <table class="tabellaQuantita tabellaLista fixedHeader">
                    <thead>
                        <tr>
                            <th colspan="2">
                                <asp:Literal ID="IntestazioneVarianteLiteral" Text='<%$ Resources: Resources, Variante %>' runat="server"></asp:Literal>
                            </th>
                            <th>
                                <asp:Literal ID="IntestazioneDuplicaLiteral" Text='<%$ Resources: Resources, Duplica %>' runat="server"></asp:Literal>
                            </th>
                            <th id="intestazioneCodiceImballo" runat="server">
                                <asp:Literal ID="IntestazioneCodiceImballoLiteral" Text='<%$ Resources: Resources, CodiceImballo %>' runat="server"></asp:Literal>
                            </th>
                            <th id="intestazioneQuantitaImballo" runat="server">
                                <asp:Literal ID="IntestazioneQuantitaImballoLiteral" Text='<%$ Resources: Resources, QuantitaImballo %>' runat="server"></asp:Literal>
                            </th>
                            <asp:Repeater ID="IntestazioniTaglieRepeater" OnItemDataBound="IntestazioniTaglieRepeater_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <th><%# Eval("Descrizione") %></th>
                                </ItemTemplate>
                            </asp:Repeater>
                            <th>
                                <asp:Literal ID="CopiaIncollaLiteral" Text='<%$ Resources: Resources, CopiaIncolla %>' runat="server"></asp:Literal>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="VariantiRepeater" OnItemDataBound="VariantiRepeater_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="tdIcona">
                                        <asp:Image ID="ImmagineVarianteImage" runat="server" />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="CodiceVarianteHiddenField" runat="server" />
                                        <asp:Literal ID="DescrizioneCompletaLiteral" runat="server"></asp:Literal>
                                    </td>

                                    <!-- bottone duplica -->
                                    <td class="tdIcona">
                                        <input type="image" src="Images/duplicate.png" class="duplicate" alt='<%$ Resources: Resources, Duplica %>' title='<%$ Resources: Resources, Duplica %>' tabindex="-1" runat="server" />
                                    </td>

                                    <!-- codice imballo -->
                                    <td id="cellaCodiceImballo" class="cellaCodiceImballo" runat="server">
                                       <asp:Label ID="CodiceImballoLabel" CssClass="codiceImballo" runat="server"></asp:Label>
                                    </td>

                                    <!-- quantita imballo -->
                                    <td id="cellaQuantitaImballo" runat="server">
                                        <asp:PlaceHolder ID="QuantitaImballoPlaceHolder" runat="server">
                                            <asp:TextBox ID="QuantitaImballoTextBox" CssClass="quantitaImballo autoselect" size="3" MaxLength="3" Text="0" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="SviluppoImballoHiddenField" runat="server" />
                                            <input type="button" value="-" class="subtractImballo" tabindex="-1" />
                                            <input type="button" value="+" class="addImballo" tabindex="-1" />
                                        </asp:PlaceHolder>
                                    </td>

                                    <!--
                                        Lista delle quantità per variante
                                        -->
                                    <asp:Repeater ID="QuantitaRepeater" OnItemDataBound="QuantitaRepeater_ItemDataBound" runat="server">
                                        <ItemTemplate>
                                            <td class="cellaQuantita">
                                                <div class="inputQuantita">
                                                    <asp:TextBox ID="QuantitaTextBox" CssClass="quantity" Text='<%# Eval("QuantitaInserita") %>' MaxLength="6" runat="server"></asp:TextBox>
                                                </div>

                                                <div id="boxPulsanti" class="footerQuantita" runat="server">
                                                    <input type="hidden" id="quantitaDisponibileHiddenField" class="max" runat="server" />
                                                    <input type="hidden" id="quantitaConfezioneHiddenField" class="pack" runat="server" />
                                                    <input type="button" class="subtract" value="-" tabindex="-1" />
                                                    <input type="button" class="add" value="+" tabindex="-1" />
                                                    
                                                    <asp:Panel class="NotaAltreDisponibilita" ID="NotaAltreDisponibilitaPanel" runat="server">
                                                        <asp:panel runat="server" Visible="false" ID="DispEtichettaPanel"  CssClass="disponibilita">
                                                            Disp <br />
                                                        </asp:panel>
                                                        <asp:Label ID="DisponibilitaLabel" CssClass="disponibilita" runat="server" ToolTip='<%$ Resources: Resources, Disponibilita %>'></asp:Label>
                                                        <asp:Image ID="DisponibilitaImg" CssClass="disponibilita" runat="server" /><br /><br />
                                                       <asp:Label ID="NotaLabel" CssClass="nota" runat="server"></asp:Label>
                                                    </asp:Panel>
                                                </div>

                                                <% if (EW.WebModaNet.Code.WebConfigSettings.ControlliDiValidazioneAttivati) { %>
                                                <p class="testoXS">
                                                    <asp:RequiredFieldValidator ID="QuantitaValidator" ControlToValidate="QuantitaTextBox" ValidationGroup="ConfermaQuantita"
                                                        ErrorMessage='<%$ Resources: Resources, ErroreQuantitaObbligatoria %>' runat="server"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="QuantitaRegexValidator" ControlToValidate="QuantitaTextBox" ValidationExpression="\d+"
                                                        ValidationGroup="ConfermaQuantita" ErrorMessage='<%$ Resources: Resources, ErroreQuantitaNumerica %>' runat="server"></asp:RegularExpressionValidator>
                                                    <asp:CustomValidator ID="DisponibilitaCustomValidator" ControlToValidate="QuantitaTextBox" ValidationGroup="ConfermaQuantita"
                                                        OnServerValidate="DisponibilitaCustomValidator_ServerValidate" runat="server"></asp:CustomValidator>
                                                    <asp:CustomValidator ID="QuantitaConfezioneCustomValidator" ControlToValidate="QuantitaTextBox" ValidationGroup="ConfermaQuantita"
                                                        OnServerValidate="QuantitaConfezioneCustomValidator_ServerValidate" runat="server"></asp:CustomValidator>
                                                </p>
                                                <% } %>
                                            </td>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <td class="tdIcona">
                                        <!-- bottone copia -->
                                        <input type="image" src="Images/copy.png" class="copy" alt='<%$ Resources: Resources, Copia %>' title='<%$ Resources: Resources, Copia %>' tabindex="-1" runat="server" />
                                        <!-- bottone incolla -->
                                        <input id="pasteButton" type="image" src="Images/paste.png" class="paste" alt='<%$ Resources: Resources, Incolla %>' title='<%$ Resources: Resources, Incolla %>' tabindex="-1" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

                <div class="buttonWrap">
                    <asp:Button ID="ConfermaButton" Text="Conferma" ValidationGroup="ConfermaQuantita" CssClass="confermaQuantita" data-confirm='<%$ Resources: Resources, MessaggioQuantitaNonCongruenti %>' OnClick="ConfermaButton_Click" runat="server" />
                </div>
            </asp:Panel>
        </div>

        <div id="tabs-2">
            <asp:Panel ID="RiepilogoPanel" runat="server">
                <h3>
                    <asp:Literal ID="RiepilogoLiteral" Text='<%$ Resources: Resources, Riepilogo %>' runat="server"></asp:Literal>
                </h3>

                <p id="messaggioAnnullamento" class="warning" visible="false" runat="server">
                    <asp:Literal ID="MessaggioAnnullamentoLiteral" Text='<%$ Resources: Resources, ErroreOrdineVuoto %>' runat="server"></asp:Literal>
                </p>

                <p id="messaggioValoreMinimoOrdine" class="warning" visible="false" runat="server"></p>

                <p id="ordineVuoto" class="error" visible="false" runat="server">
                    <asp:Literal ID="OrdineVuotoLiteral" Text='<%$ Resources: Resources, ErroreOrdineVuoto %>' runat="server"></asp:Literal>
                </p>

                <div class="infoRiepilogo">
                    <p>
                        <asp:Label ID="MetodoPagamentoLabel" Text='<%$ Resources: Resources, MetodoPagamento %>' runat="server"></asp:Label>:
                        <asp:Literal ID="MetodoPagamentoLiteral" runat="server"></asp:Literal>
                    </p>

                    <p>
                        <asp:Label ID="PortoLabel" Text='<%$ Resources: Resources, Porto %>' runat="server"></asp:Label>:
                        <asp:Literal ID="PortoLiteral" runat="server"></asp:Literal>
                    </p>

                    <p>
                        <asp:Label ID="TrasportoLabel" Text='<%$ Resources: Resources, Trasporto %>' runat="server"></asp:Label>:
                        <asp:Literal ID="TrasportoLiteral" runat="server"></asp:Literal>
                    </p>

                    <p>
                        <asp:Label ID="VettoreLabel" Text='<%$ Resources: Resources, Vettore %>' runat="server"></asp:Label>:
                        <asp:Literal ID="VettoreLiteral" runat="server"></asp:Literal>
                    </p>
                </div>

                <p id="nessunArticoloInserito" class="warning" visible="false" runat="server">
                    <asp:Literal ID="NessunArticoloInseritoLiteral" Text='<%$ Resources: Resources, ErroreNessunArticoloInserito %>' runat="server"></asp:Literal>
                </p>

                <asp:Panel ID="TabellaRiepilogoPanel" runat="server">
                    <table class="tabellaLista riepilogo fixedHeader">
                        <thead>
                            <tr>
                                <th>
                                    <asp:Literal ID="OperazioniLiteral" Text='<%$ Resources: Resources, Operazioni %>' runat="server"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="ArticoloRiepilogoLiteral" Text='<%$ Resources: Resources, Articolo %>' runat="server"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="VarianteRiepilogoLiteral" Text='<%$ Resources: Resources, Variante %>' runat="server"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="CodiciSegnataglieLiteral" runat="server"></asp:Literal>
                                </th>
                                <asp:Repeater ID="IntestazioniTaglieRiepilogoRepeater" runat="server">
                                    <ItemTemplate>
                                        <th>
                                            <%# Container.DataItem %>
                                        </th>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <th>
                                    <asp:Literal ID="NumeroCapiLiteral" Text='<%$ Resources: Resources, NumeroCapi %>' runat="server"></asp:Literal>
                                </th>
                                <th class="colonnaSconto">
                                    <asp:Literal ID="PrezzoAcquistoLiteral" Text='<%$ Resources: Resources, PrezzoAcquisto %>' runat="server"></asp:Literal>
                                    <asp:Literal ID="litValutaOrdinePR1" runat="server"></asp:Literal>
                                </th>
                                <th class="colonnaSconto">
                                    <asp:Literal ID="ScontoIntestazioneRiepilogoLiteral" Text='<%$ Resources: Resources, Sconto %>' runat="server"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="PrezzoNettoIntestazioneRiepilogoLiteral" Text='<%$ Resources: Resources, PrezzoNetto %>' runat="server"></asp:Literal>
                                    <asp:Literal ID="litValutaOrdinePR2" runat="server"></asp:Literal>
                                </th>
                                <th>
                                    <asp:Literal ID="ImportoLiteral" Text='<%$ Resources: Resources, Importo %>' runat="server"></asp:Literal>
                                    <asp:Literal ID="litValutaOrdinePR3" runat="server"></asp:Literal>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RiepilogoRepeater" OnItemDataBound="RiepilogoRepeater_ItemDataBound" OnItemCommand="RiepilogoRepeater_ItemCommand" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="tdIcona">
                                            <asp:ImageButton ID="EliminaButton" CommandName="EliminaDettaglio" CommandArgument='<%# Eval("IdDettaglio") %>'
                                                ImageUrl="~/Images/delete.png" AlternateText='<%$ Resources: Resources, Elimina %>' CssClass="confirm"
                                                data-message='<%$ Resources: Resources, MessaggioConferma %>' ToolTip='<%$ Resources: Resources, Elimina %>' runat="server" />
                                            <asp:ImageButton ID="ModificaButton" CommandName="ModificaDettaglio" CommandArgument='<%# Eval("IdDettaglio") %>'
                                                ImageUrl="~/Images/edit.png" AlternateText='<%$ Resources: Resources, Modifica %>'
                                                ToolTip='<%$ Resources: Resources, Modifica %>' runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="ArticoloLabel" Text='<%# Eval("CodiceArticolo") %>' ToolTip='<%# Eval("DescrizioneArticolo") %>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="VarianteLabel" Text='<%# Eval("CodiceVariante") %>' ToolTip='<%# Eval("DescrizioneArticolo") %>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Literal ID="SegnataglieLiteral" Text='<%# Eval("CodiceSegnataglie") %>' runat="server"></asp:Literal>
                                        </td>
                                        <asp:Repeater ID="QuantitaRepeater" runat="server">
                                            <ItemTemplate>
                                                <td>
                                                    <asp:Literal ID="QuantitaLiteral" Text='<%# Container.DataItem %>' runat="server"></asp:Literal>
                                                </td>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <td>
                                            <asp:Literal ID="NumeroCapiLiteral" Text='<%# Eval("NumeroCapi") %>' runat="server"></asp:Literal>
                                        </td>
                                        <td class="numValuta colonnaSconto">
                                            <asp:Literal ID="PrezzoAcquistoLiteral" runat="server"></asp:Literal>
                                        </td>
                                        <td class="colonnaSconto">
                                            <asp:Literal ID="ScontoLiteral" Text='<%# Eval("Sconto", "{0:0%}") != "0%" ? Eval("Sconto", "{0:0%}") : string.Empty %>' runat="server"></asp:Literal>
                                        </td>
                                        <td class="numValuta">
                                            <asp:Literal ID="PrezzoNettoLiteral" runat="server"></asp:Literal>
                                        </td>
                                        <td class="numValuta">
                                            <asp:Literal ID="ImportoLiteral" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr class="totale">
                                <td id="totale" runat="server">
                                    <asp:Literal ID="TotaleOrdineLiteral" Text='<%$ Resources: Resources, TotaleOrdine %>' runat="server"></asp:Literal>
                                </td>
                                <td style="text-align:center;">
                                    <asp:Literal ID="NumeroCapiOrdineLiteral" runat="server"></asp:Literal>
                                </td>
                                <td class="colonnaSconto">
                                    &nbsp;
                                </td>
                                <td class="colonnaSconto">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Literal ID="litValutaOrdinePR4" runat="server"></asp:Literal>
                                    <asp:Literal ID="TotaleAcquistoLiteral" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr id="rigaSconto" class="sconto" runat="server">
                                <td id="sconto" runat="server">
                                    <asp:Literal Text='<%$ Resources: Resources, Sconto %>' runat="server"></asp:Literal>
                                </td>
                                <td style="text-align:center;">
                                    <asp:Literal ID="ScontoLiteral" runat="server"></asp:Literal>
                                </td>
                                <td class="colonnaSconto">
                                    &nbsp;
                                </td>
                                <td class="colonnaSconto">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Literal ID="ImportoScontoLiteral" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr class="totaleNetto">
                                <td id="totaleNetto" runat="server">
                                    <asp:Literal ID="TotaleOrdineNettoLiteral" Text='<%$ Resources: Resources, TotaleNettoOrdine %>' runat="server"></asp:Literal>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="colonnaSconto">
                                    &nbsp;
                                </td>
                                <td class="colonnaSconto">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Literal ID="litValutaOrdinePR5" runat="server"></asp:Literal>
                                    <asp:Literal ID="TotaleAcquistoNettoLiteral" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>

                <div>
                    <asp:Label ID="IndirizzoConsegnaLabel" AssociatedControlID="IndirizziConsegnaDropDownList" Text='<%$ Resources: Resources, ConfermaIndirizzo %>' runat="server"></asp:Label>
                    <asp:DropDownList ID="IndirizziConsegnaDropDownList" DataValueField="Codice" DataTextField="Descrizione" runat="server"></asp:DropDownList>
                </div>

                <div class="pulsantiera">
                    <asp:LinkButton ID="EliminaOrdineButton" Text='<%$ Resources: Resources, EliminaOrdine %>' ToolTip='<%$ Resources: Resources, EliminaOrdine %>'
                        CssClass="pulsante linkEliminaOrdine confirm" data-message='<%$ Resources: Resources, MessaggioConfermaEliminaOrdine %>' 
                        OnClick="EliminaOrdineButton_Click" runat="server"></asp:LinkButton>

                    <asp:LinkButton ID="ChiudiOrdineButton"  Text='<%$ Resources: Resources, ChiudiOrdine %>' ToolTip='<%$ Resources: Resources, ChiudiOrdine %>'
                        CssClass="pulsante linkChiudiOrdine confirm" data-message='<%$ Resources: Resources, MessaggioConferma %>' AccessKey="C"
                        OnClick="ChiudiOrdineButton_Click" runat="server"></asp:LinkButton>

                    <div class="sospendiOrdine">
                        <asp:CheckBox ID="SospendiOrdineCheckBox" Text='<%$ Resources: Resources, SospendiOrdine %>' AccessKey="S" runat="server" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
