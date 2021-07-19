<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageHome.aspx.cs" Inherits="YourJester.PageHome" %>

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

                <!-OUR MISSION--------------------------------------------->

                <div class="item active" style="background-image: url(Images/home/Step00_bg.jpg); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderTitle000%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderLongText000%>" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
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

                <!-Step 01------------------------------------------------->

                <div class="item" style="background-image: url(Images/home/Step01_bg.jpg); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderTitle001%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderLongText001%>" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
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

                <!-Step 02------------------------------------------------->

                <div class="item" style="background-image: url(Images/home/Step02_bg.jpg); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderTitle002%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderLongText002%>" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
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

                <!--Step 03------------------------------------------------>

                <div class="item" style="background-image: url(Images/home/Step03_bg.jpg); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderTitle003%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderLongText003%>" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
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

                <!--Step 04------------------------------------------------>

                <div class="item" style="background-image: url(Images/home/Step04_bg.jpg); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderTitle004%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderLongText004%>" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
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

                <!--Step 05------------------------------------------------>

                <div class="item" style="background-image: url(Images/home/Step05_bg.jpg); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderTitle005%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderLongText005%>" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
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

                <!--Step 06------------------------------------------------>

                <div class="item" style="background-image: url(Images/home/Step06_bg.jpg); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderTitle006%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderLongText006%>" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
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

                <!--Step 07------------------------------------------------>

                <div class="item" style="background-image: url(Images/home/Step07_bg.jpg); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderTitle007%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderLongText007%>" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
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

                <!--Step 08------------------------------------------------>

                <div class="item" style="background-image: url(Images/home/Step08_bg.jpg); ">
                    <div class="container">
                        <div class="row slide-margin">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                    <h1 class="animation animated-item-1"> 
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderTitle008%>" />
                                    </h1>
                                    <h2 class="animation animated-item-2">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageHomeSliderLongText008%>" />
                                    </h2>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PageHome.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonHome%>" />
                                    </a>
                                    <a class="btn btn-primary btn-lg animation animated-item-3" href="PagePanel.aspx">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resources, PageButtonPanel%>" />
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
