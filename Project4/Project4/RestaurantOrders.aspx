<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestaurantOrders.aspx.cs" Inherits="Project4.RestaurantOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Manage Orders</h2>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" OnRowCommand="gvOrders_OnRowCommand" OnSelectedIndexChanged="gvOrders_SelectedIndexChanged" ShowHeader="False">
                <Columns>
                     <asp:BoundField DataField="OrderID" Visible="false" ReadOnly="true" />
                <asp:BoundField DataField="Name" HeaderText="Restraunt Name" ReadOnly="true" />
                    <asp:BoundField DataField="Name" HeaderText="Customer Name" ReadOnly="true" />
                    <asp:BoundField DataField="time" HeaderText="Order Tme" ReadOnly="true" />
                    <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="true" />
                    <asp:TemplateField HeaderText="XYZ">
                        <ItemTemplate>
                    <asp:DropDownList runat="server" ID="ddStatus" DataSourceId="MyDataSource" />
                    </ItemTemplate> 
                    </asp:TemplateField>
                     <asp:TemplateField ShowHeader="False">
                      <ItemTemplate>
                            <asp:Button ID="btnStatus" runat="server" CausesValidation="false" CommandName="EditStatus"
                            Text="Update Status" />
                    </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
                    </asp:GridView>
        </div>
    </form>
</body>
</html>
