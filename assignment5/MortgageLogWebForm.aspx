<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MortgageLogWebForm.aspx.cs" Inherits="assignment4.MortgageLogWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" runat="server">
    <div>
        <asp:Label ID="ifError" runat="server"></asp:Label>
        <asp:GridView ID="CalculationsGrid" runat="server"></asp:GridView>
    </div>
</asp:Content>
