<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep02Questions.aspx.cs" Inherits="YourJester.ScreenMainFlow.PageStep02Questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="background-image: url('../Images/backgrounds/bg_09.jpg');">
       <div class="container">
            <div class="form-group">
                <div class="col-sm-4">
                    <h1 dir="ltr">
                        <asp:ImageButton ID="imageUserPhoto" runat="server" CssClass="img-responsive" PostBackUrl="~/ScreenAccount/PageAccountUserPhoto.aspx" Height="50" Width="40" ImageAlign="Middle" BorderStyle="None" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="auto" style="text-align: center">
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textYouDescribeYou%>" />
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textQuestions%>" />
                    </h1>
                </div>
                <div class="col-sm-4">
                    <h1 dir="rtl">
                        <asp:AdRotator ID="adRotPartners" runat="server" AdvertisementFile="~/App_Data/Partners.xml" CssClass="img-responsive" Height="50" BorderStyle="Outset" Width="100" BackColor="White" />
                    </h1>
                </div>
            </div>
            <div class="form-group">
                <div class="progress-wrap">
                    <h3 style="font-weight: bold; color: #FFFFFF;">
                        <asp:Label runat="server" ID="labelTitleProgress" Text="<%$ Resources:Resources, textProgress %>" BorderStyle="None" />
                    </h3>
                    <div class="progress">
                        <div id="progressBar1" runat="server" class="progress-bar color2"  role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width:95%" >
                            <asp:Label runat="server" ID="labelProgressPercentage" Text="95%" CssClass="bar-width" />
                        </div>
                    </div>
                    <h3 style="text-align: right; font-weight: bold; color: #FFFFFF;">
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textQuestions%>" />
                        <asp:Label runat="server" ID="labelNumberQuestions" Text="100" CssClass="label" />
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textAnswers%>" />
                        <asp:Label runat="server" ID="labelNumberAnswers" Text="80" CssClass="label"  />
                    </h3>
                </div>
            </div>
            <div class="form-group">
                <div class="media services-wrap">
                    <div class="pull-left">
                        <img class="img-responsive" src="../Images/logo_03.png">
                    </div>
                    <div class="media-body">
                        <asp:GridView ID="gridQuestionList" runat="server" AllowPaging="True" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None"  OnPageIndexChanging="R0270PageIndexChanging" OnSelectedIndexChanged="R0240RowSelectedIndexChanged" OnDataBound="R0290DataBound" BorderStyle="None" Font-Size="Small" HeaderStyle-HorizontalAlign="NotSet" AllowCustomPaging="False" CssClass="table-responsive table" OnPageIndexChanged="R0280PageIndexChanged" OnSelectedIndexChanging="R0250RowSelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Answer" ShowCancelButton="False" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" Font-Size="Larger" VerticalAlign="Middle" Wrap="True" />
                            <RowStyle BackColor="#EFF3FB" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="form-group" style="background-color: #FFFFCC">
                <div class="media services-wrap">
                    <p style="font-size: small">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" BorderStyle="None" ForeColor="Black" Text="<%$ Resources:Resources, textNumber %>"></asp:Label>
                        <asp:Literal ID="txtTestQuestionNumber" runat="server" Text="0001" />
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" BorderStyle="None" ForeColor="Black" Text="<%$ Resources:Resources, textCharacteristic %>"></asp:Label>
                        <asp:Literal runat="server" Text="blablabla" ID="txtTestQuestionCharacteristic" />
                    </p>
                    <p style="font-size: small">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" BorderStyle="None" ForeColor="Black" Text="<%$ Resources:Resources, textDescription %>"></asp:Label>
                    </p>
                    <p style="font-size:small; text-align: justify">
                        <asp:Literal runat="server" Text="blablabla" ID="txtTestQuestionDescription" />
                    </p>
                    <p style="font-size: small">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" BorderStyle="None" ForeColor="Black" Text="<%$ Resources:Resources, textAnswer %>"></asp:Label>
                    </p>
                    <p style="font-size: small">
                        <asp:RadioButton ID="radioAnswer1" runat="server" GroupName="questions" Text="<%$ Resources:Resources, textCharacteristicsPositive %>" CssClass="radio" OnCheckedChanged="R0260CheckedChanged" AutoPostBack="True" />
                    </p>
                    <p style="font-size: small">
                        <asp:RadioButton ID="radioAnswer2" runat="server" GroupName="questions" Text="<%$ Resources:Resources, textCharacteristicsNegative %>" CssClass="radio" OnCheckedChanged="R0260CheckedChanged" AutoPostBack="True" />
                    </p>
                    <p style="font-size: small">
                        <asp:RadioButton ID="radioAnswer3" runat="server" GroupName="questions" Text="<%$ Resources:Resources, textCharacteristicsNeutral %>" CssClass="radio" OnCheckedChanged="R0260CheckedChanged" AutoPostBack="True" />
                    </p>
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
