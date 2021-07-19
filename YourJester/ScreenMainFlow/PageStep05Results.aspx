<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep05Results.aspx.cs" Inherits="YourJester.ScreenMainFlow.PageStep05Results" %>
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textYouToday%>" />
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
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textFinalAnalysis%>" />
                            </h4>
                            <p style="text-align: justify">
                                <asp:Literal runat="server" ID="txtFinalAnalysis" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="media services-wrap">
                        <div class="pull-right">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body" style="vertical-align: middle; text-align: center">
                            <asp:Chart ID="Chart1" runat="server">
                                <Series>
                                    <asp:Series ChartType="Pie" Name="Default">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group center">
                <p>
                    <asp:button ID="buttonPanel" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/PagePanel.aspx" Text="<%$ Resources:Resources, textPanel %>" />
                    <asp:button ID="buttonSendEmail" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/PageHome.aspx" Text="<%$ Resources:Resources, textHome %>" />
                </p>
            </div>
        </div>
    </section>
</asp:Content>
