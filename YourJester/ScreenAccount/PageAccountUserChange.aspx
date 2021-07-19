<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageAccountUserChange.aspx.cs" Inherits="YourJester.PageAccountUserChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="background-image: url('../Images/backgrounds/bg_09.jpg');">
        <div class="container">
            <div class="col-sm-6">
                <img src="../Images/logo_02.png" class="img-responsive">
            </div>
            <div class="col-sm-6">
                <h1> 
                    <asp:Literal runat="server" Text="<%$ Resources:Resources, textAccountChange%>" />
                </h1>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" BorderStyle="None" Text="<%$ Resources:Resources, textLogOnUserCode %>" CssClass="h2" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtUserCode" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator15" runat="server" ControlToValidate="txtUserCode" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode025 %>" OnServerValidate="R9190ValidatorLogOnDone" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserCode" ErrorMessage="<%$ Resources:Resources, messageCode003 %>" SetFocusOnError="True" CssClass="alert" Text="*"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtUserCode" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode059 %>" OnServerValidate="R9130ValidatorUserCodeExists" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" BorderStyle="None" Text="<%$ Resources:Resources, textLogOnUserPassword %>" CssClass="h2" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtUserPassword" runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="10" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserPassword" ErrorMessage="<%$ Resources:Resources, messageCode002 %>" SetFocusOnError="True" CssClass="alert">**</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode005 %>" OnServerValidate="R9140ValidatorPasswordLength" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode026 %>" OnServerValidate="R9150ValidatorPasswordLetters" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode027 %>" OnServerValidate="R9160ValidatorPasswordDigits" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode028 %>" OnServerValidate="R9170ValidatorPasswordSpecial" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator6" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode029 %>" OnServerValidate="R9180ValidatorPasswordRepeated" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator17" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode029 %>" OnServerValidate="R9180ValidatorPasswordRepeated" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" BorderStyle="None" Text="<%$ Resources:Resources, textLogOnNewUserPassword %>" CssClass="h2" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtNewUserPassword" runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="10" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserPassword" ErrorMessage="<%$ Resources:Resources, messageCode011 %>" SetFocusOnError="True" CssClass="alert">**</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator10" runat="server" ControlToValidate="txtNewUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode005 %>" OnServerValidate="R9140ValidatorPasswordLength" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator11" runat="server" ControlToValidate="txtNewUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode026 %>" OnServerValidate="R9150ValidatorPasswordLetters" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator12" runat="server" ControlToValidate="txtNewUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode027 %>" OnServerValidate="R9160ValidatorPasswordDigits" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator13" runat="server" ControlToValidate="txtNewUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode028 %>" OnServerValidate="R9170ValidatorPasswordSpecial" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator14" runat="server" ControlToValidate="txtNewUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode029 %>" OnServerValidate="R9180ValidatorPasswordRepeated" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" BorderStyle="None" Text="<%$ Resources:Resources, textLogOnConfirmPassword %>" CssClass="h2" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtConfirmUserPassword" runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="10" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserPassword" ErrorMessage="<%$ Resources:Resources, messageCode017 %>" SetFocusOnError="True" CssClass="alert">**</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtUserPassword" ControlToValidate="txtConfirmUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode018 %>" Operator="NotEqual" SetFocusOnError="True" Text="*"></asp:CompareValidator>
                    <asp:CustomValidator ID="CustomValidator16" runat="server" ControlToValidate="txtUserCode" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode034 %>" OnServerValidate="R9230ValidatorUpdateDatabase" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert" />
                    <asp:button ID="buttonChange" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textChange %>" />
                    <asp:button ID="buttonHome" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textHome %>" CausesValidation="False" PostBackUrl="~/PageHome.aspx" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
