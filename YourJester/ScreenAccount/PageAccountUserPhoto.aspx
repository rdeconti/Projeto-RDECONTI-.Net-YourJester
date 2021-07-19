<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageAccountUserPhoto.aspx.cs" Inherits="YourJester.ScreenAccount.PageAccountUserPhoto" %>
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
                    <asp:Literal runat="server" Text="<%$ Resources:Resources, textPhoto%>" />
                </h1>
                <div class="form-group">
                    <asp:Image ID="imageUserPhoto" runat="server" CssClass="img-responsive" Height="250px" Width="250px" ImageAlign="Middle" />
                </div>
                <div class="form-group">
                    <asp:FileUpload ID="photo" runat="server" AccessKey="b" Height="25px" Width="500px" BorderStyle="None" CssClass="btn-default active" />
                    <asp:CustomValidator ID="CustomValidator15" runat="server" ControlToValidate="photo" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode025 %>" OnServerValidate="R9190ValidatorLogOnDone" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator13" runat="server" ControlToValidate="photo" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode077 %>" OnServerValidate="R9220ValidatorCheckPhoto" Text="*"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator14" runat="server" ControlToValidate="photo" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode078 %>" OnServerValidate="R9230ValidatorUpdateDatabase" Text="*"></asp:CustomValidator>
                </div>
                <div class="form-group">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert" />
                    <asp:button ID="buttonUpdate" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textUpdate %>" />
                    <asp:button ID="buttonHome" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textHome %>" CausesValidation="False" PostBackUrl="~/PageHome.aspx" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
