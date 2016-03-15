<%@ Page Title='<%$ Resources: Resources, ElencoClienti %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clienti.aspx.cs" Inherits="EW.WebModaNet.Clienti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, ElencoClienti %>' runat="server"></asp:Literal>
    </h2>

    <p class="warning" id="nessunCliente" visible="false" runat="server">
        <asp:Literal ID="NessunClienteLiteral" Text='<%$ Resources: Resources, NessunCliente %>' runat="server"></asp:Literal>
    </p>

    <div class="pulsantiera">
        <asp:HyperLink ID="NuovoClienteLink1" CssClass="pulsante linkInsNuovo" NavigateUrl="~/InserisciModificaCliente.aspx" Text='<%$ Resources: Resources, NuovoCliente %>' runat="server"></asp:HyperLink>
    </div>

    <p id="successMessage" class="success" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="SuccessMessageLiteral" runat="server"></asp:Literal>
    </p>

    <asp:GridView CssClass="tabellaLista tabClienti" ID="ClientiGridView" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alternate" 
        AllowPaging="True" PageSize="20" AllowSorting="True" OnPageIndexChanging="ClientiGridView_PageIndexChanging"
        OnRowDataBound="ClientiGridView_RowDataBound" OnSorting="ClientiGridView_Sorting" PagerStyle-CssClass="paginatore" runat="server">
        <Columns>
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
            <asp:TemplateField HeaderText='<%$ Resources: Resources, Situazione %>' ItemStyle-CssClass="tdSituazione">
                <ItemTemplate>
                    <asp:Image ID="InsolutoImage" runat="server" />
                    <asp:Image ID="RatingImage" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="pulsantiera">
        <asp:HyperLink ID="NuovoClienteLink2" CssClass="pulsante linkInsNuovo" NavigateUrl="~/InserisciModificaCliente.aspx" Text='<%$ Resources: Resources, NuovoCliente %>' runat="server"></asp:HyperLink>
    </div>
</asp:Content>
