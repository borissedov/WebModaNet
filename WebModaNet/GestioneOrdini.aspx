<%@ Page Title='<%$ Resources: Resources, GestioneOrdini %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestioneOrdini.aspx.cs" Inherits="EW.WebModaNet.GestioneOrdini" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, GestioneOrdini %>' runat="server"></asp:Literal>
    </h2>

    <div class="divField divFieldRicerca filtriOrdini">
        <fieldset>
            <legend>
                <asp:Literal ID="FiltriOrdiniLiteral" Text='<%$ Resources: Resources, FiltriOrdini %>' runat="server"></asp:Literal>
            </legend>
            
            <div class="fieldStatoOrdine">
                <asp:Label ID="StatoOrdineLabel" AssociatedControlID="StatiOrdineList" Text='<%$ Resources: Resources, StatoOrdine %>' runat="server"></asp:Label>
                <asp:DropDownList ID="StatiOrdineList" DataValueField="Codice" DataTextField="Descrizione" AutoPostBack="true"
                    AppendDataBoundItems="true" OnSelectedIndexChanged="StatiOrdineList_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TuttiLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="fieldDataOrdine">
                <asp:Label ID="DataInizioLabel" AssociatedControlID="DataInizioTextBox" Text='<%$ Resources: Resources, DataInizio %>' runat="server"></asp:Label>
                <asp:TextBox ID="DataInizioTextBox" CssClass="date" AutoPostBack="true" OnTextChanged="DataInizioTextBox_TextChanged" runat="server"></asp:TextBox>
            </div>
        </fieldset>
	</div>

    <p id="messaggioSuccesso" class="success" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="MessaggioSuccessoLiteral" runat="server"></asp:Literal>
    </p>

    <p id="nessunOrdineTrovato" class="warning" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="NessunOrdineTrovatoLiteral" Text='<%$ Resources: Resources, NessunOrdineTrovato %>' runat="server"></asp:Literal>
    </p>

    <asp:GridView ID="OrdiniGridView" AutoGenerateColumns="false" AllowSorting="True" AllowPaging="true" PageSize="20"
        CssClass="tabellaLista tabClienti" AlternatingRowStyle-CssClass="alternate" PagerStyle-CssClass="paginatore" OnRowDataBound="OrdiniGridView_RowDataBound"
        OnSorting="OrdiniGridView_Sorting" OnPageIndexChanging="OrdiniGridView_PageIndexChanging" OnRowCommand="OrdiniGridView_RowCommand" runat="server">
        <Columns>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Operazioni %>' ItemStyle-CssClass="tdIcona">
                <ItemTemplate>
                    <asp:ImageButton ID="RipristinaOrdineButton" CommandName="RipristinaOrdine" CommandArgument='<%# Eval("Codice") %>'
                        ImageUrl="~/Images/clock_refresh.png" AlternateText='<%$ Resources: Resources, Ripristina %>' ToolTip='<%$ Resources: Resources, Ripristina %>'
                        CssClass="confirm" data-message='<%$ Resources: Resources, MessaggioConferma %>' runat="server" />
                    <asp:ImageButton ID="EliminaOrdineButton" CommandName="EliminaOrdine" CommandArgument='<%# Eval("Codice") %>'
                        ImageUrl="~/Images/delete.png" AlternateText='<%$ Resources: Resources, Elimina %>' ToolTip='<%$ Resources: Resources, Elimina %>'
                        CssClass="confirm" data-message='<%$ Resources: Resources, MessaggioConferma %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, TipoOrdine %>' SortExpression="TipoOrdine">
                <ItemTemplate>
                    <%# Eval("Tipo.Descrizione")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, StatoOrdine %>' SortExpression="Stato">
                <ItemTemplate>
                    <%# Eval("Stato.Descrizione") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, DataInserimento %>' SortExpression="Data">
                <ItemTemplate>
                <%# Eval("DataInserimento", "{0:dd/MM/yyyy}")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, NumeroOrdine %>' SortExpression="NumeroOrdine">
                <ItemTemplate>
                    <%# Eval("NumeroOrdineVisibile") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Utente %>' SortExpression="Agente">
                <ItemTemplate>
                    <%# Eval("Agente")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Cliente %>' SortExpression="Cliente">
                <ItemTemplate>
                    <%# Eval("Cliente") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, NumeroCapi %>' SortExpression="NumeroCapi">
                <ItemTemplate>
                    <%# Eval("NumeroCapi") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Valuta %>' SortExpression="Valuta">
                <ItemTemplate>
                    <%# Eval("Valuta.Descrizione") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Valore %>' SortExpression="Valore">
                <ItemTemplate>
                    <asp:Literal ID="TotaleScontatoLiteral" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Allegato %>' SortExpression="Valore">
                <ItemTemplate>
                    <asp:HyperLink ID="AllegatoLink" ImageUr="~/Images/delete.png" runat="server">
                        <asp:Image ID="AllegatoImg" ImageUrl="~/Images/list.png" runat="server" />
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
