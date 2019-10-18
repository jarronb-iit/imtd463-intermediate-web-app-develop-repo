<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalculateMortgageWebForm.aspx.cs" Inherits="assignment4.CalculateMortgageWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" runat="server">
    <div>
        <asp:GridView ID="ErrorsGridView" runat="server" Width="991px"></asp:GridView>
    </div>
    <div>
        <asp:Label ID="principleLabel" runat="server" Text="Please enter the princpal amount"></asp:Label>
        <asp:TextBox ID="principleInput" runat="server" Height="22px" style="margin-left: 27px"></asp:TextBox>
        <br />
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <asp:RadioButtonList ID="typesOfLoanDurationsRBList" runat="server" OnSelectedIndexChanged="typesOfLoanDurations_SelectedIndexChanged" AutoPostBack="True">


                <asp:ListItem Value="15">15 Years</asp:ListItem>
                <asp:ListItem Value="30">30 Years</asp:ListItem>
                <asp:ListItem Value="-1">Other</asp:ListItem>
                </asp:RadioButtonList>

                <asp:TextBox ID="otherLoanDurationInput" runat="server" Height="22px" 
                    style="margin-left: 27px" Enabled="false"></asp:TextBox>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <asp:Label ID="interestRateLabel" runat="server" Text="Please select the interest rate"></asp:Label>
                <asp:DropDownList ID="interestRateDropDownList" runat="server" AutoPostBack="true"></asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
        <p>
        <asp:Button ID="CalulateButton" runat="server" OnClick="Calculate_Mortgage" Text="Calculate" />
        </p>
        <br />
        <asp:TextBox ID="resultText" runat="server" ReadOnly="true" Width="433px"></asp:TextBox>
        <br />
        <br />
    </div>
     <div>
        <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <asp:Label ID="TimerofDay" runat="server"></asp:Label>
                <asp:Timer runat="server" Interval="1000" OnTick="Unnamed_Tick"></asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>