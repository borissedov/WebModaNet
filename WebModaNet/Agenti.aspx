<%@ Page Title='<%$ Resources: Resources, ElencoAgenti %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agenti.aspx.cs" Inherits="EW.WebModaNet.Agenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="TitoloLiteral" Text='<%$ Resources: Resources, ElencoAgenti %>' runat="server"></asp:Literal>
    </h2>

    <asp:Panel DefaultButton="CercaButton" CssClass="divField divFieldRicerca filtriAgente" runat="server">
        <fieldset>
            <legend>
                <asp:Literal ID="FiltriAgenteLiteral" Text='<%$ Resources: Resources, FiltriAgente %>' runat="server"></asp:Literal>
            </legend>
            <div class="fieldTipoAgente">
                <asp:Label ID="TipoAgenteLabel" AssociatedControlID="TipiAgenteList" Text='<%$ Resources: Resources, TipoAgente %>' runat="server"></asp:Label>
                <asp:DropDownList ID="TipiAgenteList" DataValueField="Codice" DataTextField="Descrizione" AutoPostBack="true"
                    AppendDataBoundItems="true" OnSelectedIndexChanged="TipiAgenteList_SelectedIndexChanged" runat="server">
                    <asp:ListItem Value="" Text='<%$ Resources: Resources, TuttiLista %>'></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="CodiceUtenteLabel" AssociatedControlID="CodiceUtenteTextBox" Text='<%$ Resources: Resources, CodiceUtente %>' runat="server"></asp:Label>
                <asp:TextBox ID="CodiceUtenteTextBox" CssClass="codiceUtente" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="CercaButton" Text='<%$ Resources: Resources, Cerca %>' OnClick="CercaButton_Click" runat="server" />
            </div>
        </fieldset>
    </asp:Panel>

    <p id="erroreLicenze" class="error" visible="false" enableviewstate="false" runat="server">
        <asp:Literal ID="ErroreLicenzeLiteral" Text='<%$ Resources: Resources, ErroreLicenze %>' runat="server"></asp:Literal>
    </p>

    <div class="pulsantiera">
        <asp:LinkButton ID="NuovoAgenteButton" Text='<%$ Resources: Resources, NuovoAgente %>' CssClass="pulsante linkInsAgente"
            OnClick="NuovoAgenteButton_Click" runat="server" />
    </div>

    <asp:UpdateProgress ID="AgentiUpdateProgress" AssociatedUpdatePanelID="AgentiUpdatePanel" runat="server">
        <ProgressTemplate>
            <p class="loading">
                <asp:Literal ID="OperazioneInCorsoLiteral" Text='<%$ Resources: Resources, OperazioneInCorso %>' runat="server"></asp:Literal>
            </p>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="AgentiUpdatePanel" runat="server">
        <ContentTemplate>
            <p id="nessunAgente" class="warning" visible="false" enableviewstate="false" runat="server">
                <asp:Literal ID="NessunAgenteLiteral" Text='<%$ Resources: Resources, NessunAgenteTrovato %>' runat="server"></asp:Literal>
            </p>

            <p id="erroreElimina" class="error" visible="false" enableviewstate="false" runat="server">
                <asp:Literal ID="ErroreEliminaLiteral" Text='<%$ Resources: Resources, ErroreEliminaAmministratore %>' runat="server"></asp:Literal>
            </p>

            <p id="agenteEliminato" class="success" visible="false" enableviewstate="false" runat="server">
                <asp:Literal ID="AgenteEliminatoLiteral" runat="server"></asp:Literal>
            </p>

            <asp:GridView CssClass="tabellaLista tabAgenti" ID="AgentiGridView" AllowSorting="True" AllowPaging="True" PageSize="20" OnPageIndexChanging="AgentiGridView_PageIndexChanging" 
                OnSorting="AgentiGridView_Sorting" AutoGenerateColumns="False" PagerStyle-CssClass="paginatore" AlternatingRowStyle-CssClass="alternate"
                OnRowCommand="AgentiGridView_RowCommand" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, Operazioni %>' ItemStyle-CssClass="tdIcona">
                        <ItemTemplate>
                            <asp:ImageButton ID="ModificaAgente" ImageUrl="~/Images/edit.png" AlternateText='<%$ Resources: Resources, ModificaAgente %>'
                                ToolTip='<%$ Resources: Resources, ModificaAgente %>' CommandName="ModificaAgente" CommandArgument='<%# Eval("CodiceUtente") %>' runat="server" />
                            <asp:ImageButton ID="EliminaAgente" ImageUrl="~/Images/delete.png" AlternateText='<%$ Resources: Resources, EliminaAgente %>'
                                ToolTip='<%$ Resources: Resources, EliminaAgente %>' CommandName="EliminaAgente" CommandArgument='<%# Eval("CodiceUtente") %>'
                                CssClass="confirm" data-message='<%$ Resources: Resources, ConfermaEliminaAgente %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, Attivo %>' SortExpression="Attivo" ItemStyle-CssClass="tdIcona">
                        <ItemTemplate>
                            <asp:Image ID="ImmagineNonAttivo" ImageUrl="~/Images/inactive.png" AlternateText='<%$ Resources: Resources, Inattivo %>'
                                ToolTip='<%$ Resources: Resources, Inattivo %>' Visible='<%# !IsAttivo(Eval("Attivo")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, TipoAgente %>' SortExpression="Tipo" ItemStyle-CssClass="tdTipoAgente">
                        <ItemTemplate>
                            <%# Eval("Tipo.Descrizione") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, CodiceUtente %>' SortExpression="CodiceUtente" ItemStyle-CssClass="tdCodice">
                        <ItemTemplate>
                            <%# Eval("CodiceUtente") %>
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
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, Online %>' SortExpression="Online" ItemStyle-CssClass="tdIcona">
                        <ItemTemplate>
                            <asp:Image ID="ImmagineOnline" ImageUrl="~/Images/online.png" AlternateText='<%$ Resources: Resources, Online %>'
                                ToolTip='<%$ Resources: Resources, Online %>' Visible='<%# IsOnline(Eval("Online")) %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources: Resources, DataUltimaOperazione %>' SortExpression="DataUltimaOperazione"  ItemStyle-CssClass="tdData">
                        <ItemTemplate>
                            <%# Eval("DataUltimaOperazione", "{0:G}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TipiAgenteList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="CercaButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
