<%@ Page Title='<%$ Resources: Resources, Login %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EW.WebModaNet.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="divLogin">
        <asp:Panel CssClass="msgHome" ID="MessaggioHomePanel" runat="server">
            <asp:Literal ID="MessaggioHomeLiteral" runat="server"></asp:Literal>
        </asp:Panel>

        <p id="aggiornaDatabase" class="info" visible="false" runat="server">
            <asp:Literal ID="AggiornaDatabaseLiteral" Text='<%$ Resources: Resources, IstruzioniAggiornaDatabase %>' runat="server"></asp:Literal>
        </p>

        <p id="warningSospensione" class="warning" visible="false" runat="server">
            <asp:Literal ID="WarningSospensioneLiteral" Text='<%$ Resources: Resources, MessaggioSospensione %>' runat="server"></asp:Literal>
        </p>

        <asp:Login CssClass="tabCont" ID="LoginPanel" DisplayRememberMe="false" FailureText='<%$ Resources: Resources, ErroreLogin %>'
            OnAuthenticate="LoginPanel_Authenticate" OnLoggedIn="LoginPanel_LoggedIn" OnLoginError="LoginPanel_LoginError" runat="server">
            <LayoutTemplate>
                <p id="erroreLogin" class="error" visible="false" enableviewstate="false" runat="server">
                    <asp:Literal ID="FailureText" EnableViewState="False" runat="server"></asp:Literal>
                </p>
                <table class="tabLogin">
                    <tr class="input1">
                        <th>
                            <asp:Label ID="UserNameLabel" AssociatedControlID="UserName" Text='<%$ Resources: Resources, UserName %>' CssClass="autofocus" runat="server"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" ControlToValidate="UserName" ErrorMessage='<%$ Resources: Resources, ErroreUserName %>'  
                                ToolTip='<%$ Resources: Resources, ErroreUserName %>' ValidationGroup="LoginPanel" runat="server">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="input2">
                        <th>
                            <asp:Label ID="PasswordLabel" AssociatedControlID="Password" Text='<%$ Resources: Resources, Password %>' runat="server"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" ControlToValidate="Password" ErrorMessage='<%$ Resources: Resources, ErrorePassword %>' 
                                ToolTip='<%$ Resources: Resources, ErrorePassword %>' ValidationGroup="LoginPanel" runat="server">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                
                <div class="bottoni bLogin buttonWrap">
                    <asp:Button ID="LoginButton" CommandName="Login" Text='<%$ Resources: Resources, Login %>' ValidationGroup="LoginPanel" runat="server" />
                </div>
            </LayoutTemplate>
        </asp:Login>
        <div id="divRichiediUtenza" runat="server" class="bottoni bLogin buttonWrap" style="text-align:center;margin-top:50px">
            <asp:HyperLink ID="lnkRichiediPassword" NavigateUrl="mailto:info@tshirtmakers.it?subject=Richiesta username e password business shop" runat="server">
                <asp:Image ID="imgRichiediPassword" ImageUrl="~/images/bottone_richiedi_password.png" runat="server" />
            </asp:HyperLink>
        </div>
    </div>
</asp:Content>
