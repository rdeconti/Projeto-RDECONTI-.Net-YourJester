<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageOurPartners.aspx.cs" Inherits="YourJester.ScreenAboutUs.PageOurPartners" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-SLIDER-------------------------------------------------------------------------------------------------------->

    <section id="main-slider" class="no-margin">

        <div class="carousel slide">

            <ol class="carousel-indicators">

                <li data-target="#main-slider" data-slide-to="0" class="active"></li>
                <li data-target="#main-slider" data-slide-to="1"></li>
                <li data-target="#main-slider" data-slide-to="2"></li>
                <li data-target="#main-slider" data-slide-to="3"></li>
                <li data-target="#main-slider" data-slide-to="4"></li>
                <li data-target="#main-slider" data-slide-to="5"></li>
                <li data-target="#main-slider" data-slide-to="6"></li>
                <li data-target="#main-slider" data-slide-to="7"></li>
                <li data-target="#main-slider" data-slide-to="8"></li>

            </ol>

            <div class="carousel-inner">

                <!-PARTNER 00---------------------------------------------->

                <div class="item active" style="background-image: url('http://localhost:64310/Images/backgrounds/bg_09.jpg'); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersTitle%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersLongText%>" />
                                    </h2>
                                    <h2 class="animation animated-item-2">
                                        <asp:DynamicHyperLink runat="server" BorderStyle="None" CssClass="text-center" Target="_top" NavigateUrl="www.uol.com.br" Text="www.uol.com.br" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-6 hidden-xs animation animated-item-4">
                                <div class="slider-img">
                                    <img src="../Images/partners/ca.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->

                <!-PARTNER 01---------------------------------------------->

                <div class="item" style="background-image: url('http://localhost:64310/Images/backgrounds/bg_09.jpg'); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersTitle%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersLongText%>" />
                                    </h2>
                                    <h2 class="animation animated-item-2">
                                        <asp:DynamicHyperLink runat="server" BorderStyle="None" CssClass="text-center" Target="_top" NavigateUrl="www.uol.com.br" Text="www.uol.com.br" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-6 hidden-xs animation animated-item-4">
                                <div class="slider-img">
                                    <img src="../Images/partners/cocacola.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->

                <!-PARTNER 02---------------------------------------------->

                <div class="item" style="background-image: url('http://localhost:64310/Images/backgrounds/bg_09.jpg'); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersTitle%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersLongText%>" />
                                    </h2>
                                    <h2 class="animation animated-item-2">
                                        <asp:DynamicHyperLink runat="server" BorderStyle="None" CssClass="text-center" Target="_top" NavigateUrl="www.uol.com.br" Text="www.uol.com.br" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-6 hidden-xs animation animated-item-4">
                                <div class="slider-img">
                                    <img src="../Images/partners/dow.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->

                <!-PARTNER 03---------------------------------------------->

                <div class="item" style="background-image: url('http://localhost:64310/Images/backgrounds/bg_09.jpg'); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersTitle%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersLongText%>" />
                                    </h2>
                                    <h2 class="animation animated-item-2">
                                        <asp:DynamicHyperLink runat="server" BorderStyle="None" CssClass="text-center" Target="_top" NavigateUrl="www.uol.com.br" Text="www.uol.com.br" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-6 hidden-xs animation animated-item-4">
                                <div class="slider-img">
                                    <img src="../Images/partners/google.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->

                <!-PARTNER 04---------------------------------------------->

                <div class="item" style="background-image: url('http://localhost:64310/Images/backgrounds/bg_09.jpg'); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersTitle%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersLongText%>" />
                                    </h2>
                                    <h2 class="animation animated-item-2">
                                        <asp:DynamicHyperLink runat="server" BorderStyle="None" CssClass="text-center" Target="_top" NavigateUrl="www.uol.com.br" Text="www.uol.com.br" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-6 hidden-xs animation animated-item-4">
                                <div class="slider-img">
                                    <img src="../Images/partners/hyundai.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->

                <!-PARTNER 05---------------------------------------------->

                <div class="item" style="background-image: url('http://localhost:64310/Images/backgrounds/bg_09.jpg'); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersTitle%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersLongText%>" />
                                    </h2>
                                    <h2 class="animation animated-item-2">
                                        <asp:DynamicHyperLink runat="server" BorderStyle="None" CssClass="text-center" Target="_top" NavigateUrl="www.uol.com.br" Text="www.uol.com.br" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-6 hidden-xs animation animated-item-4">
                                <div class="slider-img">
                                    <img src="../Images/partners/intel.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->

                <!-PARTNER 06---------------------------------------------->

                <div class="item" style="background-image: url('http://localhost:64310/Images/backgrounds/bg_09.jpg'); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersTitle%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersLongText%>" />
                                    </h2>
                                    <h2 class="animation animated-item-2">
                                        <asp:DynamicHyperLink runat="server" BorderStyle="None" CssClass="text-center" Target="_top" NavigateUrl="www.uol.com.br" Text="www.uol.com.br" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-6 hidden-xs animation animated-item-4">
                                <div class="slider-img">
                                    <img src="../Images/partners/jaguar.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->

                <!-PARTNER 07---------------------------------------------->

                <div class="item" style="background-image: url('http://localhost:64310/Images/backgrounds/bg_09.jpg'); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersTitle%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersLongText%>" />
                                    </h2>
                                    <h2 class="animation animated-item-2">
                                        <asp:DynamicHyperLink runat="server" BorderStyle="None" CssClass="text-center" Target="_top" NavigateUrl="www.uol.com.br" Text="www.uol.com.br" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-6 hidden-xs animation animated-item-4">
                                <div class="slider-img">
                                    <img src="../Images/partners/microsoft.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->

                <!-PARTNER 08---------------------------------------------->

                <div class="item" style="background-image: url('http://localhost:64310/Images/backgrounds/bg_09.jpg'); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersTitle%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageOurPartnersLongText%>" />
                                    </h2>
                                    <h2 class="animation animated-item-2">
                                        <asp:DynamicHyperLink runat="server" BorderStyle="None" CssClass="text-center" Target="_top" NavigateUrl="www.uol.com.br" Text="www.uol.com.br" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-6 hidden-xs animation animated-item-4">
                                <div class="slider-img">
                                    <img src="Images/logo_02.png" class="img-responsive">
                                </div>
                            </div>
                        </div>
                    </div>
                </div><!--/.item-->

    <!--------------------------------------------------------------------------------------------------------------->

            </div><!--/.carousel-inner-->
        </div><!--/.carousel-->

        <a class="prev hidden-xs" href="#main-slider" data-slide="prev">
            <i class="fa fa-chevron-left"></i>
        </a>

        <a class="next hidden-xs" href="#main-slider" data-slide="next">
            <i class="fa fa-chevron-right"></i>
        </a>

    </section><!--/#main-slider-->

</asp:Content>
