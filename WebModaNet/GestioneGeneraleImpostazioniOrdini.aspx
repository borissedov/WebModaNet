<%@ Page Title='<%$ Resources: Resources, GestioneGeneraleImpostazioniOrdini %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestioneGeneraleImpostazioniOrdini.aspx.cs" Inherits="EW.WebModaNet.GestioneGeneraleImpostazioniOrdini" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, GestioneGeneraleImpostazioniOrdini %>' runat="server"></asp:Literal></h2>

    <p class="info">
        <asp:Literal ID="MessaggioGestioneGeneraleImpostazioniOrdiniLiteral" Text='<%$ Resources: Resources, MessaggioGestioneGeneraleImpostazioniOrdini %>' runat="server"></asp:Literal>
    </p>

    <p id="messaggioSuccesso" class="success" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="MessaggioSuccessoLiteral" runat="server"></asp:Literal>
    </p>

    <p id="messaggioErrore" class="error" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="MessaggioErroreLiteral" runat="server"></asp:Literal>
    </p>

    <div id="tabs">
        <ul>
		    <li>
                <asp:HyperLink ID="SelezioneAgentiLink" Text='<%$ Resources: Resources, SelezioneAgenti %>'
                    NavigateUrl="#tabs-1" runat="server"></asp:HyperLink>
            </li>
		    <li>
                <asp:HyperLink ID="ImpostazioniOrdiniLink" Text='<%$ Resources: Resources, ImpostazioniOrdini %>'
                    NavigateUrl="#tabs-2" runat="server"></asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="ImpostazioniStagioniLink" Text='<%$ Resources: Resources, ImpostazioniStagioni %>'
                    NavigateUrl="#tabs-3" runat="server"></asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="ImpostazioniBlocchiLink" Text='<%$ Resources: Resources, ImpostazioniBlocchi %>'
                    NavigateUrl="#tabs-4" runat="server"></asp:HyperLink>
            </li>
	    </ul>

        <div id="tabs-1" class="divField selezioneAgenti">
            <fieldset>
                <legend>
                    <asp:Literal ID="SelezioneAgentiLiteral" Text='<%$ Resources: Resources, SelezioneAgenti %>' runat="server"></asp:Literal>
                </legend>

                <p class="info">
                    <asp:Literal ID="SelezioneAgentiInfoLiteral" Text='<%$ Resources: Resources, SelezioneAgentiInfo %>' runat="server"></asp:Literal>
                </p>

                <div class="fieldTipoAgente perc30">
                    <asp:Label ID="TipoAgenteLabel" AssociatedControlID="TipiAgenteList" Text='<%$ Resources: Resources, TipoAgente %>' runat="server"></asp:Label>
                    <asp:DropDownList ID="TipiAgenteList" DataValueField="Codice" DataTextField="Descrizione" AutoPostBack="true"
                        AppendDataBoundItems="true" OnSelectedIndexChanged="TipiAgenteList_SelectedIndexChanged" runat="server">
                        <asp:ListItem Value="" Text='<%$ Resources: Resources, TuttiLista %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="fieldMarchio perc30">
                    <asp:Label ID="MarchioLabel" AssociatedControlID="MarchiList" Text='<%$ Resources: Resources, Marchio %>' runat="server"></asp:Label>
                    <asp:DropDownList ID="MarchiList" DataValueField="Codice" DataTextField="Descrizione" AutoPostBack="true"
                        AppendDataBoundItems="true" OnSelectedIndexChanged="MarchiList_SelectedIndexChanged" runat="server">
                        <asp:ListItem Value="" Text='<%$ Resources: Resources, TuttiLista %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <br style="clear: both" />

                <p id="nessunAgenteTrovato" class="warning" visible="false" enableviewstate="false" runat="server">
                    <asp:Literal ID="NessunAgenteTrovatoLiteral" Text='<%$ Resources: Resources, NessunAgenteTrovato %>' runat="server"></asp:Literal>
                </p>

                <div class="tabellaAgenti perc100">
                    <asp:GridView ID="AgentiGridView" AutoGenerateColumns="False" CssClass="tabellaLista tabAgenti" AlternatingRowStyle-CssClass="alternate" runat="server">
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="tdCheck">
                                <HeaderTemplate>
                                    <input type="checkbox" class="selezionaTuttiAgenti" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="SelezionaAgenteCheckBox" CssClass="selezionaAgente" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='<%$ Resources: Resources, TipoAgente %>' SortExpression="Tipo" ItemStyle-CssClass="tdTipoAgente">
                                <ItemTemplate>
                                    <%# Eval("Tipo.Descrizione") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='<%$ Resources: Resources, CodiceUtente %>' SortExpression="CodiceUtente" ItemStyle-CssClass="tdCodice">
                                <ItemTemplate>
                                    <asp:Literal ID="CodiceUtenteLiteral" Text='<%# Eval("CodiceUtente") %>' runat="server"></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='<%$ Resources: Resources, CodiceAgente %>' SortExpression="CodiceAgente" ItemStyle-CssClass="tdCodice">
                                <ItemTemplate>
                                    <%# Eval("CodiceAgente") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='<%$ Resources: Resources, RagioneSociale %>' SortExpression="RagioneSociale" ItemStyle-CssClass="tdRagSociale">
                                <ItemTemplate>
                                    <%# Eval("RagioneSociale") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </fieldset>
        </div>

        <div id="tabs-2" class="divField impostazioniOrdini">
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
                        <tr runat="server">
                            <td>
                                <asp:DropDownList ID="MarchiList" DataValueField="Codice" DataTextField="DescrizioneCompleta" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaMarchioLista %>'></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="TipiOrdineList" DataValueField="Id" DataTextField="DescrizioneCompleta" AppendDataBoundItems="true" runat="server">
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
                    <AlternatingItemTemplate>
                        <tr class="alternate" runat="server">
                            <td>
                                <asp:DropDownList ID="MarchiList" DataValueField="Codice" DataTextField="DescrizioneCompleta" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaMarchioLista %>'></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="TipiOrdineList" DataValueField="Id" DataTextField="DescrizioneCompleta" AppendDataBoundItems="true" runat="server">
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
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

                <div class="buttonContainer buttonWrap">
                    <asp:Button ID="SalvaImpostazioniOrdiniButton" Text='<%$ Resources: Resources, Salva %>' OnClick="SalvaImpostazioniOrdiniButton_Click" runat="server" />
                </div>
            </fieldset>
        </div>

        <div id="tabs-3" class="divField impostazioniStagioni">
            <fieldset>
                <legend>
                    <asp:Literal ID="ImpostazioniStagioniLiteral" Text='<%$ Resources: Resources, ImpostazioniStagioni %>' runat="server"></asp:Literal>
                </legend>

                <div class="tabImpostazioni impStagioni">
                    <asp:Repeater ID="ImpostazioniStagioniRepeater" OnItemDataBound="ImpostazioniStagioniRepeater_ItemDataBound" runat="server">
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
                                    <asp:DropDownList ID="StagioniDropDownList" DataValueField="Codice" DataTextField="DescrizioneCompleta" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaStagioneLista %>'></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tdCheck">
                                    <asp:CheckBox ID="DisponibilitaCheckBox" runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="StagioniDropDownList" DataValueField="Codice" DataTextField="DescrizioneCompleta" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaStagioneLista %>'></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tdCheck">
                                    <asp:CheckBox ID="DisponibilitaCheckBox" runat="server" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <div class="buttonContainer buttonWrap">
                    <asp:Button ID="SalvaImpostazioniStagioniButton" Text='<%$ Resources: Resources, Salva %>' OnClick="SalvaImpostazioniStagioniButton_Click" runat="server" />
                </div>
            </fieldset>
        </div>

        <div id="tabs-4" class="divField impostazioniBlocchi">
            <fieldset>
                <legend>
                    <asp:Literal ID="ImpostazioniBlocchiLiteral" Text='<%$ Resources: Resources, ImpostazioniBlocchi %>' runat="server"></asp:Literal>
                </legend>

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

                <div class="buttonContainer buttonWrap">
                    <asp:Button ID="Button1" Text='<%$ Resources: Resources, Salva %>' OnClick="SalvaImpostazioniBlocchiButton_Click" runat="server" />
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
