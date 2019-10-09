<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUserControl.ascx.cs" Inherits="MortgageCalculator.HeaderUserForm" %>

<h1>Mortgage Calculator</h1>
<hr />
<asp:Menu ID="AppNavMenu" Orientation="Horizontal" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" StaticSubMenuIndent="10px">

    <DynamicHoverStyle BackColor="#284E98" ForeColor="White"></DynamicHoverStyle>

    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"></DynamicMenuItemStyle>

    <DynamicMenuStyle BackColor="#B5C7DE"></DynamicMenuStyle>

    <DynamicSelectedStyle BackColor="#507CD1"></DynamicSelectedStyle>
    <Items>
        <asp:MenuItem NavigateUrl="~/CalculateMortgageWebForm.aspx" Text="Calculate Mortgage" Value="CalculateMortgage"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/MortgageLogWebForm.aspx" Text="List Mortgages" Value="ListMortgages"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/ClearMortgagesWebForm.aspx" Text="Clear Mortgages" Value="ClearMortgages"></asp:MenuItem>
    </Items>
    <StaticHoverStyle BackColor="#284E98" ForeColor="White"></StaticHoverStyle>

    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"></StaticMenuItemStyle>

    <StaticSelectedStyle BackColor="#507CD1"></StaticSelectedStyle>
</asp:Menu>
<br />