<%@ Page Title='<%$ Resources: Resources, ElencoOrdini %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ordini.aspx.cs" Inherits="EW.WebModaNet.Ordini" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, ElencoOrdini %>' runat="server"></asp:Literal>
    </h2>

    <p id="messaggioSuccesso" class="success" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="MessaggioSuccessoLiteral" runat="server"></asp:Literal>
    </p>

    <asp:Panel ID="MessaggioOrdineTemporaneoPanel" CssClass="warning withButton large" Visible="false" runat="server">
        <p>
            <asp:Literal ID="MessaggioOrdineTemporaneoLiteral" Text='<%$ Resources: Resources, MessaggioOrdineTemporaneoElenco %>' runat="server"></asp:Literal>
        </p>
        <asp:HyperLink ID="ModificaLink" Text='<%$ Resources: Resources, ModificaTestata %>' CssClass="pulsante linkInsNuovo" runat="server"></asp:HyperLink>
    </asp:Panel>

    <div class="apriChiudi">
        <asp:LinkButton ID="FiltriRicercaButton" Text='<%$ Resources: Resources, NascondiFiltriRicerca %>'
            CssClass="mostraNascondiFiltri nascondiFiltri" OnClick="FiltriRicercaButton_Click" runat="server"></asp:LinkButton>
    </div>

    <asp:Panel ID="FiltriRicercaPanel" CssClass="divField divFieldRicerca filtriRicerca" runat="server">
        <fieldset>
            <legend>
                <asp:Literal ID="RicercaClienteLiteral" Text='<%$ Resources: Resources, FiltriRicerca %>' runat="server"></asp:Literal>
            </legend>

            <div class="fieldTipoOrdine">
                <asp:Label ID="TipoOrdineLabel" AssociatedControlID="TipiOrdineList" Text='<%$ Resources: Resources, TipoOrdine %>' runat="server"></asp:Label>
                <asp:ListBox ID="TipiOrdineList" DataValueField="Id" DataTextField="Descrizione" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TuttiLista %>'></asp:ListItem>
                </asp:ListBox>
            </div>

            <div class="fieldMarchio">
                <asp:Label ID="MarchioLabel" AssociatedControlID="MarchiList" Text='<%$ Resources: Resources, Marchio %>' runat="server"></asp:Label>
                <asp:ListBox ID="MarchiList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TuttiLista %>'></asp:ListItem>
                </asp:ListBox>
            </div>

            <div class="fieldStagione">
                <asp:Label ID="StagioneLabel" AssociatedControlID="StagioniList" Text='<%$ Resources: Resources, Stagione %>' runat="server"></asp:Label>
                <asp:ListBox ID="StagioniList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TutteLista %>'></asp:ListItem>
                </asp:ListBox>
            </div>

            <div class="fieldStatoOrdine">
                <asp:Label ID="StatoOrdineLabel" AssociatedControlID="StatiOrdineList" Text='<%$ Resources: Resources, StatoOrdine %>' runat="server"></asp:Label>
                <asp:ListBox ID="StatiOrdineList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TuttiLista %>'></asp:ListItem>
                </asp:ListBox>
            </div>

            <div class="fieldDataInizio">
                <asp:Label ID="DataInizioLabel" AssociatedControlID="DataInizioTextBox" Text='<%$ Resources: Resources, DataInizio %>' runat="server"></asp:Label>
                <asp:TextBox ID="DataInizioTextBox" CssClass="date" runat="server"></asp:TextBox>
            </div>

            <div class="fieldDataFine">
                <asp:Label ID="DataFineLabel" AssociatedControlID="DataFineTextBox" Text='<%$ Resources: Resources, DataFine %>' runat="server"></asp:Label>
                <asp:TextBox ID="DataFineTextBox" CssClass="date" runat="server"></asp:TextBox>
            </div>

            <div id="codiceCliente" class="fieldCodiceCliente" runat="server">
                <asp:Label ID="CodiceClienteLabel" AssociatedControlID="CodiceClienteTextBox" Text='<%$ Resources: Resources, CodiceCliente %>' runat="server"></asp:Label>
                <asp:TextBox ID="CodiceClienteTextBox" runat="server"></asp:TextBox>
            </div>

            <div id="ragioneSocialeCliente" class="fieldRagioneSocialeCliente" runat="server">
                <asp:Label ID="RagioneSocialeClienteLabel" AssociatedControlID="RagioneSocialeClienteTextBox" Text='<%$ Resources: Resources, RagioneSocialeCliente %>' runat="server"></asp:Label>
                <asp:TextBox ID="RagioneSocialeClienteTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldDataConsegnaInizio">
                <asp:Label ID="DataConsegnaInizioLabel" AssociatedControlID="DataConsegnaInizioTextBox" Text='<%$ Resources: Resources, DataConsegnaInizio %>' runat="server"></asp:Label>
                <asp:TextBox ID="DataConsegnaInizioTextBox" CssClass="date" runat="server"></asp:TextBox>
            </div>

            <div class="fieldDataConsegnaFine">
                <asp:Label ID="DataConsegnaFineLabel" AssociatedControlID="DataConsegnaFineTextBox" Text='<%$ Resources: Resources, DataConsegnaFine %>' runat="server"></asp:Label>
                <asp:TextBox ID="DataConsegnaFineTextBox" CssClass="date" runat="server"></asp:TextBox>
            </div>

            <div class="fieldCerca">
                <asp:Button ID="CercaButton" Text='<%$ Resources: Resources, Cerca %>' OnClick="CercaButton_Click" runat="server" />
            </div>
        </fieldset>
    </asp:Panel>

    <p id="nessunOrdineTrovato" class="warning" visible="false" runat="server">
        <asp:Literal ID="NessunOrdineTrovatoLiteral" Text='<%$ Resources: Resources, NessunOrdineTrovato %>' runat="server"></asp:Literal>
    </p>

    <asp:Panel ID="LegendaPanel" Visible="false" runat="server">
        <h3>
            <asp:Literal ID="LegendaLiteral" Text='<%$ Resources: Resources, LegendaColori %>' runat="server"></asp:Literal>:
        </h3>
        <table class="legenda">
        	<tr>
            	<td class="temporaneo">
                    <asp:Literal ID="TemporaneoLiteral" Text='<%$ Resources: Resources, Temporaneo %>' runat="server"></asp:Literal>
                </td>
                <td class="sospeso">
                    <asp:Literal ID="SospesoLiteral" Text='<%$ Resources: Resources, Sospeso %>' runat="server"></asp:Literal>
                </td>
             </tr>
             <tr>
                <td class="chiuso">
                    <asp:Literal ID="ChiusoLiteral" Text='<%$ Resources: Resources, Chiuso %>' runat="server"></asp:Literal>
                </td>
                <td class="trasmesso">
                    <asp:Literal ID="TrasmessoLiteral" Text='<%$ Resources: Resources, Trasmesso %>' runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:GridView ID="OrdiniGridView" AutoGenerateColumns="false" AllowSorting="True" AllowPaging="true" PageSize="20"
        CssClass="tabellaLista tabClienti" AlternatingRowStyle-CssClass="alternate" PagerStyle-CssClass="paginatore" 
        OnRowDataBound="OrdiniGridView_RowDataBound" OnSorting="OrdiniGridView_Sorting" OnPageIndexChanging="OrdiniGridView_PageIndexChanging"
        OnRowCommand="OrdiniGridView_RowCommand" ShowFooter="true" runat="server">
        <Columns>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Operazioni %>' ItemStyle-CssClass="tdIcona">
                <ItemTemplate>
                    <asp:HyperLink ID="StampaLink" Text='<%$ Resources: Resources, Stampa %>' Target="_blank" ImageUrl="~/Images/print.png"
                        ToolTip='<%$ Resources: Resources, Stampa %>' runat="server"></asp:HyperLink>
                    <asp:ImageButton ID="ModificaOrdineButton" CommandName="ModificaOrdine" CommandArgument='<%# Eval("Codice") %>'
                        ImageUrl="~/Images/edit.png" AlternateText='<%$ Resources: Resources, Modifica %>' ToolTip='<%$ Resources: Resources, Modifica %>' runat="server" />
                    <asp:ImageButton ID="RiepilogoButton" CommandName="Riepilogo" CommandArgument='<%# Eval("Codice") %>'
                        ImageUrl="~/Images/list.png" AlternateText='<%$ Resources: Resources, Riepilogo %>' ToolTip='<%$ Resources: Resources, Riepilogo %>' runat="server" />
                    <asp:ImageButton ID="EliminaOrdineButton" CommandName="EliminaOrdine" CommandArgument='<%# Eval("Codice") %>'
                        ImageUrl="~/Images/delete.png" AlternateText='<%$ Resources: Resources, Elimina %>' ToolTip='<%$ Resources: Resources, Elimina %>'
                        CssClass="confirm" data-message='<%$ Resources: Resources, MessaggioConfermaEliminaOrdine %>' runat="server" />
                    <asp:ImageButton ID="DuplicaOrdineButton" CommandName="DuplicaOrdine" CommandArgument='<%# Eval("Codice") %>'
                        ImageUrl="~/Images/copy.png" AlternateText='<%$ Resources: Resources, Duplica %>' ToolTip='<%$ Resources: Resources, Duplica %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, NumeroOrdine %>' SortExpression="NumeroOrdine" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Eval("NumeroOrdineVisibile") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, CodiceGestionale %>' SortExpression="CodiceGestionale" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Eval("CodiceGestionale") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Data %>' SortExpression="Data" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <%# Eval("Data", "{0:dd/MM/yyyy}")%>
                </ItemTemplate>
                <FooterTemplate>
                    <strong><asp:Literal ID="TotaleLiteral" Text='<%$ Resources: Resources, Totale %>' runat="server"></asp:Literal></strong>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Cliente %>' SortExpression="Cliente">
                <ItemTemplate>
                    <asp:Literal ID="RagioneSocialeClienteLiteral" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, StatoOrdine %>' ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="StatoOrdineLiteral" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, TipoOrdine %>' ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Eval("Tipo.Descrizione") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, NumeroCapi %>' ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Eval("NumeroCapi") %>
                </ItemTemplate>
                <FooterTemplate>
                    <strong><%# TotaleCapi %></strong>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Valuta %>' ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Eval("Valuta.Descrizione") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Valore %>' ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Literal ID="TotaleScontatoLiteral" runat="server"></asp:Literal>
                </ItemTemplate>
                <FooterTemplate> 
                    <strong><%# TotaleOrdiniFormattato %></strong>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
