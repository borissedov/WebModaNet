<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RiepilogoOrdineControl.ascx.cs" Inherits="EW.WebModaNet.Controls.RiepilogoOrdineControl" %>
<table class="tabellaLista riepilogo fixedHeader" border="1" width="100%">
    <thead>
        <tr>
            <th id="intestazioneOperazioni" runat="server">
                <asp:Literal Text='<%$ Resources: Resources, Operazioni %>' runat="server"></asp:Literal>
            </th>
            <th>
                <asp:Literal Text='<%$ Resources: Resources, Articolo %>' runat="server"></asp:Literal>
            </th>
            <th>
                <asp:Literal Text='<%$ Resources: Resources, Variante %>' runat="server"></asp:Literal>
            </th>
            <th>
                <asp:Literal ID="CodiciSegnataglieLiteral" runat="server"></asp:Literal>
            </th>
            <asp:Repeater ID="IntestazioniTaglieRepeater" runat="server">
                <ItemTemplate>
                    <th>
                        <%# Container.DataItem %>
                    </th>
                </ItemTemplate>
            </asp:Repeater>
            <th>
                <asp:Literal Text='<%$ Resources: Resources, NumeroCapi %>' runat="server"></asp:Literal>
            </th>
            <th id="intestazionePrezzoAcquisto" runat="server">
                <asp:Literal Text='<%$ Resources: Resources, PrezzoAcquisto %>' runat="server"></asp:Literal>
                <asp:Literal ID="litValutaOrdinePR1" runat="server"></asp:Literal>
            </th>
            <th id="intestazioneSconto" runat="server">
                <asp:Literal Text='<%$ Resources: Resources, Sconto %>' runat="server"></asp:Literal>
            </th>
            <th id="intestazionePrezzoNetto" runat="server">
                <asp:Literal Text='<%$ Resources: Resources, PrezzoNetto %>' runat="server"></asp:Literal>
                <asp:Literal ID="litValutaOrdinePR2" runat="server"></asp:Literal>
            </th>
            <th id="intestazioneImporto" runat="server">
                <asp:Literal Text='<%$ Resources: Resources, Importo %>' runat="server"></asp:Literal>
                <asp:Literal ID="litValutaOrdinePR3" runat="server"></asp:Literal>
            </th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="DettagliRiepilogoRepeater" OnItemDataBound="DettagliRiepilogoRepeater_ItemDataBound" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="tdIcona" visible="<%# !ModalitaStampa %>" runat="server">
                        <asp:ImageButton ID="EliminaButton" CommandName="EliminaDettaglio" CommandArgument='<%# Eval("IdDettaglio") %>'
                            ImageUrl="~/Images/delete.png" AlternateText='<%$ Resources: Resources, Elimina %>'
                            ToolTip='<%$ Resources: Resources, Elimina %>' runat="server" />
                        <asp:ImageButton ID="ModificaButton" CommandName="ModificaDettaglio" CommandArgument='<%# Eval("IdDettaglio") %>'
                            ImageUrl="~/Images/edit.png" AlternateText='<%$ Resources: Resources, Modifica %>'
                            ToolTip='<%$ Resources: Resources, Modifica %>' runat="server" />
                    </td>
                    <td style="text-align: left">
                       <asp:Label ID="ArticoloLabel" Text='<%# Eval("DescrizioneArticolo") %>' ToolTip='<%# Eval("DescrizioneArticolo") %>' runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="VarianteLabel" Text='<%# Eval("DescrizioneVariante") %>' ToolTip='<%# Eval("DescrizioneArticolo") %>' runat="server"></asp:Label>
                    </td>
                    <td  style="font-size:10px">
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
                    <td class="numValuta">
                        <asp:Literal ID="PrezzoAcquistoLiteral" runat="server"></asp:Literal>
                    </td>
                    <td>
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
            <td id="cellaTotale" runat="server">
                <asp:Literal Text='<%$ Resources: Resources, TotaleOrdine %>' runat="server"></asp:Literal>
            </td>
            <td style="text-align:center;">
                <asp:Literal ID="NumeroCapiLiteral" runat="server"></asp:Literal>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Literal ID="litValutaOrdinePR4" runat="server"></asp:Literal>
                <asp:Literal ID="TotaleLiteral" runat="server">&nbsp;</asp:Literal>
            </td>
        </tr>
        <tr id="rigaSconto" class="sconto" runat="server">
            <td id="cellaSconto" runat="server">
                <asp:Literal Text='<%$ Resources: Resources, Sconto %>' runat="server"></asp:Literal>
            </td>
            <td style="text-align: center;">
                <asp:Literal ID="PercentualeScontoLiteral" runat="server"></asp:Literal>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Literal ID="ImportoScontoLiteral" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr id="rigaTotaleNetto" class="totaleNetto" runat="server">
            <td id="cellaTotaleNetto" runat="server">
                <asp:Literal Text='<%$ Resources: Resources, TotaleNettoOrdine %>' runat="server"></asp:Literal>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;                    
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Literal ID="litValutaOrdinePR5" runat="server"></asp:Literal>
                <asp:Literal ID="TotaleNettoLiteral" runat="server"></asp:Literal>
            </td>
        </tr>
    </tbody>
</table>
