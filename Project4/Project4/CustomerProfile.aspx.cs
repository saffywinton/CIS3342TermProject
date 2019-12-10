using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using APILibrary;
using Project4Library;

namespace Project4
{
    public partial class CustomerProfile : System.Web.UI.Page
    {
        APICaller apic = new APICaller();
        SetData sd = new SetData();
        GetData gd = new GetData();

        protected void Page_Load(object sender, EventArgs e)
        {
            WalletUser wu = new WalletUser();
            Customer c = (Customer)Session["User"];

            wu = apic.GetWalletUser(c.Email);
            wu.email = c.Email;
            wu.password = c.Password;

            txtAccountBalance.Text = "$" + wu.amount.ToString();

            txtSUCBillingAddress.Text = c.BillingAddress;
            txtSUCDeliveryAddress.Text = c.DeliveryAddress;
            txtSUCEmail.Text = c.Email;
            txtSUCFirstName.Text = c.FirstName;
            txtSUCLastName.Text = c.LastName;
            txtSUCPassword.Text = c.Password;
            txtSUCPhoneNumber.Text = c.PhoneNumber;
            txtSUCRouting.Text = wu.bankRouting;
            txtSUCAccount.Text = wu.bankAccount;

            if (!IsPostBack)
            {
                DataSet ds = gd.GetOrders(int.Parse(c.UserID));

                gvPreviousOrders.DataSource = ds;
                gvPreviousOrders.DataBind();
            }
        }

        protected void btnUpdateAccount_Click(object sender, EventArgs e)
        {

            Customer c = (Customer)Session["User"];

            if (ValidateProfileInfo())
            {
                sd.UpdateCustomer(c.UserID, txtSUCEmail.Text, txtSUCPassword.Text, txtSUCFirstName.Text, txtSUCLastName.Text, txtSUCPhoneNumber.Text, txtSUCDeliveryAddress.Text, txtSUCBillingAddress.Text);
                apic.UpdatePaymentAccount(c.WalletID.ToString(), txtSUCEmail.Text, txtSUCPassword.Text, txtSUCAccount.Text, txtSUCRouting.Text);
            }
        }

        internal bool ValidateProfileInfo()
        {
            if (!CheckIfTxtFilled(txtSUCFirstName))
            {
                ErrorLabel.FillError("Please fill in the first name");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCLastName))
            {
                ErrorLabel.FillError("Please fill in the last name");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCEmail))
            {
                ErrorLabel.FillError("Please fill in the email");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCPassword))
            {
                ErrorLabel.FillError("Please fill in the password");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCPhoneNumber))
            {
                ErrorLabel.FillError("Please fill in the phonenumber");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCDeliveryAddress))
            {
                ErrorLabel.FillError("Please fill in the delivery address");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCBillingAddress))
            {
                ErrorLabel.FillError("Please fill in the billing address");
                return false;
            }
            ErrorLabel.FillError("");
            return true;
        }

        internal bool CheckIfTxtFilled(TextBox s)
        {
            if (s.Text.Equals(""))
            {
                return true;
            }
            return false;
        }

        protected void btnAddFunds_Click(object sender, EventArgs e)
        {
            Customer c = (Customer)Session["User"];
            if (CheckPassword())
            {
                if (CheckFundsBeingAdded())
                {
                    apic.FundAccount(c.WalletID, txtAddFunds.Text);
                }
            }
        }

        internal bool CheckPassword()
        {
            Customer c = (Customer)Session["User"];

            if (txtPasswordCheck.Text.Equals(c.Password))
            {
                ErrorLabel.FillError("");
                return true;
            }
            else
            {
                ErrorLabel.FillError("That is the wrong password");
                return false;
            }
        }

        internal bool CheckFundsBeingAdded()
        {
            float value;
            if (txtAddFunds.Text.Equals(""))
            {
                if (float.TryParse(txtAddFunds.Text, out value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}