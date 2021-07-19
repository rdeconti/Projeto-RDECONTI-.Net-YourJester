<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep04CpsResults.aspx.cs" Inherits="YourJester.ScreenMainFlow.PageStep04CpsResults" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textCps%>" />
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
                <div class="media services-wrap">
                    <div class="pull-left">
                        <img class="img-responsive" src="../Images/logo_03.png">
                    </div>
                    <div class="media-body">
                        <h4 style="text-align: left; font-weight: bold;">
                            <asp:Literal runat="server" Text="<%$ Resources:Resources, textDescription%>" />
                        </h4>
                        <p style="text-align: left">
                            <asp:Image ID="imageCodeImage" runat="server" Height="265px" ImageUrl="~/Images/Jester0.png" Width="180px" />
                        </p>
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
                                <asp:Literal runat="server" ID="typeRangeNumber1" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult1" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription1" />
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
                                <asp:Literal runat="server" ID="typeRangeNumber2" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult2" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription2" />
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
                                <asp:Literal runat="server" ID="typeRangeNumber3" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult3" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription3" />
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
                                <asp:Literal runat="server" ID="typeRangeNumber4" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult4" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription4" />
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
                                <asp:Literal runat="server" ID="typeRangeNumber5" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult5" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription5" />
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
                                <asp:Literal runat="server" ID="typeRangeNumber6" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult6" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription6" />
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
                                <asp:Literal runat="server" ID="typeRangeNumber7" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult7" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription7" />
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
                                <asp:Literal runat="server" ID="typeRangeNumber8" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult8" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription8" />
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
                                <asp:Literal runat="server" ID="typeRangeNumber9" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult9" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription9" />
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
                                <asp:Literal runat="server" ID="typeRangeNumber10" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeResult10" />
                            </p>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="typeDescription10" />
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
