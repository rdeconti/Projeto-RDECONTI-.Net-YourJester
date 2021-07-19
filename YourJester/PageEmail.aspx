<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageEmail.aspx.cs" Inherits="YourJester.PageEmail" %>
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textEmail%>" />
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
                    <img src="../Images/logo_02.png" class="img-responsive">
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <asp:Label ID="Label58" runat="server" CssClass="h2" ForeColor="Black" BorderStyle="None" Text="<%$ Resources:Resources, textFrom %>" ></asp:Label>
                        <asp:TextBox ID="txtEmailFrom" runat="server" ReadOnly="True" CssClass="form-control" BorderStyle="Solid" >YourJester2@gmail.com</asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label59" runat="server" CssClass="h2" ForeColor="Black" BorderStyle="None" Text="<%$ Resources:Resources, textTo %>" ></asp:Label>
                        <asp:TextBox ID="txtEmailTo" runat="server" ReadOnly="True" CssClass="form-control" BorderStyle="Solid" >rdeconti@uol.com.br</asp:TextBox>
                    </div>
                    <div class="form-group">                        
                        <asp:Label ID="Label60" runat="server" CssClass="h2" ForeColor="Black" BorderStyle="None" Text="<%$ Resources:Resources, textCopy %>" ></asp:Label>
                        <asp:TextBox ID="txtEmailCopy" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label61" runat="server" CssClass="h2" ForeColor="Black" BorderStyle="None" Text="<%$ Resources:Resources, textTitle %>" ></asp:Label>
                        <asp:TextBox ID="txtEmailTitle" runat="server" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label62" runat="server" CssClass="h2" ForeColor="Black" BorderStyle="None" Text="<%$ Resources:Resources, textMessage %>" ></asp:Label>
                        <asp:TextBox ID="txtEmailMessage" runat="server" TextMode="MultiLine" CssClass="form-control" BorderStyle="Solid"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <p>
                            <a>
                                <asp:button ID="buttonSendEmail" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0100SendEmail" Text="<%$ Resources:Resources, textSend %>"/>
                            </a>
                            <a class="btn btn-primary btn-lg" href="../PageHome.aspx">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textHome%>" />
                            </a>
                            <a class="btn btn-primary btn-lg" href="../PagePanel.aspx">
                                <asp:Literal runat="server" Text="<%$ Resources:Resources, textPanel%>" />
                            </a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>   




     
</asp:Content>
