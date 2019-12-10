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
    public partial class RestaurantOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData gd = new GetData();
            if (!IsPostBack && Session["User"] != null)
            {
                int restaurantID = int.Parse(Session["Restraunt"].ToString());
                DataSet orders = gd.GetOrders(restaurantID);
                gvOrders.DataSource = orders;
                gvOrders.DataBind();
            }
            else
            {
                Response.Redirect("AccessPage.aspx");
            }
        }
        protected void gvOrders_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditStatus")
            {
                //Get rowindex
                int rowindex = Convert.ToInt32(e.CommandArgument);
                //Get Row
                DropDownList ddl = (DropDownList)gvOrders.Rows[rowindex].FindControl("ddStatus");
                int orderID = Convert.ToInt32(gvOrders.Rows[rowindex].Cells[0].Text);
                string newStatus = ddl.SelectedValue.ToString();
            }
        }

    }
}