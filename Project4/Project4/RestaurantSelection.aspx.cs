using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project4Library;

namespace Project4
{
    public partial class RestaurantSelection : System.Web.UI.Page
    {
        GetData gd = new GetData();
        LinkHolder lh = new LinkHolder();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet restaurant = gd.GetRestaurants();
            gvRestaurantList.DataSource = restaurant;
            gvRestaurantList.DataBind();
        }

        protected void gvRestaurantList_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                String restaurantNum = gvRestaurantList.DataKeys[rowIndex].Value.ToString();
                Session["Restaurant"] = restaurantNum;
                Response.Redirect(lh.RestaurantMenu);
            }
        }
    }
}