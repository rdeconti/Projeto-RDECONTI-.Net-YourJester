<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageAccountUserLogOn.aspx.cs" Inherits="YourJester.PageAccountUserLogOn" %>
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
                    <asp:Literal runat="server" Text="<%$ Resources:Resources, textAccountLogOn%>" />
                </h1>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textLogOnUserCode %>"></asp:Label>
                    <asp:TextBox ID="txtUserCode" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserCode" ErrorMessage="<%$ Resources:Resources, messageCode003 %>" CssClass="alert" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtUserCode" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode059 %>" OnServerValidate="R9130ValidatorUserCodeExists" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" BorderStyle="None" Text="<%$ Resources:Resources, textLogOnUserPassword %>" CssClass="h2" ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtUserPassword" runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="10" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserPassword" ErrorMessage="<%$ Resources:Resources, messageCode002 %>" CssClass="alert" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode005 %>" OnServerValidate="R9140ValidatorPasswordLength" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode026 %>" OnServerValidate="R9150ValidatorPasswordLetters" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode027 %>" OnServerValidate="R9160ValidatorPasswordDigits" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode028 %>" OnServerValidate="R9170ValidatorPasswordSpecial" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator6" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode029 %>" OnServerValidate="R9180ValidatorPasswordRepeated" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator7" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode041 %>" OnServerValidate="R9200ValidatorPasswordConfirmed" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator8" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode001 %>" OnServerValidate="R9210ValidatorPasswordNotValid" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator9" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode046 %>" OnServerValidate="R9190ValidatorPasswordAttempts" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator10" runat="server" ControlToValidate="txtUserPassword" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode004 %>" OnServerValidate="R9230ValidatorUpdateDatabase" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" />
                    <asp:button ID="buttonLogOn" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textLogOn %>" />
                    <asp:button ID="buttonHome" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textHome %>" CausesValidation="False" PostBackUrl="~/PageHome.aspx" />
                </div>
                <div class="form-group">
                    <asp:button ID="buttonCreate" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textCreate %>" CausesValidation="False" PostBackUrl="~/ScreenAccount/Page_Account_User_Create.aspx" />
                    <asp:button ID="buttonConfirm" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textConfirm %>" CausesValidation="False" PostBackUrl="~/ScreenAccount/PageAccountUserConfirmation.aspx" />
                    <asp:button ID="buttonChange" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textChange %>" CausesValidation="False" PostBackUrl="~/ScreenAccount/PageAccountUserChange.aspx" />
                    <asp:button ID="buttonPhoto" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textPhoto %>" CausesValidation="False" PostBackUrl="~/ScreenAccount/PageAccountUserPhoto.aspx" />
                    <asp:button ID="buttonRecovery" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textRecovery %>" CausesValidation="False" PostBackUrl="~/ScreenAccount/PageAccountUserRecovery.aspx" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
