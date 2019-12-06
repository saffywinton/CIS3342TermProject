<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantMenu.aspx.cs" Inherits="Project4.RestaurantMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="Stylesheets/TableSheet.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblError" runat="server" Text="" Style="color:red;"></asp:Label>
    <br />
    <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" Class="TableCenter">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="itemID" Visible="false" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="name"/>
            <asp:BoundField HeaderText="Description" DataField="description"/>
            <asp:ImageField DataImageUrlField="image">
            </asp:ImageField>
            <asp:BoundField HeaderText="Price" DataField="Price"/>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnAddToCart" runat="server" Text="Add items to cart" OnClick="btnAddToCart_Click" />

</asp:Content>