<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantMenu.aspx.cs" Inherits="Project4.RestaurantMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="Stylesheets/TableSheet.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lblError" runat="server" Text="" Style="color:red;"></asp:Label>
    <br />
    <asp:GridView ID="gvAppetizers" runat="server" AutoGenerateColumns="False" style="margin:auto" Caption="Appetizers">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="itemID" runat="server" Text='<%# Eval("itemID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="name"/>
            <asp:BoundField HeaderText="Description" DataField="description"/>
            <asp:ImageField DataImageUrlField="image" ControlStyle-Height="100" ControlStyle-Width="100">
            </asp:ImageField>
            <asp:BoundField HeaderText="Price" DataField="price"/>
            <asp:TemplateField HeaderText="Comments">
                <ItemTemplate>
                    <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

       <asp:GridView ID="gvSalads" runat="server" AutoGenerateColumns="False" style="margin:auto" Caption="Salads">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="itemID" runat="server" Text='<%# Eval("itemID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="name"/>
            <asp:BoundField HeaderText="Description" DataField="description"/>
            <asp:ImageField DataImageUrlField="image" ControlStyle-Height="100" ControlStyle-Width="100">
            </asp:ImageField>
            <asp:BoundField HeaderText="Price" DataField="price"/>
            <asp:TemplateField HeaderText="Comments">
                <ItemTemplate>
                    <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

        <asp:GridView ID="gvEntrees" runat="server" AutoGenerateColumns="False" style="margin:auto" Caption="Entrees">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="itemID" runat="server" Text='<%# Eval("itemID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="name"/>
            <asp:BoundField HeaderText="Description" DataField="description"/>
            <asp:ImageField DataImageUrlField="image" ControlStyle-Height="100" ControlStyle-Width="100">
            </asp:ImageField>
            <asp:BoundField HeaderText="Price" DataField="price"/>
            <asp:TemplateField HeaderText="Comments">
                <ItemTemplate>
                    <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

        <asp:GridView ID="gvDrinks" runat="server" AutoGenerateColumns="False" style="margin:auto" Caption="Drinks">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="itemID" runat="server" Text='<%# Eval("itemID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="name"/>
            <asp:BoundField HeaderText="Description" DataField="description"/>
            <asp:ImageField DataImageUrlField="image" ControlStyle-Height="100" ControlStyle-Width="100">
            </asp:ImageField>
            <asp:BoundField HeaderText="Price" DataField="price"/>
            <asp:TemplateField HeaderText="Comments">
                <ItemTemplate>
                    <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

        <asp:GridView ID="gvOthers" runat="server" AutoGenerateColumns="False" style="margin:auto" Caption="Other">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="itemID" runat="server" Text='<%# Eval("itemID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="1"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="name"/>
            <asp:BoundField HeaderText="Description" DataField="description"/>
            <asp:ImageField DataImageUrlField="image" ControlStyle-Height="100" ControlStyle-Width="100">
            </asp:ImageField>
            <asp:BoundField HeaderText="Price" DataField="price"/>
            <asp:TemplateField HeaderText="Comments">
                <ItemTemplate>
                    <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnAddToCart" runat="server" Text="Add items to cart" OnClick="btnAddToCart_Click" />

</asp:Content>