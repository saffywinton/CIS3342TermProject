using Project4Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4
{
    public partial class RestaurantAcct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Restaurant r = (Restaurant)Session["User"];
                lblName.Text = "name";
                lblLogo.Text = "lolo";
                lblPhone.Text = "phone";
                lblType.Text = "type";
                lblPassword.Text = "type";
                txtName.Visible = false;
                txtLogo.Visible = false;
                txtPhone.Visible = false;
                txtType.Visible = false;
                txtPassword.Visible = false;
            }
           
        }

        protected void btnDoIt_Click(object sender, EventArgs e)
        {
            if (btnDoIt.Text == "Edit")
            {
                txtName.Visible = true;
                txtLogo.Visible = true;
                txtPhone.Visible = true;
                txtType.Visible = true;
                txtPassword.Visible = true;
                btnDoIt.Text = "Save";
                lblLogo.Visible = false;
                lblName.Visible = false;
                lblPhone.Visible = false;
                lblType.Visible = false;
                lblPassword.Visible = false;
                txtName.Text = lblName.Text;
                txtLogo.Text = lblLogo.Text;
                txtPhone.Text = lblPhone.Text;
                txtType.Text = lblType.Text;
                txtPassword.Text = lblPassword.Text;
            }
            else
            {
                btnDoIt.Text = "Edit";
                lblName.Text = txtName.Text;
                lblLogo.Text = txtLogo.Text;
                lblPhone.Text = txtPhone.Text;
                lblType.Text = txtType.Text;
                lblPassword.Text = txtPassword.Text;
                txtName.Text = "";
                txtLogo.Text = "";
                txtPhone.Text = "";
                txtType.Text = "";
                txtPassword.Text = "";
                txtName.Visible = false;
                txtLogo.Visible = false;
                txtPhone.Visible = false;
                txtType.Visible = false;
                txtPassword.Visible = false;
                lblLogo.Visible = true;
                lblName.Visible = true;
                lblPhone.Visible = true;
                lblType.Visible = true;
                lblPassword.Visible = true;
            }
        }
    }
}