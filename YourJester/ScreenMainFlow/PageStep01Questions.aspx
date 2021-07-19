<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep01Questions.aspx.cs" Inherits="YourJester.PageStep01Questions" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section style="background-image: url('../Images/backgrounds/bg_09.jpg');">

       <div class="container">

            <div class="form-group">
                <div class="row">
                    <div class="col-sm-4">
                        <h1 dir="ltr">
                            <asp:ImageButton ID="imageUserPhoto" runat="server" CssClass="img-responsive" PostBackUrl="~/ScreenAccount/PageAccountUserPhoto.aspx" Height="50" Width="40" ImageAlign="Middle" BorderStyle="None" />
                        </h1>
                    </div>
                    <div class="col-sm-4">
                        <h1 dir="auto" style="text-align: center">
                            <asp:Literal runat="server" Text="<%$ Resources:Resources, textYouByWorld%>" />
                        </h1>
                    </div>
                    <div class="col-sm-4">
                        <h1 dir="rtl">
                            <asp:AdRotator ID="adRotPartners" runat="server" AdvertisementFile="~/App_Data/Partners.xml" CssClass="img-responsive" Height="50" BorderStyle="Outset" Width="100" BackColor="White" />
                        </h1>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col-sm-6 col-md-6">
                        <div class="media services-wrap wow fadeInDown">
                            <div class="media-body">
                                <h2 style="text-align: left; font-weight: bold;">
                                    <asp:Literal Text="<%$ Resources:Resources, textName %>" runat="server" />
                                </h2>
                                <p style="text-align: left">
                                    <asp:Label ID="Label21" Text="<%$ Resources:Resources, textFirstName %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtFirstName"  runat="server" CssClass="form-control" BorderStyle="Solid" CausesValidation="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtFirstName" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9000ValidatorFirstName" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label22" Text="<%$ Resources:Resources, textMiddleName %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMiddleName" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtMiddleName" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9010ValidatorMiddleName" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label23" Text="<%$ Resources:Resources, textLastName %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="txtLastName" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9020ValidatorLastName" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label26" Text="<%$ Resources:Resources, textFullName %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFullName" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="txtFullName" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9030ValidatorFullName" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-6">
                        <div class="media services-wrap wow fadeInDown">
                            <div class="media-body">
                                <h2 style="text-align: left; font-weight: bold;">
                                    <asp:Literal Text="<%$ Resources:Resources, textBirthday %>" runat="server" />
                                </h2>
                                <p style="text-align: left">
                                    <asp:Label ID="Label30" Text="<%$ Resources:Resources, textDay %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtBirthday"  runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="2" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBirthday" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="txtBirthday" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9040ValidatorTextBirthday" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label31" Text="<%$ Resources:Resources, textMonth %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtBirthMonth"  runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="2" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBirthMonth" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator6" runat="server" ControlToValidate="txtBirthMonth" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9050ValidatorTextBirthMonth" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label32" Text="<%$ Resources:Resources, textYear %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtBirthYear"  runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="4" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBirthYear" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator7" runat="server" ControlToValidate="txtBirthYear" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9060ValidatorTextBirthYear" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label40" Text="<%$ Resources:Resources, textHour %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtBirthHour"  runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="2" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBirthHour" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator8" runat="server" ControlToValidate="txtBirthHour" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9070ValidatorTextBirthHour" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label41" Text="<%$ Resources:Resources, textMinute %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtBirthMinute"  runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="2" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBirthMinute" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator9" runat="server" ControlToValidate="txtBirthMinute" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9080ValidatorTextBirthMinute" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label42" Text="<%$ Resources:Resources, textSecond %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:TextBox ID="txtBirthSecond"  runat="server" CssClass="form-control" BorderStyle="Solid" MaxLength="2" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtBirthSecond" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator10" runat="server" ControlToValidate="txtBirthSecond" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9090ValidatorTextBirthSecond" SetFocusOnError="True" Text="*"></asp:CustomValidator>                                
                                </p>
                            </div>
                        </div>
                    </div>

 
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col-sm-6 col-md-6">
                        <div class="media services-wrap wow fadeInDown">
                            <div class="media-body">
                                <h2 style="text-align: left; font-weight: bold;">
                                    <asp:Literal Text="<%$ Resources:Resources, textPlaces %>" runat="server" />
                                </h2>
                                <p style="text-align: left">
                                    <asp:Label ID="Label43" Text="<%$ Resources:Resources, textBirthCountry %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionBirthCountry" DataSourceID="BirthCountryDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid" AutoPostBack="False"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator11" runat="server" ControlToValidate="userOptionBirthCountry" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9100ValidatorUserOptionBirthCountry" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label44" Text="<%$ Resources:Resources, textBirthRegion %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionBirthRegion" DataSourceID="BirthRegionDataSource" DataTextField="REGION" DataValueField="REGIONID" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid" AutoPostBack="True"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator12" runat="server" ControlToValidate="userOptionBirthRegion" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9110ValidatorUserOptionBirthRegion" SetFocusOnError="True" Text="*"></asp:CustomValidator>                               
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label45" Text="<%$ Resources:Resources, textBirthCity %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionBirthCity" DataSourceID="BirthCityDataSource" DataTextField="CITY" DataValueField="CITYID" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid" AutoPostBack="False"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator13" runat="server" ControlToValidate="userOptionBirthCity" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9120ValidatorUserOptionBirthCity" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label46" Text="<%$ Resources:Resources, textLiveCountry %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionLiveCountry" DataSourceID="LiveCountryDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid" AutoPostBack="True"></asp:ListBox>
                                <asp:CustomValidator ID="CustomValidator14" runat="server" ControlToValidate="userOptionLiveCountry" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9130ValidatorUserOptionLiveCountry" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label47" Text="<%$ Resources:Resources, textLiveRegion %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionLiveRegion" DataSourceID="LiveRegionDataSource" DataTextField="REGION" DataValueField="REGIONID" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid" AutoPostBack="False"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator15" runat="server" ControlToValidate="userOptionLiveRegion" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9140ValidatorUserOptionLiveRegion" SetFocusOnError="True" Text="*"></asp:CustomValidator>                                
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Labe48" Text="<%$ Resources:Resources, textLiveCity %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionLiveCity" DataSourceID="LiveCityDataSource" DataTextField="CITY" DataValueField="CITYID" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator16" runat="server" ControlToValidate="userOptionLiveCity" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9150ValidatorUserOptionLiveCity" SetFocusOnError="True" Text="*"></asp:CustomValidator>                                
                                </p>
                            </div>
                        </div>
                    </div>   
                    <div class="col-sm-6 col-md-6">
                        <div class="media services-wrap wow fadeInDown">
                            <div class="media-body">
                                <h2 style="text-align: left; font-weight: bold;">
                                    <asp:Literal Text="<%$ Resources:Resources, textPersonalData %>" runat="server" />
                                </h2>
                                <p style="text-align: left">
                                    <asp:Label ID="Label49" Text="<%$ Resources:Resources, textGender %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionGender" DataSourceID="genderDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator17" runat="server" ControlToValidate="userOptionGender" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9160ValidatorUserOptionGender" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label1" Text="<%$ Resources:Resources, textSexuality %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionSexuality" DataSourceID="sexualityDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator23" runat="server" ControlToValidate="userOptionSexuality" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9170ValidatorUserOptionSexuality" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label Text="<%$ Resources:Resources, textSkinColour %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionSkinColour" DataSourceID="SkinColourDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator24" runat="server" ControlToValidate="userOptionSkinColour" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9180ValidatorUserOptionSkinColour" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label2" Text="<%$ Resources:Resources, textMaritalStatus %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionMaritalStatus" DataSourceID="maritalStatusDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator25" runat="server" ControlToValidate="userOptionMaritalStatus" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9190ValidatorUserOptionMaritalStatus" SetFocusOnError="True" Text="*"></asp:CustomValidator>                                
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label3" Text="<%$ Resources:Resources, textSchooling %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionSchooling" DataSourceID="schoolingDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator19" runat="server" ControlToValidate="userOptionSchooling" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9200ValidatorUserOptionSchooling" SetFocusOnError="True" Text="*"></asp:CustomValidator>                                
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label4" Text="<%$ Resources:Resources, textOccupations %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionOccupation" DataSourceID="occupationDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator20" runat="server" ControlToValidate="userOptionOccupation" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9210ValidatorUserOptionOccupation" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label5" Text="<%$ Resources:Resources, textWage %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionWageRange" DataSourceID="wageDataSource" DataTextField="RANGE" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator21" runat="server" ControlToValidate="userOptionWageRange" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9220ValidatorUserOptionWageRange" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label10" Text="<%$ Resources:Resources, textWage %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionCurrency" DataSourceID="currencyDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator22" runat="server" ControlToValidate="userOptionCurrency" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9230ValidatorUserOptionCurrency" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label6" Text="<%$ Resources:Resources, textLanguages %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionLanguage" DataSourceID="languagesDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator26" runat="server" ControlToValidate="userOptionLanguage" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9240ValidatorUserOptionLanguage" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label7" Text="<%$ Resources:Resources, textReligions %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionReligion" DataSourceID="religionDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator27" runat="server" ControlToValidate="userOptionReligion" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9250ValidatorUserOptionReligion" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label8" Text="<%$ Resources:Resources, textHobbies %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionHobby" DataSourceID="hobbyDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator28" runat="server" ControlToValidate="userOptionHobby" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9260ValidatorUserOptionHobby" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                                <p style="text-align: left">
                                    <asp:Label ID="Label9" Text="<%$ Resources:Resources, textSports %>" runat="server" BorderStyle="None" CssClass="h4" ForeColor="Black" />
                                    <asp:ListBox ID="userOptionSport" DataSourceID="sportsDataSource" DataTextField="NAME" DataValueField="CODE" Rows="1" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:ListBox>
                                    <asp:CustomValidator ID="CustomValidator18" runat="server" ControlToValidate="userOptionSport" CssClass="alert" ErrorMessage="<%$ Resources:Resources, messageCode031 %>" OnServerValidate="R9110ValidatorUserOptionSport" SetFocusOnError="True" Text="*"></asp:CustomValidator>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-group center">
                <p>
                    &nbsp;<asp:button ID="buttonUpdate" runat="server" CssClass="btn btn-primary btn-sm" Text="<%$ Resources:Resources, textUpdate %>" OnClick="R0020UpdateClick" />
                    &nbsp;<asp:button ID="buttonPanel" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/PagePanel.aspx" Text="<%$ Resources:Resources, textPanel %>" CausesValidation="False" />
                    &nbsp;<asp:button ID="buttonHome" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl="~/PageHome.aspx" Text="<%$ Resources:Resources, textHome %>" CausesValidation="False" />
            </div>
       </div>

    </section>   

    <asp:SqlDataSource ID="genderDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_genderes WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sexualityDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_sexualities WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SELECTParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
        </SELECTParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="maritalStatusDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_maritalstatus WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SELECTParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
        </SELECTParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="schoolingDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_schoolage WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SELECTParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
        </SELECTParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="wageDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, `RANGE` FROM list_wages ORDER BY CODE"></asp:SqlDataSource>

    <asp:SqlDataSource ID="languagesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_languages WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="hobbyDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_hobbies WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="religionDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_religions WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="POR" Name="parameterLanguage" SessionField="sessionUserLanguage" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="occupationDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_occupations WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="currencyDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, NAME FROM list_currencies ORDER BY NAME">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sportsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_sports WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SELECTParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
        </SELECTParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SkinColourDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_skinColour WHERE (LANGUAGE = @parameterLanguage) ORDER BY NAME">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="answersDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" OnSELECTing="R0040SetLanguageSelecting" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, LANGUAGE, NAME FROM list_answers WHERE (LANGUAGE = @parameterLanguage AND (CODE=@parameterCode000 OR CODE=@parameterCode022 OR CODE=@parameterCode023)) ORDER BY NAME">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="POR" Name="@parameterLanguage" SessionField="sessionUserLanguage" />
            <asp:SessionParameter DefaultValue="000" Name="@parameterCode000" />
            <asp:SessionParameter DefaultValue="022" Name="@parameterCode022" />
            <asp:SessionParameter DefaultValue="023" Name="@parameterCode023" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="BirthCountryDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, NAME FROM list_countries ORDER BY NAME"></asp:SqlDataSource>
    <asp:SqlDataSource ID="BirthRegionDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT REGIONID, REGION FROM list_regions ORDER BY REGION"></asp:SqlDataSource>
    <asp:SqlDataSource ID="BirthCityDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CITYID, CITY FROM list_cities ORDER BY CITY"></asp:SqlDataSource>

    <asp:SqlDataSource ID="LiveCountryDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CODE, NAME FROM list_countries ORDER BY NAME"></asp:SqlDataSource>
    <asp:SqlDataSource ID="LiveRegionDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT REGIONID, REGION FROM list_regions ORDER BY REGION"></asp:SqlDataSource>
    <asp:SqlDataSource ID="LiveCityDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:YourJesterConnectionString %>" ProviderName="<%$ ConnectionStrings:YourJesterConnectionString.ProviderName %>" SELECTCommand="SELECT CITYID, CITY FROM list_cities ORDER BY CITY"></asp:SqlDataSource>

</asp:Content>