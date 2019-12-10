<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessPage.aspx.cs" Inherits="Project4.AccessPage" %>

<%@ Register Src="~/ErrorLabel.ascx" TagPrefix="uc1" TagName="ErrorLabel" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="Stylesheets/UtilitySheet.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-3">

            </div>
            <div class="col-6" style="text-align:center;">
                <asp:Button ID="btnSetUpLogin" runat="server" Text="Login" OnClick="btnSetUpLogin_Click" />
                <asp:Button ID="btnSetUpSignUpCustomer" runat="server" Text="Sign Up Customer" OnClick="btnSetUpSignUpCustomer_Click" />
                <asp:Button ID="btnSetUpSignUpRestaurant" runat="server" Text="Sign Up Restaurant" OnClick="btnSetUpSignUpRestaurant_Click" />
                <br />
                <asp:Label ID="lblUserAction" runat="server" Text=""></asp:Label>
                <br />
                <uc1:ErrorLabel runat="server" id="ErrorLabel" />
                <br />
                <asp:Panel ID="Login" runat="server" Visible="true">
                    <asp:Table ID="tblLogin" runat="server" style="margin:auto;">
                        <asp:TableRow>
                            <asp:TableCell>
                                Email:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtLoginUsername" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Password:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" />
                    <br />
                    <a href="ForgotPass.aspx">Forgot Password?</a>
                </asp:Panel>
                <asp:Panel ID="SignUpCustomer" runat="server" Visible="true">
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
                    <br />
                    <asp:Button ID="btnSignUpCustomer" runat="server" Text="SignUp" />
                </asp:Panel>
                <asp:Panel ID="SignUpRestaurant" runat="server" Visible="true">
                    <asp:Table ID="tlbSignUpRestaurant" runat="server" style="margin:auto;">
                        <asp:TableRow>
                            <asp:TableCell>
                                Restaurant Name:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSURName" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Logo URL:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSURLogo" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Email:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSUREmail" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Password:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSURPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                PhoneNumber:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSURPhoneNumber" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Type of Restaurant:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSURType" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Bank Routing Number
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSURRouting" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Bank Account Number
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSURAccount" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Button ID="btnSignUpRestaurant" runat="server" Text="SignUp" />
                </asp:Panel>
            </div>
            <div class="col-3">

            </div>
        </div>
    </form>
</body>
</html>
