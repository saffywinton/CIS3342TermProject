using DoorGrubMate.DoorGrubLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoorGrubMate
{
    public partial class CustomerMaster : System.Web.UI.MasterPage
    {

        LinkHolder lh = new LinkHolder();

        private const int PRICECOLUMN = 2;

        protected void Page_Load(object sender, EventArgs e)
        {

           

            if (Session["User"] == null)
            {
                Response.Redirect(lh.SplashPage);
            }
            User user = (User)Session["User"];

            //Sets up the user cart
            Cart cart;
            if (Session["Cart"] == null)
            {
                cart = (Cart)Session["Cart"];
            }
            else
            {
                cart = new Cart();
            }
            //-----------------------

            gvCart.DataSource = cart;
            gvCart.DataBind();
            gvCart.Columns[PRICECOLUMN].FooterText = cart.GetCartTotal().ToString();
            gvCart.Columns[PRICECOLUMN - 1].FooterText = "Total:";

        }

        protected void btnToRestaurantList_Click(object sender, EventArgs e)
        {
            Response.Redirect(lh.RestaurantSelection);
        }

        protected void btnToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect(lh.Cart);
        }

        protected void btnToProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect(lh.Profile);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session["Cart"] = null;
            Response.Redirect(lh.SplashPage);
        }
    }
}