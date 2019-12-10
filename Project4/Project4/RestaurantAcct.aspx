<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestaurantAcct.aspx.cs" Inherits="Project4.RestaurantAcct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <a href="RestaurantManageMenu.aspx">Manage Menu</a>
    <a href="FundAccount.aspx">Fund Account</a>
    <h2>Account Info</h2>
    <p>&nbsp;</p>
    <form id="form1" runat="server">
        <p>Wallet Balance:
            <asp:Label ID="lblBalance" runat="server"></asp:Label>
        </p>
        <div>
            <asp:Label runat="server" Text="Restaurant Name: "></asp:Label>
            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Logo URL: "></asp:Label>
            <asp:Label ID="lblLogo" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txtLogo" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Phone Number: "></asp:Label>
            <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Restaurant Category: "></asp:Label>
            <asp:Label ID="lblType" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="Password"></asp:Label>
            <asp:Label ID="lblPassword" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btnDoIt" runat="server" OnClick="btnDoIt_Click" Text="Edit" />
    </form>
</body>
</html>
