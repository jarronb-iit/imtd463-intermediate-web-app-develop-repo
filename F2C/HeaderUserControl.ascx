<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUserControl.ascx.cs" Inherits="F2C.HeaderUserForm" %>

<h1>Temperature Convert</h1>
<hr />
<asp:Menu ID="AppNavMenu" Orientation="Horizontal" runat="server">

    <Items>
        <asp:MenuItem NavigateUrl="~/F2CWebForm.aspx" Text="F2C" Value="F2C"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/TempLog.aspx" Text="Logger" Value="Logger"></asp:MenuItem>
    </Items>
</asp:Menu>
