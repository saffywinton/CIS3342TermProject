<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="CustomerCart.aspx.cs" Inherits="Project4.CustomerCart" %>

<%@ Register Src="~/ErrorLabel.ascx" TagPrefix="uc1" TagName="ErrorLabel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class ="row">
        <div class="col-3">
            <!-- This is deadspace -->
        </div>

        <div class="col-6" >

    Feel free to change any of the selected items before checkout. When done, click the checkout button located at the bottom of the page.
            <br />
            <uc1:ErrorLabel runat="server" ID="ErrorLabel" />
            <br />

    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" Style="margin:auto;" ShowFooter="True">
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
                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="name"/>
            <asp:BoundField HeaderText="Description" DataField="description"/>
            <asp:ImageField DataImageUrlField="image">
            </asp:ImageField>
            <asp:BoundField HeaderText="Price" DataField="price" DataFormatString="{0:c}"/>
            <asp:BoundField DataField="type" HeaderText="Type" />
            <asp:TemplateField HeaderText="Comments">
                <ItemTemplate>
                    <asp:TextBox ID="txtComments" runat="server" Text='<%# Bind("Comments") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnDelete" runat="server" Text="Delete Selected" style="color:red;" OnClick="btnDelete_Click"/>
    <asp:Button ID="btnClear" runat="server" Text="Clear Cart" style="color:red;" OnClick="btnClear_Click"/>
    <asp:Button ID="btnCheckOut" runat="server" Text="CheckOut" style="color:green;" OnClick="btnCheckOut_Click"/>
            </div>        
         <div class="col-3">
            <!-- This is deadspace -->
        </div>
    </div>
</asp:Content>
