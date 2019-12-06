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
    public partial class RestaurantMenu : System.Web.UI.Page
    {
        GetData gd = new GetData();
        LinkHolder lh = new LinkHolder();

        const int itemID = 1;
        const int name = 4;
        const int description = 5;
        const int image = 6;
        const int price = 7;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Ensures that the user came here from the RestaurantSelection page so the menu can be filled
            if (Session["Restaurant"] != null)
            {
                DataSet menu = gd.GetMenu(Session["Restaurant"].ToString());
                gvMenu.DataSource = menu;
                gvMenu.DataBind();
            }
            else
            {
                Response.Redirect(lh.RestaurantSelection);
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            Cart cart = new Cart();
            bool itemAdded = false;

            for(int i = 0; i < gvMenu.Rows.Count; i++)
            {
                CheckBox cbox;

                cbox = (CheckBox)gvMenu.Rows[i].FindControl("chkSelect");

                if (cbox.Checked)
                {
                    Item item = CreateItem(
                        gvMenu.Rows[i].Cells[itemID].Text,
                        gvMenu.Rows[i].Cells[name].Text,
                        gvMenu.Rows[i].Cells[description].Text,
                        gvMenu.Rows[i].Cells[price].Text,
                        gvMenu.Rows[i].Cells[image].Text
                        );
                    cart.ModCart("Add", item);
                    itemAdded = true;
                }
            }
            if (itemAdded)
            {
                Session["Cart"] = cart;
                Response.Redirect(lh.Cart);
            }
            else
            {
                lblError.Text = "No items were selected";
            }
        }

        internal Item CreateItem(string iID, string na, string de, string pr, string im)
        {
            Item i = new Item();

            i.ItemID = iID;
            i.Name = na;
            i.Description = de;
            i.Price = float.Parse(pr);
            i.Image = im;

            return i;
        }
    }
}