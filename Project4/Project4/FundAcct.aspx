<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FundAcct.aspx.cs" Inherits="Project4.FundAcct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Fund Your Account</h2>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFunds" runat="server" Text="Transfer Amount:"></asp:Label>
            <asp:TextBox ID="txtFundAmount" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnFund" runat="server" OnClick="btnFund_Click" Text="Add Funds" />
    </form>
</body>
</html>
