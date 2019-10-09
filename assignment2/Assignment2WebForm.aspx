<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Assignment2WebForm.aspx.vb" Inherits="assignment2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="NorthwindEmployeesGV" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="NorthwindDataSource" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
                    <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" InsertVisible="False" ReadOnly="True"></asp:BoundField>
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID"></asp:BoundField>
                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID"></asp:BoundField>
                    <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate"></asp:BoundField>
                    <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate"></asp:BoundField>
                    <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate"></asp:BoundField>
                    <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" SortExpression="ShipVia"></asp:BoundField>
                    <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight"></asp:BoundField>
                    <asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName"></asp:BoundField>
                    <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress"></asp:BoundField>
                    <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity"></asp:BoundField>
                    <asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion"></asp:BoundField>
                    <asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode"></asp:BoundField>
                    <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry"></asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#999999"></EditRowStyle>

                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="NorthwindDataSource" ConnectionString='<%$ ConnectionStrings:NorthwindConnectionString %>' OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Orders]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Orders] WHERE [OrderID] = @original_OrderID AND (([CustomerID] = @original_CustomerID) OR ([CustomerID] IS NULL AND @original_CustomerID IS NULL)) AND (([EmployeeID] = @original_EmployeeID) OR ([EmployeeID] IS NULL AND @original_EmployeeID IS NULL)) AND (([OrderDate] = @original_OrderDate) OR ([OrderDate] IS NULL AND @original_OrderDate IS NULL)) AND (([RequiredDate] = @original_RequiredDate) OR ([RequiredDate] IS NULL AND @original_RequiredDate IS NULL)) AND (([ShippedDate] = @original_ShippedDate) OR ([ShippedDate] IS NULL AND @original_ShippedDate IS NULL)) AND (([ShipVia] = @original_ShipVia) OR ([ShipVia] IS NULL AND @original_ShipVia IS NULL)) AND (([Freight] = @original_Freight) OR ([Freight] IS NULL AND @original_Freight IS NULL)) AND (([ShipName] = @original_ShipName) OR ([ShipName] IS NULL AND @original_ShipName IS NULL)) AND (([ShipAddress] = @original_ShipAddress) OR ([ShipAddress] IS NULL AND @original_ShipAddress IS NULL)) AND (([ShipCity] = @original_ShipCity) OR ([ShipCity] IS NULL AND @original_ShipCity IS NULL)) AND (([ShipRegion] = @original_ShipRegion) OR ([ShipRegion] IS NULL AND @original_ShipRegion IS NULL)) AND (([ShipPostalCode] = @original_ShipPostalCode) OR ([ShipPostalCode] IS NULL AND @original_ShipPostalCode IS NULL)) AND (([ShipCountry] = @original_ShipCountry) OR ([ShipCountry] IS NULL AND @original_ShipCountry IS NULL))" InsertCommand="INSERT INTO [Orders] ([CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate], [ShipVia], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], [ShipCountry]) VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)" UpdateCommand="UPDATE [Orders] SET [CustomerID] = @CustomerID, [EmployeeID] = @EmployeeID, [OrderDate] = @OrderDate, [RequiredDate] = @RequiredDate, [ShippedDate] = @ShippedDate, [ShipVia] = @ShipVia, [Freight] = @Freight, [ShipName] = @ShipName, [ShipAddress] = @ShipAddress, [ShipCity] = @ShipCity, [ShipRegion] = @ShipRegion, [ShipPostalCode] = @ShipPostalCode, [ShipCountry] = @ShipCountry WHERE [OrderID] = @original_OrderID AND (([CustomerID] = @original_CustomerID) OR ([CustomerID] IS NULL AND @original_CustomerID IS NULL)) AND (([EmployeeID] = @original_EmployeeID) OR ([EmployeeID] IS NULL AND @original_EmployeeID IS NULL)) AND (([OrderDate] = @original_OrderDate) OR ([OrderDate] IS NULL AND @original_OrderDate IS NULL)) AND (([RequiredDate] = @original_RequiredDate) OR ([RequiredDate] IS NULL AND @original_RequiredDate IS NULL)) AND (([ShippedDate] = @original_ShippedDate) OR ([ShippedDate] IS NULL AND @original_ShippedDate IS NULL)) AND (([ShipVia] = @original_ShipVia) OR ([ShipVia] IS NULL AND @original_ShipVia IS NULL)) AND (([Freight] = @original_Freight) OR ([Freight] IS NULL AND @original_Freight IS NULL)) AND (([ShipName] = @original_ShipName) OR ([ShipName] IS NULL AND @original_ShipName IS NULL)) AND (([ShipAddress] = @original_ShipAddress) OR ([ShipAddress] IS NULL AND @original_ShipAddress IS NULL)) AND (([ShipCity] = @original_ShipCity) OR ([ShipCity] IS NULL AND @original_ShipCity IS NULL)) AND (([ShipRegion] = @original_ShipRegion) OR ([ShipRegion] IS NULL AND @original_ShipRegion IS NULL)) AND (([ShipPostalCode] = @original_ShipPostalCode) OR ([ShipPostalCode] IS NULL AND @original_ShipPostalCode IS NULL)) AND (([ShipCountry] = @original_ShipCountry) OR ([ShipCountry] IS NULL AND @original_ShipCountry IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_OrderID" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_CustomerID" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_EmployeeID" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_OrderDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="original_RequiredDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="original_ShippedDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="original_ShipVia" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_Freight" Type="Decimal"></asp:Parameter>
                    <asp:Parameter Name="original_ShipName" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipAddress" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipCity" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipRegion" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipPostalCode" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipCountry" Type="String"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="CustomerID" Type="String"></asp:Parameter>
                    <asp:Parameter Name="EmployeeID" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="OrderDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="RequiredDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="ShippedDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="ShipVia" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Freight" Type="Decimal"></asp:Parameter>
                    <asp:Parameter Name="ShipName" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipAddress" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipCity" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipRegion" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipPostalCode" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipCountry" Type="String"></asp:Parameter>
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="CustomerID" Type="String"></asp:Parameter>
                    <asp:Parameter Name="EmployeeID" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="OrderDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="RequiredDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="ShippedDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="ShipVia" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Freight" Type="Decimal"></asp:Parameter>
                    <asp:Parameter Name="ShipName" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipAddress" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipCity" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipRegion" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipPostalCode" Type="String"></asp:Parameter>
                    <asp:Parameter Name="ShipCountry" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_OrderID" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_CustomerID" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_EmployeeID" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_OrderDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="original_RequiredDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="original_ShippedDate" Type="DateTime"></asp:Parameter>
                    <asp:Parameter Name="original_ShipVia" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="original_Freight" Type="Decimal"></asp:Parameter>
                    <asp:Parameter Name="original_ShipName" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipAddress" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipCity" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipRegion" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipPostalCode" Type="String"></asp:Parameter>
                    <asp:Parameter Name="original_ShipCountry" Type="String"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
