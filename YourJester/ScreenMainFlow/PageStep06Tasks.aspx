<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageStep06Tasks.aspx.cs" Inherits="YourJester.ScreenMainFlow.PageStep06Tasks" %>
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
                        <asp:Literal runat="server" Text="<%$ Resources:Resources, textYouVirtual%>" />
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
                        <asp:Label ID="Label29" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textProjects %>"></asp:Label>
                        <asp:Label ID="Label31" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textNumber %>"></asp:Label>
                        <asp:TextBox ID="txtProjectNumber" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True"></asp:TextBox>
                        <asp:Label ID="Label30" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textName %>"></asp:Label>
                        <asp:TextBox ID="txtProjectName" runat="server" CssClass="form-control" BorderStyle="Solid" ></asp:TextBox>
                        <asp:Label ID="Label11" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textTasks %>"></asp:Label>
                        <asp:Label ID="Label19" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textNumber %>"></asp:Label>
                        <asp:TextBox ID="txtTaskNumber" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True" ></asp:TextBox>
                        <asp:Label ID="Label20" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textName %>"></asp:Label>
                        <asp:TextBox ID="txtTaskName" runat="server" CssClass="form-control" BorderStyle="Solid" ></asp:TextBox>
                        <asp:Label ID="Label21" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textCreation %>"></asp:Label>
                        <asp:TextBox ID="txtTaskCreation" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True" ></asp:TextBox>
                        <asp:Label ID="Label22" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textStarted %>"></asp:Label>
                        <asp:TextBox ID="txtTaskStarted" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True" ></asp:TextBox>
                        <asp:Label ID="Label23" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textFinished %>"></asp:Label>
                        <asp:TextBox ID="txtTaskFinished" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True" ></asp:TextBox>
                        <asp:Label ID="Label25" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textResponsible %>"></asp:Label>
                        <asp:TextBox ID="txtTaskResponsible" CssClass="form-control" BorderStyle="Solid" runat="server" ></asp:TextBox>
                        <asp:Label ID="Label26" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textMail %>"></asp:Label>
                        <asp:TextBox ID="txtTaskMail" runat="server" CssClass="form-control" BorderStyle="Solid" ></asp:TextBox>
                        <asp:Label ID="Label27" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textCosts %>"></asp:Label>
                        <asp:TextBox ID="txtTaskCosts" runat="server" CssClass="form-control" BorderStyle="Solid"  ></asp:TextBox>
                        <asp:Label ID="Label28" runat="server" BorderStyle="None" CssClass="h2" ForeColor="Black" Text="<%$ Resources:Resources, textDescription %>"></asp:Label>
                        <asp:TextBox ID="txtTaskDescription" runat="server" CssClass="form-control" BorderStyle="Solid" TextMode="MultiLine" ></asp:TextBox>
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
                        <asp:button ID="buttonPreviousTask" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0060TreatPreviousProject" Text="<%$ Resources:Resources, textPrevious %>" />
                        <asp:button ID="buttonNextTask" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0070TreatNextProject" Text="<%$ Resources:Resources, textNext %>" />
                    </div>
                    <div class="form-group">
                        <asp:button ID="buttonCreateTask" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0030TreatProjectCreation" Text="<%$ Resources:Resources, textCreate %>" />
                        <asp:button ID="buttonChangeTask" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0040DatabaseChangeProject" Text="<%$ Resources:Resources, textChange %>" />
                        <asp:button ID="buttonDeleteTask" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0050DatabaseDeleteProject" Text="<%$ Resources:Resources, textDelete %>" />
                        <asp:button ID="buttonStartedTask" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0080DatabaseUpdateProjectStart" Text="<%$ Resources:Resources, textStarted %>" />
                        <asp:button ID="buttonFinishedTask" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0080DatabaseUpdateProjectFinish" Text="<%$ Resources:Resources, textFinished %>" />
                        <asp:button ID="buttonGoProjects" runat="server" CssClass="btn btn-primary btn-sm" OnClick="R0020CallScreenProjects" Text="<%$ Resources:Resources, textProjects %>" />
                    </div>
                </div>
            </div>
        </div>
    </section>   
</asp:Content>
