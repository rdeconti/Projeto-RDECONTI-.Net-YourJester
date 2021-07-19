<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageAccountUserConfirmation.aspx.cs" Inherits="YourJester.PageAccountUserConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="background-image: url('../Images/backgrounds/bg_09.jpg');">
        <div class="container">
            <div class="col-sm-6">
                <img src="../Images/logo_02.png" class="img-responsive">
            </div>
            <div class="col-sm-6">
                <h1 class="animation animated-item-2"> 
                    <asp:Literal runat="server" Text="<%$ Resources:Resources, textAccountConfirmation%>" />
                </h1>
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" BorderStyle="None" Text="<%$ Resources:Resources, textLogOnUserCode %>" CssClass="h2" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtUserCode" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserCode" ErrorMessage="<%$ Resources:Resources, messageCode003 %>" SetFocusOnError="True" CssClass="alert" Text="*"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtUserCode" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode059 %>" OnServerValidate="R9130ValidatorUserCodeExists" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" BorderStyle="None" Text="<%$ Resources:Resources, textLogOnUserPassword %>" CssClass="h2" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtUserPassword" runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="10" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserPassword" ErrorMessage="<%$ Resources:Resources, messageCode002 %>" SetFocusOnError="True" CssClass="alert" Text="*"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode005 %>" OnServerValidate="R9140ValidatorPasswordLength" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode026 %>" OnServerValidate="R9150ValidatorPasswordLetters" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode027 %>" OnServerValidate="R9160ValidatorPasswordDigits" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode028 %>" OnServerValidate="R9170ValidatorPasswordSpecial" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator6" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode029 %>" OnServerValidate="R9180ValidatorPasswordRepeated" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator8" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode001 %>" OnServerValidate="R9210ValidatorPasswordNotValid" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" BorderStyle="None" Text="<%$ Resources:Resources, textLogOnConfirmation %>" CssClass="h2" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtUserCodeConfirmation" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="confirmation" ErrorMessage="<%$ Resources:Resources, messageCode017 %>" CssClass="alert" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtUserPassword" ControlToValidate="confirmation" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode018 %>" Operator="NotEqual" SetFocusOnError="True" Text="*"></asp:CompareValidator>
                    <asp:CustomValidator ID="CustomValidator9" runat="server" ControlToValidate="txtUserCode" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode059 %>" OnServerValidate="R9215DatabaseValidatorGetConfirmationCode" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator14" runat="server" ControlToValidate="txtUserCode" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode004 %>" OnServerValidate="R9230ValidatorUpdateDatabase" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert" />
                    <asp:button ID="buttonConfirm" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textConfirm %>" />
                    <asp:button ID="buttonHome" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textHome %>" CausesValidation="False" PostBackUrl="~/PageHome.aspx" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
