<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep06Projects.aspx.cs" Inherits="YourJester.ScreenMainFlow.PageStep06Projects" %>
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textProjects%>" />
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
                        <asp:Label ID="Label15" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textNumber %>"></asp:Label>
                        <asp:TextBox ID="txtProjectNumber" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True" ></asp:TextBox>
                        <asp:Label ID="Label10" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textName %>"></asp:Label>
                        <asp:TextBox ID="txtProjectNname" runat="server" CssClass="form-control" BorderStyle="Solid" Width="600px"></asp:TextBox>
                        <asp:Label ID="Label8" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textCreation %>"></asp:Label>
                        <asp:TextBox ID="txtProjectCreation" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True" ></asp:TextBox>
                        <asp:Label ID="Label16" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textStarted %>"></asp:Label>
                        <asp:TextBox ID="txtProjectStarted" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True" ></asp:TextBox>
                        <asp:Label ID="Label17" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textFinished %>"></asp:Label>
                        <asp:TextBox ID="txtProjectFinished" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True" ></asp:TextBox>
                        <asp:Label ID="Label12" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textDescription %>"></asp:Label>
                        <asp:TextBox ID="txtProjectDescription" runat="server" CssClass="form-control" BorderStyle="Solid" TextMode="MultiLine" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <a class="btn btn-primary btn-lg" href="../PageHome.aspx">
                            <asp:Literal runat="server" Text="<%$ Resources:Resources, textHome%>" />
                        </a>
                        <a class="btn btn-primary btn-lg" href="../PagePanel.aspx">
                            <asp:Literal runat="server" Text="<%$ Resources:Resources, textPanel%>" />
                        </a>
                    </div>
                    <div class="form-group">
                        <asp:button ID="button_previous" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0060TreatPreviousProject" Text="<%$ Resources:Resources, textPrevious %>" />
                        <asp:button ID="button_next" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0070TreatNextProject" Text="<%$ Resources:Resources, textNext %>" />
                    </div>
                    <div class="form-group">
                        <asp:button ID="buttonCreate" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0030TreatProjectCreation" Text="<%$ Resources:Resources, textCreate %>" />
                        <asp:button ID="buttonChange" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0040DatabaseChangeProject" Text="<%$ Resources:Resources, textChange %>" />
                        <asp:button ID="button_delete" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0050DatabaseDeleteProject" Text="<%$ Resources:Resources, textDelete %>" />
                        <asp:button ID="button_started" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0080DatabaseUpdateProjectStart" Text="<%$ Resources:Resources, textStarted %>" />
                        <asp:button ID="button_finished" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0080DatabaseUpdateProjectFinish" Text="<%$ Resources:Resources, textFinished %>" />
                        <asp:button ID="buttonUpdate" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0020CallScreenTasks" Text="<%$ Resources:Resources, textTasks %>" />
                    </div>
                </div>
            </div>
        </div>
    </section>   
</asp:Content>
