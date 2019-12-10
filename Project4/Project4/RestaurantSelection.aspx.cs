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
            if (!IsPostBack)
            {
                DataSet restaurant = gd.GetRestaurants();
                gvRestaurantList.DataSource = restaurant;
                gvRestaurantList.DataBind();


                DataSet types = gd.GetRestaurantType();
                ddlType.DataValueField = types.Tables[0].Columns["type"].ToString();
                ddlType.DataTextField = types.Tables[0].Columns["type"].ToString();
                ddlType.DataBind();
            }
        }

        protected void gvRestaurantList_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                String restaurantNum = ((Label)gvRestaurantList.Rows[rowIndex].FindControl("lblRestaurantID")).Text;
                Session["Restaurant"] = restaurantNum;
                Response.Redirect(lh.RestaurantMenu);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string type = ddlType.SelectedValue;

            DataSet restaurant = gd.GetRestaurants(type);
            gvRestaurantList.DataSource = restaurant;
            gvRestaurantList.DataBind();
        }

        protected void btnSearchKeyword_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text;

            DataSet restaurant = gd.GetLikeRestaurants(keyword);
            gvRestaurantList.DataSource = restaurant;
            gvRestaurantList.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Session["Cart"] = null;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label restaurantNumlbl = (Label)gvRestaurantList.Rows[gvr.DataItemIndex].FindControl("lblRestaurantID");
            int restaurantNum = int.Parse(restaurantNumlbl.Text);
            Session["Restaurant"] = restaurantNum;
            Response.Redirect(lh.RestaurantMenu);
        }
    }
}