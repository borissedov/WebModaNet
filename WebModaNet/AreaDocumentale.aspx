<%@ Page Title='<%$ Resources: Resources, AreaDocumentale %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AreaDocumentale.aspx.cs" Inherits="EW.WebModaNet.AreaDocumentale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, AreaDocumentale %>' runat="server"></asp:Literal>
    </h2>

    <asp:Panel ID="FiltriRicercaPanel" DefaultButton="CercaButton" CssClass="divField divFieldRicerca filtriRicerca" runat="server">
        <fieldset>
            <legend>
                <asp:Literal ID="RicercaDocumentiLiteral" Text='<%$ Resources: Resources, FiltriRicerca %>' runat="server"></asp:Literal>
            </legend>

            <div class="fieldCliente">
                <asp:Label ID="ClienteLabel" AssociatedControlID="ClientiList" Text='<%$ Resources: Resources, Cliente %>' runat="server"></asp:Label>
                <asp:DropDownList ID="ClientiList" DataValueField="Codice" DataTextField="RagioneSociale" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TuttiLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="fieldTipoDocumento">
                <asp:Label ID="TipoDocumentoLabel" AssociatedControlID="TipiDocumentoList" Text='<%$ Resources: Resources, Tipo %>' runat="server"></asp:Label>
                <asp:DropDownList ID="TipiDocumentoList" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TuttiLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="fieldStagione">
                <asp:Label ID="StagioneLabel" AssociatedControlID="StagioniList" Text='<%$ Resources: Resources, Stagione %>' runat="server"></asp:Label>
                <asp:DropDownList ID="StagioniList" DataValueField="Codice" DataTextField="Descrizione" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="StagioniList_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TutteLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>
                        
            <div class="fieldLinea">
                <asp:Label ID="LineaLabel" AssociatedControlID="LineeList" Text='<%$ Resources: Resources, Linea %>' runat="server"></asp:Label>
                <asp:DropDownList ID="LineeList" DataValueField="Codice" DataTextField="Descrizione" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TutteLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="fieldDescrizione">
                <asp:Label ID="DescrizioneLabel" AssociatedControlID="DescrizioneTextBox" Text='<%$ Resources: Resources, Descrizione %>' runat="server"></asp:Label>
                <asp:TextBox ID="DescrizioneTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="fieldScaduti fieldAttivo">
                <asp:CheckBox ID="ScadutiCheckBox" Text='<%$ Resources: Resources, Scaduti %>' runat="server" />
            </div>

            <div class="fieldCerca buttonWrap">
                <asp:Button ID="CercaButton" Text='<%$ Resources: Resources, Cerca %>' OnClick="CercaButton_Click" runat="server" />
            </div>
        </fieldset>
    </asp:Panel>

    <asp:UpdateProgress ID="DocumentiUpdateProgress" runat="server">
        <ProgressTemplate>
            <p class="loading">
                <asp:Literal ID="OperazioneInCorsoLiteral" Text='<%$ Resources: Resources, OperazioneInCorso %>' runat="server"></asp:Literal>
            </p>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="DocumentiUpdatePanel" runat="server">
        <ContentTemplate>
            <p id="nessunDocumentoTrovato" class="warning" visible="false" enableviewstate="false" runat="server">
                <asp:Literal ID="NessunDocumentoTrovatoLiteral" Text='<%$ Resources: Resources, NessunDocumentoTrovato %>' runat="server"></asp:Literal>
            </p>

            <asp:GridView CssClass="tabellaLista" ID="DocumentiGridView" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alternate" 
                AllowPaging="True" AllowSorting="true" PageSize="20" OnPageIndexChanging="DocumentiGridView_PageIndexChanging" OnSorting="DocumentiGridView_Sorting"
                OnRowDataBound="DocumentiGridView_RowDataBound" PagerStyle-CssClass="paginatore" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, Titolo %>' SortExpression="Titolo">
                        <ItemTemplate>
                            <asp:HyperLink ID="TitoloLink" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, Cliente %>' SortExpression="Cliente">
                        <ItemTemplate>
                            <%# Eval("Cliente.RagioneSociale") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, Tipo %>' SortExpression="Tipo">
                        <ItemTemplate>
                            <%# Eval("Tipo") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, Stagione %>' SortExpression="Stagione">
                        <ItemTemplate>
                            <%# Eval("Stagione")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, Linea %>' SortExpression="Linea">
                        <ItemTemplate>
                            <%# Eval("Linea") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, Descrizione %>' SortExpression="Descrizione">
                        <ItemTemplate>
                            <%# Eval("Descrizione") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, DataScadenza %>' SortExpression="DataScadenza">
                        <ItemTemplate>
                            <%# Eval("DataScadenza", "{0:dd/MM/yyyy}")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="CercaButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
