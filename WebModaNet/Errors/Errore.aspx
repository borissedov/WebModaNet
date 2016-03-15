<%@ Page Title='<%$ Resources: Resources, Errore %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Errore.aspx.cs" Inherits="EW.WebModaNet.Errore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="perc50">
        <h2>
            <asp:Literal ID="TitoloErroreLiteral" Text='<%$ Resources: Resources, Errore %>' runat="server"></asp:Literal>
        </h2>
        <p class="error">
            <asp:Literal ID="DescrizioneErroreLiteral" Text='<%$ Resources: Resources, ErroreGenerico %>' runat="server"></asp:Literal>
        </p>
    </div>
</asp:Content>
