using System;
using System.Collections.Generic;
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

        }
        protected void gvMenu_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //Get rowindex
                int rowindex = Convert.ToInt32(e.CommandArgument);
               
                int itemID = Convert.ToInt32(gvMenu.Rows[rowindex].Cells[0].Text);
                int restrauntID = Convert.ToInt32(gvMenu.Rows[rowindex].Cells[1].Text);

            }
            else if (e.CommandName == "Edit")
            {
                //Get rowindex
                int rowindex = Convert.ToInt32(e.CommandArgument);

                int itemID = Convert.ToInt32(gvMenu.Rows[rowindex].Cells[0].Text);
                int restrauntID = Convert.ToInt32(gvMenu.Rows[rowindex].Cells[1].Text);
            }
    }
}