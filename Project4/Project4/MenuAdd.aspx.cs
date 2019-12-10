using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project4Library;

namespace Project4
{
    public partial class MenuAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("AccessPage.aspx");
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Restaurant r = (Restaurant)
            SetData sd = new SetData();
            sd.CreateItem(1,0, txtName.Text, txtDescription.Text, txtPrice.Text, txtImage.Text, txtType.Text);
            Response.Write("<script>alert('Item Created');</script>");
            Response.Redirect("RestaurantManageMenu.aspx");
        }

     
    }
}