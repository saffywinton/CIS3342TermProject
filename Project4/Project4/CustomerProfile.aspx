<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="Project4.CustomerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="Stylesheets/TableSheet.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6" style="text-align:center;">
            <asp:Table ID="tblSignUpCustomer" runat="server" style="margin:auto;" Class="TableCenter">
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
            <asp:Button ID="btnUpdateAccount" runat="server" Text="Update Account" />
        </div>
        <div class="col-6" style="text-align:center;">
            You currently have :<asp:TextBox ID="txtAccountBalance" runat="server" ReadOnly="true"></asp:TextBox> in your account.
            <br />
            Want to add money to your account? Enter the infomation below.
            <asp:Table ID="tblAddFunds" runat="server" Class="TableCenter">
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
        </div>
    </div>
</asp:Content>
