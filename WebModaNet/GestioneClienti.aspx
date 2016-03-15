<%@ Page Title='<%$ Resources: Resources, GestioneClienti %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestioneClienti.aspx.cs" Inherits="EW.WebModaNet.GestioneClienti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, GestioneClienti %>' runat="server"></asp:Literal>
    </h2>

    <p class="info">
        <asp:Literal ID="IstruzioniGestioneClientiLiteral" Text='<%$ Resources: Resources, IstruzioniGestioneClienti %>' runat="server"></asp:Literal>
    </p>

    <p id="messaggioErrore" class="error" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="MessaggioErroreLiteral" runat="server"></asp:Literal>
    </p>

    <div class="divField divFieldRicerca filtriClienti">
        <fieldset>
            <legend>
                <asp:Literal ID="FiltriClientiLiteral" Text='<%$ Resources: Resources, FiltriClienti %>' runat="server"></asp:Literal>
            </legend>
            <div class="fieldCodiceUtente">
                <asp:Label ID="CodiceUtenteLabel" AssociatedControlID="CodiciUtentiDropDownList" Text='<%$ Resources: Resources, CodiceUtente %>' runat="server"></asp:Label>
                <asp:DropDownList ID="CodiciUtentiDropDownList" AutoPostBack="true" AppendDataBoundItems="true"
                    OnSelectedIndexChanged="CodiciUtentiDropDownList_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, SelezionaAgenteLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>
        </fieldset>
	</div>

    <p id="messaggioSuccesso" class="success" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="MessaggioSuccessoLiteral" runat="server"></asp:Literal>
    </p>

    <p id="nessunClienteTrovato" class="warning" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="NessunClienteTrovatoLiteral" Text='<%$ Resources: Resources, NessunClienteTrovato %>' runat="server"></asp:Literal>
    </p>

    <asp:GridView CssClass="tabellaLista tabClienti" ID="ClientiGridView" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alternate" AllowPaging="True" PageSize="20"
        AllowSorting="True" OnRowDataBound="ClientiGridView_RowDataBound" OnRowCommand="ClientiGridView_RowCommand" OnPageIndexChanging="ClientiGridView_PageIndexChanging" OnSorting="ClientiGridView_Sorting"
        PagerStyle-CssClass="paginatore" Visible="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Operazioni %>' ItemStyle-CssClass="tdIcona">
                <ItemTemplate>
                    <asp:ImageButton ID="CreaProfiloUtenteButton" CommandName="CreaProfiloUtente" CommandArgument='<%# Eval("Codice") %>'
                        ImageUrl="~/Images/agent-add.png" AlternateText='<%$ Resources: Resources, CreaProfiloUtente %>' ToolTip='<%$ Resources: Resources, CreaProfiloUtente %>'
                        CssClass="confirm" data-message='<%$ Resources: Resources, MessaggioConferma %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Codice %>' SortExpression="Codice" ItemStyle-CssClass="tdCodice">
                <ItemTemplate>
                    <%# Eval("Codice") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, RagioneSociale %>' SortExpression="RagioneSociale" ItemStyle-CssClass="tdRagSociale">
                <ItemTemplate>
                    <%# Eval("RagioneSociale") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Indirizzo %>' ItemStyle-CssClass="tdIndirizzo">
                <ItemTemplate>
                    <asp:Literal ID="IndirizzoLiteral" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Citta %>' ItemStyle-CssClass="tdCitta">
                <ItemTemplate>
                    <asp:Literal ID="CittaLiteral" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Provincia %>' ItemStyle-CssClass="tdProvincia">
                <ItemTemplate>
                    <asp:Literal ID="ProvinciaLiteral" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
