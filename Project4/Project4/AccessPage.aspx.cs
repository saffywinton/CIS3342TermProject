using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project4Library;

namespace Project4
{
    public partial class AccessPage : System.Web.UI.Page
    {
        GetData gd = new GetData();
        SetData sd = new SetData();
        LinkHolder lh = new LinkHolder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                TurnOffVisibilty();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                string username = txtLoginUsername.Text;
                string password = txtLoginPassword.Text;

                DataSet ds = gd.GetProfile(username);

                if (ds.Tables[0].Rows[0]["type"].Equals("Customer"))
                {
                    LogInAsCustomer(username);
                }
                else if (ds.Tables[0].Rows[0]["type"].Equals("Restaurant"))
                {
                    LogInAsRestaurant(username);
                }
                else
                {
                    lblError.Text = "User type is invalid, please contact support";
                }
            }

        }

        protected void btnSignUpCustomer_Click(object sender, EventArgs e)
        {
            if (ValidateCustomerSignUp())
            {
                DataSet ds;
                string firstName = txtSUCFirstName.Text;
                string lastName = txtSUCLastName.Text;
                string email = txtSUCEmail.Text;
                string password = txtSUCPassword.Text;
                string phoneNumber = txtSUCPhoneNumber.Text;
                string deliveryAddress = txtSUCDeliveryAddress.Text;
                string billingAddress = txtSUCBillingAddress.Text;

                ds = gd.GetProfile(email);
                //Makes sure that the email is not already in use
                if (ds.Tables[0].Rows.Count == 0)
                {

                    sd.CreateCustomer(email, password, "Customer", firstName, lastName, phoneNumber, deliveryAddress, billingAddress);

                    LogInAsCustomer(email);
                }
                else
                {
                    lblError.Text = "That email is already connected to an account";
                }
            }
        }

        protected void btnSignUpRestaurant_Click(object sender, EventArgs e)
        {
            if (ValidateRestaurantSignUp())
            {
                DataSet ds;
                string name = txtSURName.Text;
                string logo = txtSURLogo.Text;
                string email = txtSUREmail.Text;
                string password = txtSURPassword.Text;
                string phoneNumber = txtSURPhoneNumber.Text;
                string type = txtSURType.Text;

                ds = gd.GetProfile(email);
                //Makes sure that the email is not already in use
                if (ds.Tables[0].Rows.Count == 0)
                {
                    sd.CreateRestaurant(email, password, "Restaurant", name, logo, phoneNumber, type);

                    LogInAsRestaurant(email);
                }
                else
                {
                    lblError.Text = "That email is already connected to an account";
                }
            }
        }

        protected void btnSetUpLogin_Click(object sender, EventArgs e)
        {
            TurnOffVisibilty();
            Login.Visible = true;
            lblUserAction.Text = "You are logging in";
        }

        protected void btnSetUpSignUpCustomer_Click(object sender, EventArgs e)
        {
            TurnOffVisibilty();
            SignUpCustomer.Visible = true;
            lblUserAction.Text = "You are signing up as a customer";
        }

        protected void btnSetUpSignUpRestaurant_Click(object sender, EventArgs e)
        {
            TurnOffVisibilty();
            SignUpRestaurant.Visible = true;
            lblUserAction.Text = "You are signing up as a restaurant";
        }

        internal void TurnOffVisibilty()
        {
            Login.Visible = false;
            SignUpCustomer.Visible = false;
            SignUpRestaurant.Visible = false;
        }

        internal bool CheckIfTxtFilled(TextBox s)
        {
            if (s.Text.Equals(""))
            {
                return true;
            }
            return false;
        }

        internal bool ValidateLogin()
        {
            if (!CheckIfTxtFilled(txtLoginUsername))
            {
                FillError("Please fill in the email");
                return false;
            }
            else if (!CheckIfTxtFilled(txtLoginPassword))
            {
                FillError("Please fill in the password");
                return false;
            }
            FillError("");
            return true;
        }

        internal bool ValidateCustomerSignUp()
        {
            if (!CheckIfTxtFilled(txtSUCFirstName))
            {
                FillError("Please fill in the first name");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCLastName))
            {
                FillError("Please fill in the last name");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCEmail))
            {
                FillError("Please fill in the email");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCPassword))
            {
                FillError("Please fill in the password");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCPhoneNumber))
            {
                FillError("Please fill in the phonenumber");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCDeliveryAddress))
            {
                FillError("Please fill in the delivery address");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUCBillingAddress))
            {
                FillError("Please fill in the billing address");
                return false;
            }
            FillError("");
            return true;
        }

        internal bool ValidateRestaurantSignUp()
        {
            if (!CheckIfTxtFilled(txtSURName))
            {
                FillError("Please fill in the restaurant name");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSURLogo))
            {
                FillError("Please fill in the logo url");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSUREmail))
            {
                FillError("Please fill in the email");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSURPassword))
            {
                FillError("Please fill in the password");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSURPhoneNumber))
            {
                FillError("Please fill in the phone number");
                return false;
            }
            else if (!CheckIfTxtFilled(txtSURType))
            {
                FillError("Please fill in the type");
                return false;
            }
            FillError("");
            return true;
        }

        internal void FillError(string s)
        {
            lblError.Text = s;
        }

        internal Customer CreateCustomer(string uid, string fn, string ln, string em, string pa, string pn, string ba, string da, string apik)
        {
            Customer c = new Customer();
            c.UserID = uid;
            c.FirstName = fn;
            c.LastName = ln;
            c.Email = em;
            c.PhoneNumber = pn;
            c.DeliveryAddress = da;
            c.BillingAddress = ba;
            c.APIKey = apik;
            return c;
        }

        internal Restaurant CreateRestaurant(string uid, string name, string logo, string pn, string type, string apik)
        {
            Restaurant r = new Restaurant();
            r.userID = uid;
            r.name = name;
            r.logo = logo;
            r.phoneNumber = pn;
            r.type = type;
            r.apiKey = apik;

            return r;
        }

        internal void LogInAsCustomer(string email)
        {
            DataSet user = gd.GetProfile(email);
            DataSet customer = gd.GetCustomer(user.Tables[0].Rows[0]["userID"].ToString());
            DataSet key = gd.GetAPIKey();

            Customer c = CreateCustomer(
                user.Tables[0].Rows[0]["userID"].ToString(),
                customer.Tables[0].Rows[0]["firstname"].ToString(),
                customer.Tables[0].Rows[0]["lastname"].ToString(),
                user.Tables[0].Rows[0]["email"].ToString(),
                user.Tables[0].Rows[0]["password"].ToString(),
                customer.Tables[0].Rows[0]["phoneNumber"].ToString(),
                customer.Tables[0].Rows[0]["billingAddress"].ToString(),
                customer.Tables[0].Rows[0]["deliveryAddress"].ToString(),
                key.Tables[0].Rows[0]["APIKey"].ToString());
            Session["User"] = c;

            Response.Redirect(lh.RestaurantSelection);
        }

        internal void LogInAsRestaurant(string email)
        {
            DataSet user = gd.GetProfile(email);
            DataSet restaurant = gd.GetCustomer(user.Tables[0].Rows[0]["userID"].ToString());
            DataSet key = gd.GetAPIKey();

            Restaurant r = CreateRestaurant(
                user.Tables[0].Rows[0]["userID"].ToString(),
                restaurant.Tables[0].Rows[0]["name"].ToString(),
                restaurant.Tables[0].Rows[0]["logo"].ToString(),
                restaurant.Tables[0].Rows[0]["phoneNumber"].ToString(),
                restaurant.Tables[0].Rows[0]["type"].ToString(),
                key.Tables[0].Rows[0]["APIKey"].ToString());
            Session["User"] = r;

            //Redirect to RestaurantSplashPage
        }
    }
}