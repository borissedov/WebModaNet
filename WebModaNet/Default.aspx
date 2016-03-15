<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EW.WebModaNet.Default" EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="RagioneSocialeLiteral" runat="server"></asp:Literal>
    </h2>

    <asp:Panel ID="OrdineTemporaneoPanel" Visible="false" runat="server">
        <p class="warning">
            <asp:Literal ID="OrdineTemporaneoLiteral" runat="server"></asp:Literal>
            <asp:HyperLink ID="OrdineTemporaneoLink" ImageUrl="~/Images/edit.png" Text='<%$ Resources: Resources, Modifica %>'
                ToolTip='<%$ Resources: Resources, Modifica %>' runat="server"></asp:HyperLink>
        </p>
    </asp:Panel>
    <asp:Panel ID="NuovoOrdinePanel" Visible="false" runat="server" CssClass="pulsantiera">
        <asp:HyperLink ID="NuovoOrdineLink" CssClass="pulsante linkInsNuovo" NavigateUrl="~/ModificaOrdine.aspx" Text='<%$ Resources: Resources, InserisciNuovoOrdine %>'
            ToolTip='<%$ Resources: Resources, InserisciNuovoOrdine %>' runat="server"></asp:HyperLink>
    </asp:Panel>
    <div class="contentHome">
        <section class="colSX banner">
            <div class="contenitoreBanner">
                <asp:HyperLink ID="lnkPromozione1" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione1" Visible="false" runat="server" />
                </asp:HyperLink>
                
                <asp:HyperLink ID="lnkPromozione2" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione2" Visible="false" runat="server" />
                </asp:HyperLink>
        
                <asp:HyperLink ID="lnkPromozione3" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione3" Visible="false" runat="server" />
                </asp:HyperLink>
        
                <asp:HyperLink ID="lnkPromozione4" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione4" Visible="false" runat="server" />
                </asp:HyperLink>
        
                <asp:HyperLink ID="lnkPromozione5" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione5" Visible="false" runat="server" />
                </asp:HyperLink>
        
                <asp:HyperLink ID="lnkPromozione6" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione6" Visible="false" runat="server" />
                </asp:HyperLink>
                <asp:HyperLink ID="lnkPromozione7" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione7" Visible="false" runat="server" />
                </asp:HyperLink>
        
                <asp:HyperLink ID="lnkPromozione8" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione8" Visible="false" runat="server" />
                </asp:HyperLink>
        
                <asp:HyperLink ID="lnkPromozione9" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione9" Visible="false" runat="server" />
                </asp:HyperLink>
        
                <asp:HyperLink ID="lnkPromozione10" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione10" Visible="false" runat="server" />
                </asp:HyperLink>
        
                <asp:HyperLink ID="lnkPromozione11" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione11" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione12" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione12" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione13" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione13" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione14" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione14" Visible="false" runat="server" />
                </asp:HyperLink>
                
                <asp:HyperLink ID="lnkPromozione15" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione15" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione16" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione16" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione17" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione17" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione18" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione18" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione19" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione19" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione20" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione20" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione21" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione21" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione22" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione22" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione23" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione23" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione24" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione24" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione25" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione25" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione26" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione26" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione27" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione27" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione28" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione28" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione29" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione29" Visible="false" runat="server" />
                </asp:HyperLink>

                <asp:HyperLink ID="lnkPromozione30" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione30" Visible="false" runat="server" />
                </asp:HyperLink>
        
            </div>
        </section>
        <aside class="colDX">        	
            <div class="contatto" id="divContatto" runat="server" visible="false">
            	<h2>Il tuo contatto:</h2>
                <div class="logoContatto">
                	<asp:Image ID="ContattoImage" runat="server" Visible="false" />
                </div>
                <div class="indirizzoContatto">
                	<asp:Literal ID="ContattoRagioneSocialeLiteral" runat="server"></asp:Literal><br />
                	<asp:Literal ID="ContattoCapCittaLiteral" runat="server"></asp:Literal>
                </div>
                <div class="contattiContatto">
                    <asp:HyperLink ID="ContattoEmailLink" runat="server"></asp:HyperLink><br />
                    <asp:HyperLink ID="ContattoTelefonoLink" runat="server"></asp:HyperLink><br />
                    <asp:HyperLink ID="ContattoTelefono2Link" runat="server"></asp:HyperLink>
                </div>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione31" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione31" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione32" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione32" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione33" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione33" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione34" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione34" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione35" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione35" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione36" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione36" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione37" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione37" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione38" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione38" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione39" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione39" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="banner">
                <asp:HyperLink ID="lnkPromozione40" Visible="false" runat="server">
                    <asp:Image ID="imgPromozione40" Visible="false" runat="server" />
                </asp:HyperLink>
            </div>
        </aside>
    </div>
</asp:Content>
