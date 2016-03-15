<%@ Page Title='<%$ Resources: Resources, AccessoNegato %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessoNegato.aspx.cs" Inherits="EW.WebModaNet.AccessoNegato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="perc50">
        <h2>
            <asp:Literal ID="TitoloAccessoNegatoLiteral" Text='<%$ Resources: Resources, AccessoNegato %>' runat="server"></asp:Literal>
        </h2>
        <p class="error">
            <asp:Literal ID="ErroreAccessoNegatoLiteral" Text='<%$ Resources: Resources, ErroreAccessoNegato %>' runat="server"></asp:Literal>
        </p>
    </div>
</asp:Content>
