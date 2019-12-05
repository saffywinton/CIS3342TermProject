<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantRegistration.aspx.cs" Inherits="PaymentRegistration.MerchantRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!-- Required meta tags-->
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Colorlib Templates">
    <meta name="author" content="Colorlib">
    <meta name="keywords" content="Colorlib Templates">

    <!-- Title Page-->
    <title>Merchant Registration</title>

    <!-- Icons font CSS-->
    <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">
    <link href="vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <!-- Font special for pages-->
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet">

    <!-- Vendor CSS-->
    <link href="vendor/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="vendor/datepicker/daterangepicker.css" rel="stylesheet" media="all">

    <!-- Main CSS-->
    <link href="css/main.css" rel="stylesheet" media="all">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script >
     
        var validate = function () {
            if ($("#txtMerchantName").val() == "" ) {
                alert("Must enter a merchant name");
                return false;
            } else if ($("#txtWebsiteURL").val() == "") {
                alert("Must enter a website URL");
                return false;
            }else if ($("#txtEmail").val() == "") {
                alert("Must enter an email");
                return false;
            }else if ($("#txtPassword").val() == "") {
                alert("Must enter a password");
                return false;
            }else if ($("#txtRouting").val() == "") {
                alert("Must enter a routing number");
                return false;
            }else if ($("#txtAccount").val() == "") {
                alert("Must enter an account number");
                return false;
            }
          
            return true;
        };
    
    </script>
   
</head>
<body>
    <div class="page-wrapper bg-red p-t-180 p-b-100 font-robo">
        <div class="wrapper wrapper--w960">
            <div class="card card-2">
                <div class="card-heading"></div>
                <div class="card-body">
                    <h2 class="title">Register a New Merchant</h2>
                    <form id="form1" runat="server">
         
                        <div class="input-group">
                            <asp:Textbox type="text" class="input--style-2" id="txtMerchantName" placeholder="Merchant Name"
                       runat="server"/>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Textbox type="text" class="form-control" id="txtWebsiteURL" placeholder="Merchant Website URL"
                           runat="server"/>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:Textbox type="email" class="form-control" id="txtEmail" placeholder="Merchant Email"
                           runat="server"/>
                                </div>
                            </div>
                        </div>
                        <div class="input-group">
                             <asp:Textbox class="form-control" id="txtPassword" placeholder="Password"
                           runat="server"/>
                        </div>
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                 <asp:Textbox type="text" class="form-control" id="txtRouting" placeholder="Bank Routing Number"
                           runat="server"/>                                </div>
                            </div>
                            <div class="col-2">
                                <div class="input-group">
                                   <asp:Textbox class="form-control" id="txtAccount" placeholder="Bank Account Number"
                           runat="server"/>                             </div>
                            </div>
                        </div>
                        <div class="p-t-30">
                           <asp:Button  ID="btnRegister" class="btn btn--radius btn--green" type="submit" Text="Register" runat="server" OnClientClick="return validate();" OnClick="btnRegister_Click" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Jquery JS-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <!-- Vendor JS-->
    <script src="vendor/select2/select2.min.js"></script>
    <script src="vendor/datepicker/moment.min.js"></script>
    <script src="vendor/datepicker/daterangepicker.js"></script>

    <!-- Main JS-->
    <script src="js/global.js"></script>
       

</body>
</html>
