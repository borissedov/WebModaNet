<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stampa.aspx.cs" Inherits="EW.WebModaNet.Stampa" %>

<%@ Register src="Controls/RiepilogoOrdineControl.ascx" tagname="RiepilogoOrdineControl" tagprefix="uc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <asp:Literal ID="TitleLiteral" Text='<%$ Resources: Resources, StampaOrdine %>' runat="server"></asp:Literal>
    </title>
    <link href="Styles/Site.css" rel="Stylesheet" type="text/css" media="screen" />
    <link href="Styles/Site_print.css" rel="Stylesheet" type="text/css" media="print" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="popStampa">

            <p id="ordineNonTrovato" class="error" visible="false" enableviewstate="false" runat="server">
                <asp:Literal ID="OrdineNonTrovatoLiteral" runat="server"></asp:Literal>
            </p>

            <asp:Panel ID="StampaPanel" Visible="true" EnableViewState="false" runat="server">
                <div class="paginaInStampa">
                    <div>
                        <asp:ImageButton ID="StampaButton" ImageUrl="~/Images/print.png" AlternateText='<%$ Resources: Resources, Stampa %>' ToolTip='<%$ Resources: Resources, Stampa %>'
                            CssClass="printButton" OnClientClick="window.print(); return false;" runat="server" />
                    </div>

                    <table class="headerStampa" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="logoDitta">
                                <asp:Image ID="LogoDittaImage" AlternateText='<%$ Resources: Resources, Logo %>' runat="server" />
                            </td>
                            <td class="infoDitta">
                                    <p>
                                        <asp:Label ID="IndirizzoDittaLabel" runat="server"></asp:Label>
                                    </p>

                                    <p>
                                        <asp:Literal Text='<%$ Resources: Resources, Telefono %>' runat="server"></asp:Literal>:
                                        <asp:Label ID="TelefonoDittaLabel" runat="server"></asp:Label>
                                    </p>

                                    <p>
                                        <asp:Literal Text='<%$ Resources: Resources, Fax %>' runat="server"></asp:Literal>:
                                        <asp:Label ID="FaxDittaLabel" runat="server"></asp:Label>
                                    </p>
                            
                                    <p>
                                        <asp:Literal Text='<%$ Resources: Resources, PartitaIva %>' runat="server"></asp:Literal>:
                                        <asp:Label ID="PartitaIvaDittaLabel" runat="server"></asp:Label>
                                    </p>
                            
                                    <p>
                                        <asp:Literal Text='<%$ Resources: Resources, SitoWeb %>' runat="server"></asp:Literal>:
                                        <asp:Label ID="SitoWebDittaLabel" runat="server"></asp:Label>
                                    </p>

                                    <p>
                                        <asp:Literal Text='<%$ Resources: Resources, Email %>' runat="server"></asp:Literal>:
                                        <asp:Label ID="EmailLabel" runat="server"></asp:Label>
                                    </p>
                            </td>
                            <td class="infoCliente">
                                <strong><asp:Literal ID="ClienteLiteral" Text='<%$ Resources: Resources, Cliente %>' runat="server"></asp:Literal>:</strong><br />
                                <asp:Literal ID="DescrizioneClienteLiteral" runat="server"></asp:Literal><br />
                                <asp:Literal ID="IndirizzoSedeLegaleLiteral" runat="server"></asp:Literal>
                            </td>
                            <td class="infoIndirizzoConsegna">
                                <strong><asp:Literal ID="IndirizzoConsegnaLiteral" Text='<%$ Resources: Resources, IndirizzoConsegna %>' runat="server"></asp:Literal>:</strong><br />
                                <asp:Literal ID="IDIndirizzoConsegnaLiteral" runat="server"></asp:Literal> -
                                <asp:Literal ID="DescrizioneIndirizzoConsegnaLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>

                    <div>
                        <h2>
                            <asp:Literal ID="TitoloOrdineLiteral" runat="server"></asp:Literal>
                        </h2>

                        <p id="intestazione" class="intestazione" runat="server">
                            <asp:Literal ID="IntestazioneLiteral" runat="server"></asp:Literal>
                        </p>

                        <table class="infoOrdine">
                	        <tr>
                                <td>
                                    <span><asp:Literal Text='<%$ Resources: Resources, Valuta %>' runat="server"></asp:Literal>:</span>
                                    <asp:Literal ID="ValutaLiteral" runat="server"></asp:Literal>
                                </td>

                                <td>
                                    <span><asp:Literal Text='<%$ Resources: Resources, MetodoPagamento %>' runat="server"></asp:Literal>:</span>
                                    <asp:Literal ID="MetodoPagamentoLiteral" runat="server"></asp:Literal>
                                </td>

                                <td>
                                    <span><asp:Literal Text='<%$ Resources: Resources, Porto %>' runat="server"></asp:Literal>:</span>
                                    <asp:Literal ID="PortoLiteral" runat="server"></asp:Literal>
                                </td>

                                <td>
                                    <span><asp:Literal Text='<%$ Resources: Resources, Trasporto %>' runat="server"></asp:Literal>:</span>
                                    <asp:Literal ID="TrasportoLiteral" runat="server"></asp:Literal>
                                </td>

                                <td>
                                    <span><asp:Literal Text='<%$ Resources: Resources, Vettore %>' runat="server"></asp:Literal>:</span>
                                    <asp:Literal ID="VettoreLiteral" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <span><asp:Literal Text='<%$ Resources: Resources, Rifordine %>' runat="server"></asp:Literal>:</span>
                                    <asp:Literal ID="RifordineLiteral" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <uc:RiepilogoOrdineControl ID="RiepilogoOrdineControl1" ModalitaStampa="true" runat="server" />

                    <table class="dateConsegna" border="0" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th><asp:Literal Text='<%$ Resources: Resources, Marchio %>' runat="server"></asp:Literal></th>
                                <th><asp:Literal Text='<%$ Resources: Resources, Stagione %>' runat="server"></asp:Literal></th>
                                <th><asp:Literal Text='<%$ Resources: Resources, DataConsegna %>' runat="server"></asp:Literal></th>
                                <th><asp:Literal Text='<%$ Resources: Resources, DataUltimaConsegna %>' runat="server"></asp:Literal></th>
                                <th><asp:Literal Text='<%$ Resources: Resources, DataDecorrenza %>' runat="server"></asp:Literal></th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="DateConsegnaRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><asp:Literal ID="MarchioLiteral" Text='<%# Eval("DescrizioneMarchio") %>' runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="StagioneLiteral" Text='<%# Eval("DescrizioneStagione") %>' runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="DataConsegnaLiteral" Text='<%# Eval("DataConsegna", "{0:dd/MM/yyyy}") %>' runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="DataUltimaConsegnaLiteral" Text='<%# Eval("DataUltimaConsegna", "{0:dd/MM/yyyy}") %>' runat="server"></asp:Literal></td>
                                    <td><asp:Literal ID="DataDecorrenzaLiteral" Text='<%# Eval("DataDecorrenza", "{0:dd/MM/yyyy}") %>' runat="server"></asp:Literal></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>

                    <div class="condizioniVendita">
                        <p><asp:Literal ID="CondizioniVenditaLiteral" runat="server"></asp:Literal></p>
                    </div>

                    <table class="footer" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td><asp:Literal Text='<%$ Resources: Resources, AgenteTimbroFirma %>' runat="server"></asp:Literal></td>
                            <td><asp:Literal Text='<%$ Resources: Resources, ClienteTimbroFirma %>' runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="RiepilogoFirmaLiteral" runat="server"></asp:Literal><br />

                                <asp:Literal Text='<%$ Resources: Resources, NumeroCapi %>' runat="server"></asp:Literal>:
                                <asp:Literal ID="NumeroCapiFirmaLiteral" runat="server"></asp:Literal><br />

                                <asp:Literal Text='<%$ Resources: Resources, TotaleNetto %>' runat="server"></asp:Literal>
                                <asp:Literal ID="litValutaOrdinePR1" runat="server"></asp:Literal>:
                                <asp:Literal ID="TotaleNettoFirmaLiteral" runat="server"></asp:Literal>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Literal ID="PiedeStampaLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
