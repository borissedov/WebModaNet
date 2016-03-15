<%@ Page Title='<%$ Resources: Resources, InserisciTestataOrdine %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserisciModificaTestata.aspx.cs" Inherits="EW.WebModaNet.InserisciModificaTestata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, InserisciTestataOrdine %>' runat="server"></asp:Literal>
    </h2>

    <asp:Panel ID="MessaggioTestataPanel" CssClass="pannelloMessaggi info" runat="server">
        <div class="info2">
            <asp:Literal ID="MessaggioTestataLiteral" Text='<%$ Resources: Resources, MessaggioInserisciTestata %>' runat="server"></asp:Literal>
        </div>
        <asp:HyperLink ID="NuovoClienteLink" CssClass="pulsante linkInsNuovo" NavigateUrl="~/InserisciModificaCliente.aspx"
            Text='<%$ Resources: Resources, NuovoCliente %>' runat="server"></asp:HyperLink>
    </asp:Panel>
		
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

    <p id="clienteBloccato" class="error" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="ClienteBloccatoLiteral" runat="server"></asp:Literal>
    </p>

    <asp:Panel ID="TestataPanel" Visible="false" DefaultButton="ConfermaTestataButton" runat="server">
        <div class="info">
            <asp:Literal ID="MessaggioConfermaTestataLiteral" Text='<%$ Resources: Resources, MessaggioConfermaTestata %>' runat="server"></asp:Literal>
        </div>

        <asp:ValidationSummary ID="MainValidationSummary" HeaderText='<%$ Resources: Resources, ErroriRiepilogo %>'
            ValidationGroup="ConfermaTestata" CssClass="validationSummary" runat="server" />

        <div class="divField datiCliente">
            <fieldset>
                <legend><asp:Literal ID="DatiClienteLiteral" Text='<%$ Resources: Resources, DatiCliente %>' runat="server"></asp:Literal></legend>

                <div class="fieldRagioneSociale literal">
                    <strong><asp:Literal ID="RagioneSocialeEtichettaLiteral" Text='<%$ Resources: Resources, RagioneSociale %>' runat="server"></asp:Literal>:</strong><br />
                    <asp:Literal ID="RagioneSocialeLiteral" runat="server"></asp:Literal>
                </div>

                <div class="fieldIndirizzo literal perc70">
                    <strong><asp:Literal ID="IndirizzoEtichettaLiteral" Text='<%$ Resources: Resources, IndirizzoPredefinito %>' runat="server"></asp:Literal>:</strong><br />
                    <asp:Literal ID="IndirizzoLiteral" runat="server"></asp:Literal>
                </div>
            </fieldset>
        </div>

        <div class="divField impostazioniAmministrative">
            <fieldset>
                <legend><asp:Literal ID="ImpostazioniAmministrativeLiteral" Text='<%$ Resources: Resources, ImpostazioniAmministrative %>' runat="server"></asp:Literal></legend>

                <div class="fieldBanca">
                    <asp:Label ID="BancaLabel" AssociatedControlID="BancaTextBox" Text='<%$ Resources: Resources, Banca %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="BancaValidator" ControlToValidate="BancaTextBox" ValidationGroup="ConfermaTestata"
                        ErrorMessage='<%$ Resources: Resources, Banca %>' Enabled="false" runat="server"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="BancaTextBox" runat="server"></asp:TextBox>
                </div>

                <div class="fieldValuta">
                    <asp:Label ID="ValutaLabel" AssociatedControlID="ValuteList" Text='<%$ Resources: Resources, Valuta %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="ValutaValidator" ControlToValidate="ValuteList" ValidationGroup="ConfermaTestata"
                        ErrorMessage='<%$ Resources: Resources, Valuta %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ValuteList" DataValueField="Codice" DataTextField="Descrizione" runat="server"></asp:DropDownList>
                </div>
            </fieldset>
        </div>

        <div class="divField impostazioniCommerciali">
            <fieldset>
                <legend><asp:Literal ID="ImpostazioniCommercialiLiteral" Text='<%$ Resources: Resources, ImpostazioniCommerciali %>' runat="server"></asp:Literal></legend>
            
                <div class="fieldPorto">
                    <asp:Label ID="PortoLabel" AssociatedControlID="PortiList" Text='<%$ Resources: Resources, Porto %>' runat="server"></asp:Label>
                    <asp:DropDownList ID="PortiList" DataValueField="Id" DataTextField="Descrizione" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="PortoValidator" ControlToValidate="PortiList" ValidationGroup="ConfermaTestata"
                        ErrorMessage='<%$ Resources: Resources, Porto %>' runat="server"></asp:RequiredFieldValidator>
                </div>

                <div class="fieldTrasporto">
                    <asp:Label ID="TrasportoLabel" AssociatedControlID="TrasportiList" Text='<%$ Resources: Resources, Trasporto %>' runat="server"></asp:Label>
                    <asp:DropDownList ID="TrasportiList" DataValueField="Id" DataTextField="Descrizione" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="TrasportoValidator" ControlToValidate="TrasportiList" ValidationGroup="ConfermaTestata"
                        ErrorMessage='<%$ Resources: Resources, Trasporto %>' runat="server"></asp:RequiredFieldValidator>
                </div>

                <div class="fieldVettore">
                    <asp:Label ID="VettoreLabel" AssociatedControlID="VettoriList" Text='<%$ Resources: Resources, Vettore %>' runat="server"></asp:Label>
                    <asp:DropDownList ID="VettoriList" DataValueField="Id" DataTextField="Descrizione" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="VettoreValidator" ControlToValidate="VettoriList" ValidationGroup="ConfermaTestata"
                        ErrorMessage='<%$ Resources: Resources, Vettore %>' runat="server"></asp:RequiredFieldValidator>
                </div>
            </fieldset>
        </div>

        <div class="divField impostazioniOrdine">
            <fieldset>
                <legend><asp:Literal ID="ImpostazioniOrdineLiteral" Text='<%$ Resources: Resources, ImpostazioniOrdine %>' runat="server"></asp:Literal></legend>

                <div class="fieldMarchio">
                    <asp:Label ID="MarchioLabel" AssociatedControlID="MarchiList" Text='<%$ Resources: Resources, Marchio %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="MarchioValidator" ControlToValidate="MarchiList" ValidationGroup="ConfermaTestata"
                        ErrorMessage='<%$ Resources: Resources, Marchio %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="MarchiList" DataValueField="Codice" DataTextField="Descrizione" AutoPostBack="true"
                        OnSelectedIndexChanged="MarchiList_SelectedIndexChanged" runat="server"></asp:DropDownList>
                </div>

                <div class="fieldTipoOrdine">
                    <asp:Label ID="TipoOrdineLabel" AssociatedControlID="TipiOrdineList" Text='<%$ Resources: Resources, TipoOrdine %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="TipoOrdineValidator" ControlToValidate="TipiOrdineList" ValidationGroup="ConfermaTestata"
                        ErrorMessage='<%$ Resources: Resources, TipoOrdine %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="TipiOrdineList" DataValueField="Id" DataTextField="Descrizione" runat="server"></asp:DropDownList>
                </div>

                <div class="fieldData">
                    <asp:Label ID="DataLabel" AssociatedControlID="DataTextBox" Text='<%$ Resources: Resources, Data %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="DataValidator" ControlToValidate="DataTextBox" ValidationGroup="ConfermaTestata"
                        ErrorMessage='<%$ Resources: Resources, Data %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="DataCustomValidator" ControlToValidate="DataTextBox" ValidationGroup="ConfermaTestata"
                        OnServerValidate="DataCustomValidator_ServerValidate" runat="server"></asp:CustomValidator>
                    <asp:TextBox ID="DataTextBox" CssClass="date" runat="server"></asp:TextBox>
                </div>

                <div class="fieldIndirizzoConsegna perc50">
                    <asp:Label ID="IndirizzoConsegnaLabel" AssociatedControlID="IndirizziConsegnaList" Text='<%$ Resources: Resources, IndirizzoConsegna %>' runat="server"></asp:Label>
                    <asp:RequiredFieldValidator ID="IndirizzoConsegnaValidator" ControlToValidate="IndirizziConsegnaList" ValidationGroup="ConfermaTestata"
                        ErrorMessage='<%$ Resources: Resources, IndirizzoConsegna %>' runat="server"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="IndirizziConsegnaList" DataValueField="Codice" DataTextField="Descrizione" runat="server"></asp:DropDownList>

                    <asp:HyperLink ID="InserisciIndirizziNuovi" NavigateUrl="~/NuoviIndirizzi.aspx" Text='<%$ Resources: Resources, InserisciNuovoIndirizzo %>' runat="server"></asp:HyperLink>
                </div>

                <asp:Panel ID="DataConsegnaManualePanel" CssClass="fieldNote" Visible="false" runat="server">
                    <asp:Label ID="DataConsegnaManualeLabel" AssociatedControlID="DataConsegnaManualeTextBox" Text='<%$ Resources: Resources, DataConsegna %>' runat="server"></asp:Label>
                    <asp:TextBox ID="DataConsegnaManualeTextBox" CssClass="date" runat="server"></asp:TextBox>
                </asp:Panel>


                <asp:Panel ID="NotePanel" CssClass="fieldNote perc50" Visible="false" runat="server">
                    <asp:Label ID="NoteLabel" AssociatedControlID="NoteTextBox" Text='<%$ Resources: Resources, Note %>' runat="server"></asp:Label>
                    <asp:TextBox ID="NoteTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
                </asp:Panel>

                <asp:Panel ID="AllegatoUploadPanel" CssClass="fieldUploadAllegato" Visible="false" runat="server">
                    <asp:Label ID="AllegatoLabel" AssociatedControlID="AllegatoFileUpload" Text='<%$ Resources: Resources, Allegato %>' runat="server"></asp:Label>
                    <asp:FileUpload ID="AllegatoFileUpload" runat="server" />
                    <asp:RegularExpressionValidator ID="AllegatoFileUploadRegExValidator" ControlToValidate="AllegatoFileUpload" ValidationGroup="ConfermaTestata"
                        ValidationExpression="^.*\..+" ErrorMessage='<%$ Resources: Resources, ErroreNoEstensioneAllegato %>' Runat="Server" />
                </asp:Panel>
                <asp:Panel ID="AllegatoPanel" CssClass="fieldAllegato" Visible="false" runat="server">
                    <asp:HyperLink ID="AllegatoLink" runat="server" Target="_blank"></asp:HyperLink>
                    <asp:CheckBox ID="EliminaAllegatoCheckBox" runat="server" />
                    <asp:Label ID="EliminaAllegatoLabel" AssociatedControlID="EliminaAllegatoCheckBox" Text='<%$ Resources: Resources, Elimina %>' runat="server"></asp:Label>
                </asp:Panel>

                <asp:Label ID="RifOrdineLabel" Text='<%$ Resources: Resources, Rifordine %>' runat="server"></asp:Label>
                <asp:TextBox ID="RifOrdineTextBox" runat="server"></asp:TextBox>

            </fieldset>
        </div>

        <div class="buttonWrap">
            <asp:Button ID="ConfermaTestataButton" Text='<%$ Resources: Resources, ConfermaTestata %>' ValidationGroup="ConfermaTestata"
                OnClick="ConfermaTestataButton_Click" runat="server" />
        </div>
    </asp:Panel>
</asp:Content>
