<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F2CWebForm.aspx.cs" Inherits="F2C.F2CWebForm" %>

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
            <asp:Label ID="farLable" runat="server" Text="Please enter a temperature in Farheneit"></asp:Label>
            <asp:TextBox ID="farText" runat="server" Height="22px" style="margin-left: 27px"></asp:TextBox>
            <br />

        </div>
        <p>
            <asp:Button ID="ConvertF2C" runat="server" OnClick="ConvertF2C_Click" Text="Convert" />
            </p>
        <p>
            <asp:Literal ID="tempText" runat="server"></asp:Literal>
            <br />
        </p>

        <asp:RadioButtonList ID="typesOfDrinks" runat="server" OnSelectedIndexChanged="typesOfDrinks_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>Rootbear</asp:ListItem>
            <asp:ListItem>Ginger</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:RadioButtonList>

        <asp:CheckBox ID="CheckBox1" Enabled="false" runat="server" />
    </form>
</body>
</html>
