using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4
{
    public partial class AccessPage : System.Web.UI.Page
    {
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

        }

        protected void btnSignUpCustomer_Click(object sender, EventArgs e)
        {

        }

        protected void btnSignUpRestaurant_Click(object sender, EventArgs e)
        {

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
    }
}