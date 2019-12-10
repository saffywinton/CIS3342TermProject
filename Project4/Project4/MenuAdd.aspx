﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdd.aspx.cs" Inherits="Project4.MenuAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Add A Menu Item</h2>
    <form id="form1" runat="server">
        <div>
            Name<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <p>
            Description<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            Price<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            Type<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btnAdd" runat="server" Text="Add" />
    </form>
</body>
</html>
