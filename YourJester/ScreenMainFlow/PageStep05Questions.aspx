<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep05Questions.aspx.cs" Inherits="YourJester.PageStep05Questions" %>
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textYouToday %>" />
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
                    <h3 style="text-align: left; font-weight: bold; color: #FFFFFF;">
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textProgress%>" />
                    </h3>
                    <div class="progress">
                        <div id="progressBar1" runat="server" class="progress-bar color2"  role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width:95%" >
                            <asp:Label runat="server" ID="labelProgressPercentage" Text="95%" CssClass="bar-width" />
                        </div>
                    </div>
                    <h3 style="text-align: right; font-weight: bold; color: #FFFFFF;">
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textQuestions%>" />
                        <asp:Label runat="server" ID="labelNumberQuestions" Text="100"  />
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textAnswers%>" />
                        <asp:Label runat="server" ID="labelNumberAnswers" Text="80"  />
                    </h3>
                </div>
            </div>
            <div class="form-group">
                    <div class="media services-wrap wow fadeInDown">
                        <div class="pull-left">
                            <img class="img-responsive" src="../Images/logo_03.png">
                        </div>
                        <div class="media-body">
                            <asp:GridView ID="gridQuestionList" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnPageIndexChanging="R0270PageIndexChanging" OnSelectedIndexChanged="R0240RowSelectedIndexChanged" OnSelectedIndexChanging="R0250RowSelectedIndexChanging" Width="600px" OnPageIndexChanged="R0280PageIndexChanged" OnDataBound="R0290DataBound">
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
                            <p style="font-size: small">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" BorderStyle="None" ForeColor="Black" Text="<%$ Resources:Resources, textArea %>"></asp:Label>
                                <asp:Literal ID="txtTestQuestionAreaNumber" runat="server" Text="0001" />
                                <asp:Literal ID="txtTestQuestionAreaName" runat="server" Text="0001" />
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" BorderStyle="None" ForeColor="Black" Text="<%$ Resources:Resources, textQuestion %>"></asp:Label>
                                <asp:Literal ID="txtTestQuestionNumber" runat="server" Text="0001" />
                                <asp:Literal runat="server" Text="blablabla" ID="txtTestQuestionCharacteristic" />
                            </p>
                            <p style="font-size: small">
                                <asp:RadioButton ID="radioAnswer1" runat="server" GroupName="questions" Text=" <%$ Resources:Resources, textAnswerLow %>" TextAlign="Left" OnCheckedChanged="R0260CheckedChanged" BorderStyle="None" ForeColor="Black" AutoPostBack="True" />
                            </p>
                            <p style="font-size: small">
                                <asp:RadioButton ID="radioAnswer2" runat="server" GroupName="questions" Text="<%$ Resources:Resources, textAnswerMedium %>" TextAlign="Left" OnCheckedChanged="R0260CheckedChanged" BorderStyle="None" ForeColor="Black" AutoPostBack="True" />
                            </p>
                            <p style="font-size: small">
                                <asp:RadioButton ID="radioAnswer3" runat="server" GroupName="questions" Text="<%$ Resources:Resources, textAnswerHigh %>" TextAlign="Left" OnCheckedChanged="R0260CheckedChanged" BorderStyle="None" ForeColor="Black" AutoPostBack="True" />
                            </p>
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
