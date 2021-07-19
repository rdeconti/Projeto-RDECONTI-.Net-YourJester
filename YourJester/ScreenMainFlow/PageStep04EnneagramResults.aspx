<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep04EnneagramResults.aspx.cs" Inherits="YourJester.ScreenMainFlow.PageStep04EnneagramResults" %>
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textEnneagram%>" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textTriad%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="triad" />
                                <asp:Image ID="imageCodeImage" runat="server" Height="265px" ImageUrl="~/Images/Jester0.png" Width="180px" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textName%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="name" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textDescription%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="txtDescription" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textProfile>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="profile" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textGood%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="good" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textMedium%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="medium" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textBad>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="bad" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textCommunication%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="communication" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textAddiction%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="addiction" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textVirtue%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="virtue" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textDirection>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="direction" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textRecommendation%>" />
                            </h4>
                            <p style="text-align: left">
                                <asp:Literal runat="server" ID="recommendation" />
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
