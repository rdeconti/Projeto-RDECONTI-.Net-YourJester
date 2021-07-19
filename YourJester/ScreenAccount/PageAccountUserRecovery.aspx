<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageAccountUserRecovery.aspx.cs" Inherits="YourJester.PageAccountUserRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="background-image: url('../Images/backgrounds/bg_09.jpg');">
        <div class="container">
            <div class="col-sm-6">
                <img src="../Images/logo_02.png" class="img-responsive">
            </div>
            <div class="col-sm-6">
                <h1 class="animation animated-item-2"> 
                    <asp:Literal runat="server" Text="<%$ Resources:Resources, textAccountRecovery%>" />
                </h1>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" BorderStyle="None" Text="<%$ Resources:Resources, textEmail %>" CssClass="h2" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ErrorMessage="<%$ Resources:Resources, messageCode016 %>" SetFocusOnError="True" CssClass="alert" Text="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode043 %>" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" Text="*"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="CustomValidator12" runat="server" ControlToValidate="txtUserEmail" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode014 %>" OnServerValidate="R9140ValidatorDatabaseCheckUserEmail" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="True" />
                    <asp:button ID="buttonRecovery" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textRecovery %>" />
                    <asp:button ID="buttonHome" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textHome %>" CausesValidation="False" PostBackUrl="~/PageHome.aspx" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
