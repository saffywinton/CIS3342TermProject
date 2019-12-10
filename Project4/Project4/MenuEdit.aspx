<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuEdit.aspx.cs" Inherits="Project4.MenuEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Edit An Item</h2>
    <form id="form1" runat="server">
        <div>
        <div>
            Name<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
            <p>
                Description<asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </p>
            <p>
                Price<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </p>
            <p>
                Type<asp:TextBox ID="txtType" runat="server"></asp:TextBox>
            </p>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
        </div>
    </form>
</body>
</html>
