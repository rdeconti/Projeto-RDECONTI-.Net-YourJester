<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageLanguage.aspx.cs" Inherits="YourJester.PageLanguage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="background-image: url('../Images/backgrounds/bg_09.jpg');">
       <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <h1 dir="ltr">
                        <asp:ImageButton ID="imageUserPhoto" runat="server" CssClass="img-responsive" PostBackUrl="~/ScreenAccount/PageAccountUserPhoto.aspx" Height="50" Width="40" ImageAlign="Middle" BorderStyle="None" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="auto" style="text-align: center">
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageLanguageTitle%>" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="rtl">
                        <asp:AdRotator ID="adRotPartners" runat="server" AdvertisementFile="~/App_Data/Partners.xml" CssClass="img-responsive" Height="50" BorderStyle="Outset" Width="100" BackColor="White" />
                    </h1>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <p style="color: #FFFFFF; text-align: center">
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageLanguageLongText%>" />
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <img src="../Images/logo_02.png" class="img-responsive">
                </div>
                <div class="col-sm-6">
                    <div class="col-sm-4">
                        <asp:ImageButton ID="imageActionButton1" runat="server" Height="100px" ImageUrl="~/Images/flags/portugal640.png" OnClick="R0100LanguagePortuguese" />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="<%$ Resources:Resources, textPortuguese %>" Width="250px" ForeColor="White"></asp:Label>
                        <asp:ImageButton ID="imageActionButton2" runat="server" Height="100px" ImageUrl="~/Images/flags/spain640.png" OnClick="R0110LanguageSpanish" />
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="<%$ Resources:Resources, textSpanish %>" Width="250px" ForeColor="White"></asp:Label>
                        <asp:ImageButton ID="imageActionButton3" runat="server" Height="100px" ImageUrl="~/Images/flags/italy640.png" OnClick="R0180LanguageItalian" />
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="<%$ Resources:Resources, textItalian %>" Width="250px" ForeColor="White"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:ImageButton ID="imageActionButton4" runat="server" Height="100px" ImageUrl="~/Images/flags/china640.png" OnClick="R0170LanguageChinese" />
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="<%$ Resources:Resources, textChinese %>" Width="250px" ForeColor="White"></asp:Label>
                        <asp:ImageButton ID="imageActionButton5" runat="server" Height="100px" ImageUrl="~/Images/flags/arab640.png" OnClick="R0150LanguageArabic" />
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="<%$ Resources:Resources, textArabic %>" Width="250px" ForeColor="White"></asp:Label>
                        <asp:ImageButton ID="imageActionButton6" runat="server" Height="100px" ImageUrl="~/Images/flags/japan640.png" OnClick="R0160LanguageJapanese" />
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="<%$ Resources:Resources, textJapanese %>" Width="250px" ForeColor="White"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:ImageButton ID="imageActionButton7" runat="server" Height="100px" ImageUrl="~/Images/flags/france640.png" OnClick="R0130LanguageFrench" />
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="<%$ Resources:Resources, textFrench %>" Width="250px" ForeColor="White"></asp:Label>
                        <asp:ImageButton ID="imageActionButton8" runat="server" Height="100px" ImageUrl="~/Images/flags/england640.png" OnClick="R0120LanguageEnglish" />
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="<%$ Resources:Resources, textEnglish %>" Width="250px" ForeColor="White"></asp:Label>
                        <asp:ImageButton ID="imageActionButton9" runat="server" Height="100px" ImageUrl="~/Images/flags/germany640.png" OnClick="R0140LanguageGerman" />
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="<%$ Resources:Resources, textGerman %>" Width="250px" ForeColor="White"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <p style="text-align: center">
                        <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                            <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                        </a>
                        <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                            <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
                        </a>
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
