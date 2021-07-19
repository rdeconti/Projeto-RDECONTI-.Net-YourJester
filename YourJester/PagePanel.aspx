<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PagePanel.aspx.cs" Inherits="YourJester.PagePanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="background-image: url('Images/backgrounds/bg_09.jpg');">
       <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <h1 dir="ltr">
                        <asp:ImageButton ID="imageUserPhoto" runat="server" CssClass="img-responsive" PostBackUrl="~/ScreenAccount/PageAccountUserPhoto.aspx" Height="50" Width="40" ImageAlign="Middle" BorderStyle="None" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="auto" style="text-align: center">
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textPanel%>" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="rtl">
                        <asp:AdRotator ID="AdRotator5" runat="server" AdvertisementFile="~/App_Data/Partners.xml" CssClass="img-responsive" Height="50" BorderStyle="Outset" Width="100" BackColor="White" />
                    </h1>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage1" CssClass="img-responsive" ImageUrl="~/Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep01 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textYouByWorld %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton1" runat="server" Text="<%$ Resources:Resources,textQuestions%>" PostBackUrl="~/ScreenMainFlow/PageStep01Questions.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                            <asp:button ID="actionButton2" runat="server" Text="<%$ Resources:Resources,textResults%>" PostBackUrl="~/ScreenMainFlow/PageStep01Results.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage2" CssClass="img-responsive" ImageUrl="Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources, textStep02 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textYouDescribeYou %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton3" runat="server" Text="<%$ Resources:Resources,textQuestions%>" PostBackUrl="~/ScreenMainFlow/PageStep02Questions.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                            <asp:button ID="actionButton4" runat="server" Text="<%$ Resources:Resources,textResults%>" PostBackUrl="~/ScreenMainFlow/PageStep02Results.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage3" CssClass="img-responsive" ImageUrl="Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep03 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textYouByOthers %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton5" runat="server" Text="<%$ Resources:Resources,textQuestions%>" PostBackUrl="~/ScreenMainFlow/PageStep03Questions.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                            <asp:button ID="actionButton6" runat="server" Text="<%$ Resources:Resources,textResults%>" PostBackUrl="~/ScreenMainFlow/PageStep03Results.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage4" CssClass="img-responsive" ImageUrl="Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep04 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textYouDiscoverYou %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton7" runat="server" Text="<%$ Resources:Resources,textQuestions%>" PostBackUrl="~/ScreenMainFlow/PageStep04Questions.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                            <asp:button ID="actionButton8" runat="server" Text="<%$ Resources:Resources,textResults%>" PostBackUrl="~/ScreenMainFlow/PageStep04Results.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage5" CssClass="img-responsive" ImageUrl="Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep05 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textYouToday %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton9" runat="server" Text="<%$ Resources:Resources,textQuestions%>" PostBackUrl="~/ScreenMainFlow/PageStep05Questions.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                            <asp:button ID="actionButton10" runat="server" Text="<%$ Resources:Resources,textResults%>" PostBackUrl="~/ScreenMainFlow/PageStep05Results.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage6" CssClass="img-responsive" ImageUrl="Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep06 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textYouTomorrow %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton11" runat="server" Text="<%$ Resources:Resources,textQuestions%>" PostBackUrl="~/ScreenMainFlow/PageStep06Questions.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                            <asp:button ID="actionButton12" runat="server" Text="<%$ Resources:Resources,textResults%>" PostBackUrl="~/ScreenMainFlow/PageStep06Results.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage7" CssClass="img-responsive" ImageUrl="Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep07 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textYouInAction %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton13" runat="server" Text="<%$ Resources:Resources,textQuestions%>" PostBackUrl="~/ScreenMainFlow/PageStep07Questions.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                            <asp:button ID="actionButton14" runat="server" Text="<%$ Resources:Resources,textResults%>" PostBackUrl="~/ScreenMainFlow/PageStep07Results.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="media services-wrap">
                        <div class="row">
                            <div class="pull-left"><img class="img-responsive" src="Images/logo_03.png"></div>
                            <div class="pull-right"><asp:Image runat="server" ID="imageCodeImage8" CssClass="img-responsive" ImageUrl="Images/Icons/locked.jpg" BorderStyle="None" ImageAlign="Middle" /></div>
                        </div>
                        <div class="row" style="text-align: center">
                            <p></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textStep08 %>" BorderStyle="None" ForeColor="Black" Font-Bold="True" /></p>
                            <p><asp:Label runat="server" Text="<%$ Resources:Resources,textYouVirtual %>" BorderStyle="None" ForeColor="Black" /></p>
                        </div>
                        <div class="row" style="text-align: center">
                            <asp:button ID="actionButton15" runat="server" Text="<%$ Resources:Resources,textQuestions%>" PostBackUrl="~/ScreenMainFlow/PageStep08Questions.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                            <asp:button ID="actionButton16" runat="server" Text="<%$ Resources:Resources,textResults%>" PostBackUrl="~/ScreenMainFlow/PageStep08Results.aspx" CssClass="btn btn-primary btn-sm" BorderStyle="None"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
