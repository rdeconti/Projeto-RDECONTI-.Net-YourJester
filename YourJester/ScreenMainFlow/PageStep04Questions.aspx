<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep04Questions.aspx.cs" Inherits="YourJester.PageStep04Questions" %>
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textYouDiscoverYou%>" />
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textQuestions%>" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="rtl">
                        <asp:AdRotator ID="adRotPartners" runat="server" AdvertisementFile="~/App_Data/Partners.xml" CssClass="img-responsive" Height="50" BorderStyle="Outset" Width="100" BackColor="White" />
                    </h1>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage1" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep01 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textCps %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="buttonSendEmail" runat="server" PostBackUrl="~/ScreenMainFlow/PageStep04CpsQuestions.aspx" Text="<%$ Resources:Resources, textQuestions %>" CssClass="btn btn-primary btn-sm"/>
                            <asp:button ID="button2" runat="server" PostBackUrl="~/ScreenMainFlow/PageStep04CpsResults.aspx" Text="<%$ Resources:Resources, textResults %>" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage2" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep02 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textEnneagram %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="button3" runat="server" PostBackUrl="~/ScreenMainFlow/PageStep04EnneagramQuestions.aspx" Text="<%$ Resources:Resources, textQuestions %>" CssClass="btn btn-primary btn-sm"/>
                            <asp:button ID="button4" runat="server" PostBackUrl="~/ScreenMainFlow/PageStep04EnneagramResults.aspx" Text="<%$ Resources:Resources, textResults %>" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage3" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep03 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textHippocrates %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="button5" runat="server" PostBackUrl="~/ScreenMainFlow/PageStep04HippocratesQuestions.aspx" Text="<%$ Resources:Resources, textQuestions %>" CssClass="btn btn-primary btn-sm"/>
                            <asp:button ID="button6" runat="server" PostBackUrl="~/ScreenMainFlow/PageStep04HippocratesResults.aspx" Text="<%$ Resources:Resources, textResults %>" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group center">
                <p>
                    <asp:button ID="buttonPanel" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/PagePanel.aspx" Text="<%$ Resources:Resources, textPanel %>" />
                    <asp:button ID="buttonHome" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/PageHome.aspx" Text="<%$ Resources:Resources, textHome %>" />
                </p>
            </div>
        </div>
    </section>   
</asp:Content>
