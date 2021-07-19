<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep03Occidental.aspx.cs" Inherits="YourJester.PageStep03Occidental" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="services" style="background-image: url('../Images/backgrounds/bg_09.jpg');">
       <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <h1 dir="ltr">
                        <asp:ImageButton ID="imageUserPhoto" runat="server" CssClass="img-responsive" PostBackUrl="~/ScreenAccount/PageAccountUserPhoto.aspx" Height="50" Width="40" ImageAlign="Middle" BorderStyle="None" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="auto" style="text-align: center">
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textAstrologyOcidental%>" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="rtl">
                        <asp:AdRotator ID="adRotPartners" runat="server" AdvertisementFile="~/App_Data/Partners.xml" CssClass="img-responsive" Height="50" BorderStyle="Outset" Width="100" BackColor="White" />
                    </h1>
                </div>
            </div>
            <div class="row">
                <h1 dir="auto" style="text-align: center">
                    <asp:Literal runat="server" ID="name" />
                </h1>
            </div>
            <div class="row">
                <div class="col-sm-6 col-md-6">
                    <div class="media services-wrap wow fadeInDown">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textCharacteristicsPositive%>" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="txtPositiveCharacteristics" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-6">
                    <div class="media services-wrap wow fadeInDown">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textCharacteristicsNegative%>" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="txtNegativeCharacteristics" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <div class="media services-wrap wow fadeInDown">
                        <div class="pull-left">
                            <asp:Image runat="server" ID="imageCodeImage" BorderStyle="None" CssClass="img-responsive" />
                        </div>
                        <div class="media-body">
                            <p style="text-align: justify">
                                <asp:Literal runat="server" Text="description" ID="txtDescription" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group center">
                <asp:button ID="buttonSendEmail" runat="server" Text="<%$ Resources:Resources,textYouByOthers%>" PostBackUrl="~/ScreenMainFlow/PageStep03Questions.aspx" CssClass="btn btn-primary btn-sm"/>
                <asp:button ID="button2" runat="server" Text="<%$ Resources:Resources, textHome %>" PostBackUrl="~/PageHome.aspx" CssClass="btn btn-primary btn-sm" />
            </div>

        </div>
    </section>
</asp:Content>
