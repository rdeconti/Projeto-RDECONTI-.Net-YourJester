<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep04HippocratesResults.aspx.cs" Inherits="YourJester.ScreenMainFlow.PageStep04HippocratesResults" %>
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textHippocrates%>" />
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textResults%>" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="rtl">
                        <asp:AdRotator ID="adRotPartners" runat="server" AdvertisementFile="~/App_Data/Partners.xml" CssClass="img-responsive" Height="50" BorderStyle="Outset" Width="100" BackColor="White" />
                    </h1>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textCharacteristicsPositive%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="txtPositiveCharacteristics" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textCharacteristicsNegative%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="txtNegativeCharacteristics" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textName%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Image ID="imageCodeImage" runat="server" Height="265px" ImageUrl="~/Images/Jester0.png" Width="180px" />
                                <asp:TextBox ID="txtname" runat="server" MaxLength="50" ReadOnly="True" Width="500px"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textDescription%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="txtDescription" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textApperance%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="appearance" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textWalk%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="walk" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textEyes%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="eyes" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textGestures%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="gestures" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
           <div class="row">
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textSpeaking%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="speaking" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textRelationships%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="relationships" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textHabits%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="habits" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textFood%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="food" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textClothing%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="clothing" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textObservation%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="observation" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textMemory%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="memory" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textInterest%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="interest" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textAttitudes%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="attitudes" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textDisposal%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="disposal" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <h4 style="text-align: left; font-weight: bold;">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textDrawings%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="drawings" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group center">
                <p>
                    <asp:button ID="buttonPanel" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/PagePanel.aspx" Text="<%$ Resources:Resources, textPanel %>" />
                    <asp:button ID="buttonHome" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/PageHome.aspx" Text="<%$ Resources:Resources, textHome %>" />
                    <asp:button ID="button_back" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/ScreenMainFlow/PageStep04Questions.aspx" Text="<%$ Resources:Resources, textYouDiscoverYou %>" />
                </p>
            </div>
        </div>
    </section>
</asp:Content>
