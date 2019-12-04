<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="RestarantSelection.aspx.cs" Inherits="Project4.RestarantSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <asp:GridView ID="gvRestaurantList" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvRestaurantList_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Name" />
                    <asp:BoundField HeaderText="Type" />
                    <asp:BoundField HeaderText="Description" />
                    <asp:ButtonField Text="Select" />
                </Columns>

            </asp:GridView>
        </div>
        <div class="col-3">
            <!-- This is space for the cart -->

        </div>
    </div>
</asp:Content>
