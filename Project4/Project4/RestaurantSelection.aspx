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
                </div>
                <div class="col">
                    <asp:TextBox ID="txtKeyword" runat="server" style="width:100%;"></asp:TextBox>
                </div>
                <div class="col">
                    <asp:Button ID="btnSearch" runat="server" Text="Search"/>
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
            <asp:GridView ID="gvRestaurantList" runat="server" AutoGenerateColumns="false" Class="TableCenter">
                <Columns>
                    <asp:BoundField HeaderText="RestaurantID" Visible="false"/>
                    <asp:TemplateField HeaderText="Logo">
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgLogo"></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Name" />
                    <asp:BoundField HeaderText="Type" />
                    <asp:BoundField HeaderText="Description" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" runat="server" Text="Select" OnClientClick="return CheckUser()"/>
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