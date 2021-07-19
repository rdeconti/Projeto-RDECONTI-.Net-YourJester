<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageSupport.aspx.cs" Inherits="YourJester.PageSupport" %>
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageSupportTitle%>" />
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
                    <h2 dir="auto" style="text-align: justify; color: #FFFFFF;">
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageSupportLongText%>" />
                    </h2>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <img src="../Images/logo_02.png" class="img-responsive">
                </div>
                <div class="col-sm-6">
                    <p>

                    </p>
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
