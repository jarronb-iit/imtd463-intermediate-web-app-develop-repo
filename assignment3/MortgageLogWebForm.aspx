<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MortgageLogWebForm.aspx.cs" Inherits="MortgageCalculator.MortgageLogWebForm" %>

<%@ Register Src="~/HeaderUserControl.ascx" TagPrefix="uc1" TagName="HeaderUserControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:HeaderUserControl runat="server" ID="HeaderUserControl" />
        </div>
        <div>
            <asp:Label ID="ifError" runat="server"></asp:Label>
            <asp:GridView ID="CalculationsGrid" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
