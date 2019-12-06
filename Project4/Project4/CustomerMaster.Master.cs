using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project4Library;

namespace Project4
{
    public partial class CustomerMaster : System.Web.UI.MasterPage
    {
        LinkHolder lh = new LinkHolder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] == null)
            {
                //UncommentThisWhenProject is done
                //Response.Redirect(lh.AccessPage);
            }
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
            Response.Redirect(lh.CustomerProfile);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session["Restaurant"] = null;
            Session["Cart"] = null;
            Response.Redirect(lh.AccessPage);
        }
    }
}