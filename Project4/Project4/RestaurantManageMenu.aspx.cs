using Project4Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4
{
    public partial class RestaurantManageMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData gd = new GetData();
            if (!IsPostBack && Session["User"] != null)
            {
                int restaurantID = int.Parse(Session["Restraunt"].ToString());
                DataSet orders = gd.GetMenu(restaurantID, "Appetizers");
                DataSet drinks = gd.GetMenu(restaurantID, "Drinks");
                DataSet entrees = gd.GetMenu(restaurantID, "Entrees");
                DataSet salads = gd.GetMenu(restaurantID, "Salads");
                DataSet others = gd.GetMenu(restaurantID, "Others");
                orders.Merge(drinks);
                orders.Merge(entrees);
                orders.Merge(salads);
                orders.Merge(others);
                gvMenu.DataSource = orders;
                gvMenu.DataBind();
            }
            else { 
            Response.Redirect("AccessPage.aspx");
            }
        }
        protected void gvMenu_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //Get rowindex
                int rowindex = Convert.ToInt32(e.CommandArgument);

                int itemID = Convert.ToInt32(gvMenu.Rows[rowindex].Cells[0].Text);
                int restrauntID = Convert.ToInt32(gvMenu.Rows[rowindex].Cells[1].Text);
                SetData sd = new SetData();
                sd.DeleteItem(itemID.ToString());
            }
            else if (e.CommandName == "Edit")
            {
                //Get rowindex
                int rowindex = Convert.ToInt32(e.CommandArgument);

                int itemID = Convert.ToInt32(gvMenu.Rows[rowindex].Cells[0].Text);
                int restrauntID = Convert.ToInt32(gvMenu.Rows[rowindex].Cells[1].Text);
                Session["getItemID"] = itemID;
                Response.Redirect("MenuEdit.aspx");

            }
        }
    }
}