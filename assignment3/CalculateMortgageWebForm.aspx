<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculateMortgageWebForm.aspx.cs" Inherits="MortgageCalculator.CalculateMortgageWebForm" %>

<%@ Register Src="~/HeaderUserControl.ascx" TagPrefix="uc1" TagName="HeaderUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <uc1:HeaderUserControl runat="server" id="HeaderUserControl" />
        </div>
        <div>
            <asp:GridView ID="ErrorsGridView" runat="server" Width="991px"></asp:GridView>
        </div>
        <div>
            <asp:Label ID="principleLabel" runat="server" Text="Please enter the princpal amount"></asp:Label>
            <asp:TextBox ID="principleInput" runat="server" Height="22px" style="margin-left: 27px"></asp:TextBox>
            <br />

        </div>
        <div>
            <asp:RadioButtonList ID="typesOfLoanDurationsRBList" runat="server" OnSelectedIndexChanged="typesOfLoanDurations_SelectedIndexChanged" AutoPostBack="True">

                <asp:ListItem Value="15">15 Years</asp:ListItem>
                <asp:ListItem Value="30">30 Years</asp:ListItem>
                <asp:ListItem Value="-1">Other</asp:ListItem>
            </asp:RadioButtonList>

            <asp:TextBox ID="otherLoanDurationInput" runat="server" Height="22px" style="margin-left: 27px" Enabled="false"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="interestRateLabel" runat="server" Text="Please select the interest rate"></asp:Label>
            <asp:DropDownList ID="interestRateDropDownList" runat="server" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div>
            <p>
                <asp:Button ID="CalulateButton" runat="server" OnClick="Calculate_Mortgage" Text="Calculate" />
            </p>
            <br />
            <asp:TextBox ID="resultText" runat="server" ReadOnly Width="433px"></asp:TextBox>
            <br />

        </div>
    </form>
</body>
</html>
