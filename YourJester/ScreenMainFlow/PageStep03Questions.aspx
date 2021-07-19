<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep03Questions.aspx.cs" Inherits="YourJester.PageStep03Questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="background-image: url('../Images/backgrounds/bg_09.jpg');">
       <div class="container">
            <div class="row">
                <div class="wow fadeInDown">
                    <div class="col-sm-4">
                        <h1 dir="ltr">
                            <asp:ImageButton ID="imageUserPhoto" runat="server" CssClass="img-responsive" PostBackUrl="~/ScreenAccount/PageAccountUserPhoto.aspx" Height="50" Width="40" ImageAlign="Middle" BorderStyle="None" />
                        </h1>
                    </div>
                    <div class="col-sm-4">
                        <h1 dir="auto" style="text-align: center">
                            <asp:Literal runat="server" Text="<%$ Resources:Resources, textYouByOthers%>" />
                            <asp:Literal runat="server" Text="<%$ Resources:Resources, textAnalysis%>" />
                        </h1>
                    </div>
                    <div class="col-sm-4">
                        <h1 dir="rtl">
                            <asp:AdRotator ID="AdRotator5" runat="server" AdvertisementFile="~/App_Data/Partners.xml" CssClass="img-responsive" Height="50" BorderStyle="Outset" Width="100" BackColor="White" />
                        </h1>
                    </div>
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
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyAztec %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton1" runat="server" Text="<%$ Resources:Resources,textAnalysis %>" PostBackUrl="~/ScreenMainFlow/PageStep03Aztec.aspx" CssClass="btn btn-primary btn-sm" />
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
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyBrazilian %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton2" runat="server" Text="<%$ Resources:Resources,textAnalysis %>" PostBackUrl="~/ScreenMainFlow/PageStep03Brazilian.aspx" CssClass="btn btn-primary btn-sm"/>
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
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyCeltic %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton3" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Celtic.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage4" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep04 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyChinese %>" BorderStyle="None" ForeColor="Black" /></p>                       
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton4" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Chinese.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage5" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep05 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyEgyptian %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton5" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Egyptian.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage6" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep06 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyGypsy %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton6" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Gypsy.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage7" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep07 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyIndian %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton7" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Indian.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage8" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep08 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyMaya %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton8" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Maya.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage9" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep09 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyOcidental %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton9" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Occidental.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage10" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep10 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAstrologyShamanic %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton10" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Shamanic.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage11" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep11 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textAngels %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton11" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Angel.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage12" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep12 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textBornPressage %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton12" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03DayOfBorn.aspx" CssClass="btn btn-primary btn-sm"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="../Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage13" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep13 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textNumerology %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton13" runat="server" Text="<%$ Resources:Resources,textAnalysis%>" PostBackUrl="~/ScreenMainFlow/PageStep03Numerology.aspx" CssClass="btn btn-primary btn-sm"/>
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
