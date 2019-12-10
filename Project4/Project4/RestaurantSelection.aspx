<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantSelection.aspx.cs" Inherits="Project4.RestaurantSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Stylesheets/TableSheet.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class ="row">
        <div class="col-3">
            <!-- This is deadspace -->
        </div>

        <div class="col-6" style="background-color:grey">
            <div class="row">
                <div class="col">
                    <asp:DropDownList ID="ddlType" runat="server" style="width:100%;">
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" Text="Search by Type" OnClick="btnSearch_Click" />
                </div>
                <div class="col">
                    <asp:TextBox ID="txtKeyword" runat="server" style="width:100%;"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button ID="btnSearchKeyword" runat="server" Text="Search by Keyword" OnClick="btnSearchKeyword_Click"/>
                </div>
            </div>
        </div>
        <div class="col-3">
            <!-- This is deadspace -->
        </div>
    </div>
    <div class ="row">
        <div class="col-3">
            <!-- This is deadspace -->
        </div>
        <div class="col-6">
            <asp:GridView ID="gvRestaurantList" runat="server" AutoGenerateColumns="false" style="margin:auto">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblRestaurantID" runat="server" Text='<%# Eval("restaurantID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ImageField DataImageUrlField="logo" HeaderText="Logo" ItemStyle-Width="50px" ControlStyle-Height="100" ControlStyle-Width="100">
                    </asp:ImageField>
                    <asp:BoundField HeaderText="Name" DataField="name"/>
                    <asp:BoundField HeaderText="Type" DataField="type" />
                    <asp:BoundField HeaderText="Phone Number" DataField="phoneNumber" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" runat="server" Text="Select" OnClientClick="return CheckUser()" OnClick="btnSelect_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
        <div class="col-3">
            <!-- This is space for the cart -->

        </div>
    </div>

    <script>
    function CheckUser() {
        return confirm("If you already have a cart, it will be deleted. Are you sure you want to do this?");
    }
</script>
</asp:Content>