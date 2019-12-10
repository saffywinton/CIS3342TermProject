<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="Project4.ForgotPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Recover Account Info</h2>
   <h5>To recover your account, please enter your email</h5>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label4" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <p>
        <asp:Button ID="btnRecover" runat="server" Text="Recover" OnClick="btnRecover_Click" />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to Login" />
        </p>
        <p>
            <asp:Label ID="lblEmail" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
