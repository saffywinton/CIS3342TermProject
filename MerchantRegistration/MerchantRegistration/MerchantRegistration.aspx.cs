using APILibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentRegistration
{
    public partial class MerchantRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Merchant m = new Merchant();
            m.name = txtMerchantName.Text;
            m.email = txtEmail.Text;
            m.password = txtPassword.Text;
            m.URL = txtWebsiteURL.Text;
            m.bankAccount = txtAccount.Text;
            m.bankRouting = txtRouting.Text;

            // Create an HTTP Web Request and get the HTTP Web Response from the server.

            WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Users/tug90052/CIS3342/api/service/PaymentGateway/" + m);

            WebResponse response = request.GetResponse();



            // Read the data from the Web Response, which requires working with streams.

            Stream theDataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();

            response.Close();
            if(data != "")
            {
                Response.Write("<script>alert('Account Created!');</script>");
                txtMerchantName.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtWebsiteURL.Text = "";
                txtAccount.Text = "";
                txtRouting.Text = "";
            }
        }
    }
    }