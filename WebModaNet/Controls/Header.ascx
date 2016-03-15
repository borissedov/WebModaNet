<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="EW.WebModaNet.Controls.Header" %>
<header>
    <div class="containerHeader">
        <h1 id="pageHeader" runat="server">
            <asp:HyperLink ID="HomeLink" NavigateUrl="~/Default.aspx" runat="server" ToolTip='<%$ Resources: Resources, TornaHome %>' >
                <span><asp:Literal ID="TitoloSitoLiteral" Text='<%$ Resources: Resources, TitoloSito %>' runat="server"></asp:Literal></span>
            </asp:HyperLink>
        </h1>
    
        <div class="login">
            <asp:PlaceHolder ID="LoginPlaceHolder" Visible="false" runat="server">
                <asp:Literal ID="WelcomeLiteral" Text='<%$ Resources: Resources, Benvenuto %>' runat="server"></asp:Literal>:
                <strong>
                    <asp:Literal ID="AgenteLiteral" runat="server"></asp:Literal>
                </strong>
                |
                <asp:HyperLink ID="LogoutLink" NavigateUrl="~/Logout.aspx" Text='<%$ Resources: Resources, Logout %>' runat="server">
                </asp:HyperLink>
                -
            </asp:PlaceHolder>
    
            <asp:Literal ID="TodayLiteral" Text="<%$ Resources: Resources, DataOggi %>" runat="server"></asp:Literal>
            <strong>
                <asp:Literal ID="DateLiteral" runat="server"></asp:Literal>
            </strong>
        </div>
    </div>
</header>
