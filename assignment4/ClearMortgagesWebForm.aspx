<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClearMortgagesWebForm.aspx.cs" Inherits="assignment4.ClearMortgagesWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" runat="server">
    <div>
        <asp:Label ID="ifError" runat="server"></asp:Label>

        <asp:Button ID="ClearListButton" runat="server" Text="Clear list" BackColor="Red"  OnClick="ClearListButton_Click" />
        <br />
        <asp:GridView ID="CalculationsGrid" runat="server"></asp:GridView>
    </div>
</asp:Content>
