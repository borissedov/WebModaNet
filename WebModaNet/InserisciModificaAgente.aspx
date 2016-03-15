<%@ Page Title='<%$ Resources: Resources, InserisciNuovoAgente %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserisciModificaAgente.aspx.cs" Inherits="EW.WebModaNet.InserisciModificaAgente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, InserisciNuovoAgente %>' runat="server"></asp:Literal>
    </h2>

    <div class="pulsantiera">
        <asp:HyperLink ID="TornaIndietroLink" CssClass="pulsante linkTorna" NavigateUrl="~/Agenti.aspx" Text='<%$ Resources: Resources, TornaElencoAgenti %>' runat="server"></asp:HyperLink>
    </div>

    <asp:ValidationSummary ID="MainValidationSummary" ValidationGroup="SalvaAgente" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>' runat="server" />

    <p id="messaggioSuccesso" class="success" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="MessaggioSuccessoLiteral" runat="server"></asp:Literal>
    </p>

    <div id="tabs">
        <ul>
		    <li>
                <asp:HyperLink ID="ImpostazioniGeneraliLiteralLink" Text='<%$ Resources: Resources, ImpostazioniGenerali %>'
                    NavigateUrl="#tabs-1" runat="server"></asp:HyperLink>
            </li>
		    <li>
                <asp:HyperLink ID="ImpostazioniPredefiniteLink" Text='<%$ Resources: Resources, ImpostazioniClientiNuovi %>'
                    NavigateUrl="#tabs-2" runat="server"></asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="BlocchiLink" Text='<%$ Resources: Resources, ImpostazioniBlocchi %>'
                    NavigateUrl="#tabs-3" runat="server"></asp:HyperLink>
            </li>
		    <li>
                <asp:HyperLink ID="ImpostazioniOrdiniLink" Text='<%$ Resources: Resources, ImpostazioniOrdini %>'
                    NavigateUrl="#tabs-4" runat="server"></asp:HyperLink>
            </li>
	    </ul>

        <div id="tabs-1" class="divField impostazioniGenerali">
            <fieldset>
                <legend>
                    <asp:Literal ID="ImpostazioniGeneraliLiteral" Text='<%$ Resources: Resources, ImpostazioniGenerali %>' runat="server"></asp:Literal>
                </legend>

                <div class="fieldNomeUtente">
                    <asp:Label ID="NomeUtenteLabel" AssociatedControlID="NomeUtenteTextBox" Text='<%$ Resources: Resources, User %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="NomeUtenteValidator" ControlToValidate="NomeUtenteTextBox"
                        ErrorMessage='<%$ Resources: Resources, User %>' ValidationGroup="SalvaAgente" runat="server"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="NomeUtenteCustomValidator" ErrorMessage='<%$ Resources: Resources, ErroreUserEsistente %>' ValidationGroup="SalvaAgente"
                        OnServerValidate="NomeUtenteCustomValidator_ServerValidate" runat="server"></asp:CustomValidator>
                    <asp:TextBox ID="NomeUtenteTextBox" MaxLength="10" runat="server"></asp:TextBox>
                </div>

                <div class="fieldRagioneSociale">
                    <asp:Label ID="RagioneSocialeLabel" AssociatedControlID="RagioneSocialeTextBox" Text='<%$ Resources: Resources, DescrizioneUser %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="RagioneSocialeValidator" ControlToValidate="RagioneSocialeTextBox"
                        ErrorMessage='<%$ Resources: Resources, DescrizioneUser %>' ValidationGroup="SalvaAgente" runat="server"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="RagioneSocialeTextBox" MaxLength="50" runat="server"></asp:TextBox>
                </div>

                <div class="fieldPassword">
                    <asp:Label ID="PasswordLabel" AssociatedControlID="PasswordTextBox" Text='<%$ Resources: Resources, Password %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="PasswordValidator" ControlToValidate="PasswordTextBox"
                        ErrorMessage='<%$ Resources: Resources, Password %>' ValidationGroup="SalvaAgente" runat="server"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="PasswordTextBox" MaxLength="10" runat="server"></asp:TextBox>
                </div>

                <div class="fieldCodiceAgente">
                    <asp:Label ID="CodiceAgenteLabel" AssociatedControlID="CodiceAgenteTextBox" Text='<%$ Resources: Resources, CodiceAgenteCliente %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="CodiceAgenteValidator" ControlToValidate="CodiceAgenteTextBox"
                        ErrorMessage='<%$ Resources: Resources, CodiceAgenteCliente %>' ValidationGroup="SalvaAgente" runat="server"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CodiceAgenteRegexValidator" ControlToValidate="CodiceAgenteTextBox" ValidationExpression="\d{1,10}"
                        ValidationGroup="SalvaAgente" runat="server"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="CodiceAgenteTextBox" MaxLength="10" runat="server"></asp:TextBox>
                </div>

                <div class="fieldNazione">
                    <asp:Label ID="NazioneLabel" AssociatedControlID="NazioniList" Text='<%$ Resources: Resources, Nazione %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="NazioneValidator" ControlToValidate="NazioniList"
                        ErrorMessage='<%$ Resources: Resources, Nazione %>' ValidationGroup="SalvaAgente" runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="NazioniList" AppendDataBoundItems="true" DataValueField="Codice" DataTextField="Descrizione" runat="server">
                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaNazioneLista %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="fieldLingua">
                    <asp:Label ID="LinguaLabel" AssociatedControlID="LingueList" Text='<%$ Resources: Resources, Lingua %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="LinguaValidator" ControlToValidate="LingueList"
                        ErrorMessage='<%$ Resources: Resources, Lingua %>' ValidationGroup="SalvaAgente" runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="LingueList" AppendDataBoundItems="true" DataValueField="Codice" DataTextField="Descrizione" runat="server">
                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaLinguaLista %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="fieldAttivo">
                    <asp:CheckBox ID="AttivoCheckBox" Text='<%$ Resources: Resources, Attivo %>' Checked="true" runat="server" />
                </div>
                
                <div class="fieldNumeroDecimali">
                    <label><asp:Label ID="NumeroDecimaliLabel" Text='<%$ Resources: Resources, NumeroDecimali %>' runat="server"></asp:Label></label>
                    <asp:RequiredFieldValidator ID="NumeroDecimaliValidator" ControlToValidate="NumeroDecimaliTextBox"
                        ErrorMessage='<%$ Resources: Resources, NumeroDecimali %>' ValidationGroup="SalvaAgente" runat="server"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="NumeroDecimaliRegexValidator" ControlToValidate="NumeroDecimaliTextBox" ValidationExpression="\d+"
                        ValidationGroup="SalvaAgente" ErrorMessage='<%$ Resources: Resources, NumeroDecimali %>' runat="server"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="NumeroDecimaliTextBox" Text="2" runat="server"></asp:TextBox>
                </div>
                
                <div class="fieldTipoAgente tabTipoAgente">
                    <asp:Label ID="TipoAgenteLabel" Text='<%$ Resources: Resources, TipoAgente %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="TipoAgenteValidator" ControlToValidate="TipiAgenteRadio"
                        ErrorMessage='<%$ Resources: Resources, TipoAgente %>' ValidationGroup="SalvaAgente" runat="server"></asp:RequiredFieldValidator>
                    <asp:RadioButtonList ID="TipiAgenteRadio" DataValueField="Codice" DataTextField="Descrizione" RepeatDirection="Horizontal" runat="server">
                    </asp:RadioButtonList>
                </div>

                <br style="clear: both" /><br />

                <div class="fieldUtilizzaOffline">
                    <asp:CheckBox ID="UtilizzaOfflineCheckBox" Text='<%$ Resources: Resources, UtilizzaOffline %>' runat="server" />
                </div>
                <div class="fieldMostraDisponibilitaIcona" id="divMostraDisponibilitaIcona" runat="server">
                    <asp:CheckBox ID="MostraDisponibilitaIconaCheckBox" Text='<%$ Resources: Resources, MostraDisponibilitaIcona %>' runat="server" />
                </div>
            </fieldset>
        </div>

        <div id="tabs-2" class="divField impostazioniClientiNuovi">
            <fieldset>
                <legend>
                    <asp:Literal ID="ImpostazioniPredefiniteLiteral" Text='<%$ Resources: Resources, ImpostazioniClientiNuovi %>' runat="server"></asp:Literal>
                </legend>

                <div class="perc100">
                    <div class="fieldListinoDefault">
                        <asp:Label ID="ListinoDefaultLabel" AssociatedControlID="ListiniDefaultList" Text='<%$ Resources: Resources, ListinoPredefinito %>' runat="server"></asp:Label>
                        <asp:DropDownList ID="ListiniDefaultList" AppendDataBoundItems="true" runat="server">
                            <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaListinoLista %>'></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div>
                        <asp:Label ID="MetodoPagamentoDefaultLabel" AssociatedControlID="MetodiPagamentoDefaultList" Text='<%$ Resources: Resources, MetodoPagamentoPredefinito %>' runat="server"></asp:Label>
                        <asp:DropDownList ID="MetodiPagamentoDefaultList" AppendDataBoundItems="true" DataValueField="Codice" DataTextField="DescrizioneCompleta" runat="server">
                            <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaMetodoPagamentoLista %>'></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="tabImpostazioni impListini">          
                    <h3>
                        <asp:Literal ID="ImpostazioniListini" Text='<%$ Resources: Resources, ImpostazioniListini %>' runat="server"></asp:Literal>
                    </h3>

                    <asp:Repeater ID="ListiniRepeater" OnItemDataBound="ListiniRepeater_ItemDataBound" runat="server">
                        <HeaderTemplate>
                            <table class="tabellaLista">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:Literal ID="ListinoLiteral" Text='<%$ Resources: Resources, Listino %>' runat="server"></asp:Literal>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ListiniDropDownList" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaListinoLista %>'></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
            	</div>

                <div class="tabImpostazioni impValute">
                    <h3>
                        <asp:Literal ID="ImpostazioniValuteLiteral" Text='<%$ Resources: Resources, ImpostazioniValute %>' runat="server"></asp:Literal>
                    </h3>

                    <asp:Repeater ID="ValuteRepeater" OnItemDataBound="ValuteRepeater_ItemDataBound" runat="server">
                        <HeaderTemplate>
                            <table class="tabellaLista">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:Literal ID="ValutaLiteral" Text='<%$ Resources: Resources, Valuta %>' runat="server"></asp:Literal>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ValuteDropDownList" DataValueField="Codice" DataTextField="Descrizione"
                                        AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaValutaLista %>'></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <div class="tabImpostazioni impPagamenti">
                    <h3>
                        <asp:Literal ID="ImpostazioniMetodiPagamentoLiteral" Text='<%$ Resources: Resources, ImpostazioniMetodiPagamento %>' runat="server"></asp:Literal>
                    </h3>

                    <asp:Repeater ID="MetodiPagamentoRepeater" OnItemDataBound="MetodiPagamentoRepeater_ItemDataBound" runat="server">
                        <HeaderTemplate>
                            <table class="tabellaLista">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:Literal ID="MetodoPagamentoLiteral" Text='<%$ Resources: Resources, MetodoPagamento %>' runat="server"></asp:Literal>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="MetodiPagamentoDropDownList" DataValueField="Codice" DataTextField="DescrizioneCompleta"
                                        AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaMetodoPagamentoLista %>'></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </fieldset>
        </div>

        <div id="tabs-3" class="divField impostazioniBlocchi">
            <fieldset>
                <legend>
                    <asp:Literal ID="ImpostazioniBlocchiLiteral" Text='<%$ Resources: Resources, ImpostazioniBlocchi %>' runat="server"></asp:Literal>
                </legend>

                <p class="info">
                    <asp:Literal ID="DescrizioneBlocchiLiteral" Text='<%$ Resources: Resources, DescrizioneBlocchi %>' runat="server"></asp:Literal>
                </p>

                <div>
                    <asp:CheckBox ID="BloccoMetodoPagamentoCheckBox" Text='<%$ Resources: Resources, BloccoMetodoPagamento %>' runat="server" />
                </div>

                <div>
                    <asp:CheckBox ID="BloccoBancaCheckBox" Text='<%$ Resources: Resources, BloccoBanca %>' runat="server" />
                </div>

                <div>
                    <asp:CheckBox ID="BloccoValutaCheckBox" Text='<%$ Resources: Resources, BloccoValuta %>' runat="server" />
                </div>

                <div>
                    <asp:CheckBox ID="BloccoPortoCheckBox" Text='<%$ Resources: Resources, BloccoPorto %>' runat="server" />
                </div>

                <div>
                    <asp:CheckBox ID="BloccoTrasportoCheckBox" Text='<%$ Resources: Resources, BloccoTrasporto %>' runat="server" />
                </div>

                <div>
                    <asp:CheckBox ID="BloccoVettoreCheckBox" Text='<%$ Resources: Resources, BloccoVettore %>' runat="server" />
                </div>

                <div>
                    <asp:CheckBox ID="BloccoDataOrdineCheckBox" Text='<%$ Resources: Resources, BloccoDataOrdine %>' runat="server" />
                </div>

                <div>
                    <asp:CheckBox ID="BloccoDateConsegnaCheckBox" Text='<%$ Resources: Resources, BloccoDateConsegna %>' runat="server" />
                </div>
            </fieldset>
        </div>

        <div id="tabs-4" class="divField impostazioniOrdini">
            <fieldset>
                <legend>
                    <asp:Literal ID="ImpostazioniOrdiniLiteral" Text='<%$ Resources: Resources, ImpostazioniOrdini %>' runat="server"></asp:Literal>
                </legend>

                <asp:Repeater ID="ImpostazioniOrdiniRepeater" OnItemDataBound="ImpostazioniOrdiniRepeater_ItemDataBound" runat="server">
                    <HeaderTemplate>
                        <table class="tabellaLista">
                            <thead>
                                <tr>
                                    <th>
                                        <asp:Literal ID="MarchioLiteral" Text='<%$ Resources: Resources, Marchio %>' runat="server"></asp:Literal>
                                    </th>
                                    <th>
                                        <asp:Literal ID="TipoOrdineLiteral" Text='<%$ Resources: Resources, TipoOrdine %>' runat="server"></asp:Literal>
                                    </th>
                                    <th>
                                        <asp:Literal ID="ListinoConsigliatoLiteral" Text='<%$ Resources: Resources, ListinoConsigliato %>' runat="server"></asp:Literal>
                                    </th>
                                    <th>
                                        <asp:Literal ID="ValoreMinimoLiteral" Text='<%$ Resources: Resources, ValoreMinimoOrdine %>' runat="server"></asp:Literal>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="rigaImpostazioneOrdine" runat="server">
                            <td>
                                <asp:DropDownList ID="MarchiList" DataValueField="Codice" DataTextField="DescrizioneCompleta"
                                    AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaMarchioLista %>'></asp:ListItem>
                                </asp:DropDownList>
                            </td>
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
                                <asp:TextBox ID="ValoreMinimoTextBox" Text='<%# Eval("ValoreMinimoOrdine", "{0:0}") %>' CssClass="autoselect" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                
                
				<div class="tabImpostazioni impStagioni">
                    <h3>
                        <asp:Literal ID="ImpostazioniStagioniLiteral" Text='<%$ Resources: Resources, ImpostazioniStagioni %>' runat="server"></asp:Literal>
                    </h3>

                    <asp:Repeater ID="StagioniRepeater" OnItemDataBound="StagioniRepeater_ItemDataBound" runat="server">
                        <HeaderTemplate>
                            <table class="tabellaLista">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:Literal ID="StagioneLiteral" Text='<%$ Resources: Resources, Stagione %>' runat="server"></asp:Literal>
                                        </th>
                                        <th>
                                            <asp:Literal ID="DisponibilitaLiteral" Text='<%$ Resources: Resources, Disponibilita %>' runat="server"></asp:Literal>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="StagioniDropDownList" DataValueField="Codice" DataTextField="DescrizioneCompleta"
                                        AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaStagioneLista %>'></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tdCheck">
                                    <asp:CheckBox ID="DisponibilitaCheckBox" runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </fieldset>
        </div>
    </div>

    <div class="buttonWrap">
        <asp:Button ID="SalvaButton" Text='<%$ Resources: Resources, Salva %>' ValidationGroup="SalvaAgente" OnClick="SalvaButton_Click" runat="server" />
    </div>
</asp:Content>
