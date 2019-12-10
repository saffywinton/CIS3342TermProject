<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="Project4.CustomerProfile" %>

<%@ Register Src="~/ErrorLabel.ascx" TagPrefix="uc1" TagName="ErrorLabel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="Stylesheets/TableSheet.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;">
    <uc1:ErrorLabel runat="server" id="ErrorLabel"/>
    </div>
    <div class="row">
        <div class="col-6" style="text-align:center;">
            <asp:Table ID="tblSignUpCustomer" runat="server" style="margin:auto;">
                <asp:TableRow>
                    <asp:TableCell>
                        First Name
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSUCFirstName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Last Name:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSUCLastName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Email:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSUCEmail" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Password:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSUCPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        PhoneNumber:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSUCPhoneNumber" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Delivery Address:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSUCDeliveryAddress" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Billing Address
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSUCBillingAddress" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Bank Routing Number
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSUCRouting" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Bank Account Number
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSUCAccount" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Button ID="btnUpdateAccount" runat="server" Text="Update Account" OnClick="btnUpdateAccount_Click" />
        </div>
        <div class="col-6" style="text-align:center;">
            You currently have :<asp:TextBox ID="txtAccountBalance" runat="server" ReadOnly="true"></asp:TextBox> in your account.
            <br />
            Want to add money to your account? Enter the infomation below.
            <asp:Table ID="tblAddFunds" runat="server" style="margin:auto">
                <asp:TableRow>
                    <asp:TableCell>
                        Ammount you want to add:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtAddFunds" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Password:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtPasswordCheck" runat="server" TextMode="Password"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Button ID="btnAddFunds" runat="server" Text="Add Funds" OnClick="btnAddFunds_Click" />

            <br />
            <h2> Previous Orders </h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="AJAXPanel" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvPreviousOrders" runat="server" AutoGenerateColumns="False" style="margin:auto">
                        <Columns>
                            <asp:BoundField DataField="OrderID" Visible="false" />
                            <asp:BoundField DataField="Restaurant Name" HeaderText="Restaurant Name" />
                            <asp:BoundField DataField="Total" HeaderText="Total Price" />
                            <asp:BoundField DataField="Date" HeaderText="Order Date" />
                            <asp:BoundField DataField="Status" HeaderText="Current Status" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
