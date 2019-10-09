<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="C2FWebForm.aspx.cs" Inherits="F2C.C2FWebForm" %>

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
            <asp:Label ID="celLable" runat="server" Text="Please enter a temperature in Celsius"></asp:Label>
            <asp:TextBox ID="celText" runat="server" Height="22px" style="margin-left: 27px"></asp:TextBox>
            <br />

        </div>
        <p>
            <asp:Button ID="ConvertC2F" runat="server" OnClick="ConvertC2F_Click" Text="Convert" />
            </p>
        <p>
            <asp:Literal ID="tempText" runat="server"></asp:Literal>
            <br />
        </p>
    </form>
</body>
</html>
