<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestaurantManageMenu.aspx.cs" Inherits="Project4.RestaurantManageMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Menu Items</h2>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvMenu" runat="server">
                <Columns>
                    <asp:BoundField DataField="ItemID" Visible="false" ReadOnly="true" />
                     <asp:BoundField DataField="RestrauntID" Visible="false" ReadOnly="true" />
                    <asp:BoundField DataField="Name" HeaderText="Item Name" ReadOnly="true" />
                    <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="true" />
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="true" />
                    <asp:BoundField DataField="Image" HeaderText="Image" ReadOnly="true" />
                    <asp:BoundField DataField="Type" HeaderText="Type" ReadOnly="true" />
                    <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                            <asp:Button ID="btdEdit" runat="server" CausesValidation="false" CommandName="Edit"
                            Text="Edit" />
                    </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete"
                            Text="Delete" />
                    </ItemTemplate>
                        </
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
