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
        const int name = 3;
        const int description = 4;
        const int image = 5;
        const int price = 6;
        const int comments = 7;
        const int quantity = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Ensures that the user came here from the RestaurantSelection page so the menu can be filled
            if (!IsPostBack)
            {
                if (Session["Restaurant"] != null)
                {
                    int restaurantID = int.Parse(Session["Restaurant"].ToString());
                    DataSet appetizers = gd.GetMenu(restaurantID, "Appetizers");
                    DataSet drinks = gd.GetMenu(restaurantID, "Drinks");
                    DataSet entrees = gd.GetMenu(restaurantID, "Entrees");
                    DataSet salads = gd.GetMenu(restaurantID, "Salads");
                    DataSet others = gd.GetMenu(restaurantID, "Others");

                    gvAppetizers.DataSource = appetizers;
                    gvAppetizers.DataBind();
                    gvDrinks.DataSource = drinks;
                    gvDrinks.DataBind();
                    gvEntrees.DataSource = entrees;
                    gvEntrees.DataBind();
                    gvSalads.DataSource = salads;
                    gvSalads.DataBind();
                    gvOthers.DataSource = others;
                    gvOthers.DataBind();
                }
                else
                {
                    Response.Redirect(lh.RestaurantSelection);
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            Cart cart = new Cart();

            FillCartFromGridView(ref cart, gvAppetizers);
            FillCartFromGridView(ref cart, gvDrinks);
            FillCartFromGridView(ref cart, gvEntrees);
            FillCartFromGridView(ref cart, gvSalads);

            if (cart.GetSize() > 0)
            {
                Session["Cart"] = cart;
                Response.Redirect(lh.Cart);
            }
            else
            {
                //lblError.Text = "No items were selected";
            }
        }

        internal void FillCartFromGridView(ref Cart cart, GridView gvMenu)
        {
            for (int i = 0; i < gvMenu.Rows.Count; i++)
            {
                CheckBox cbox;

                cbox = (CheckBox)gvMenu.Rows[i].FindControl("chkSelect");
                lblError.Text = gvMenu.Caption;
                if (cbox.Checked)
                {

                    Item item = CreateItem(
                        gvMenu.Rows[i].Cells[itemID].Text,
                        gvMenu.Rows[i].Cells[name].Text,
                        gvMenu.Rows[i].Cells[description].Text,
                        (float.Parse(gvMenu.Rows[i].Cells[price].Text) * float.Parse(((TextBox)gvMenu.Rows[i].FindControl("txtQuantity")).Text)).ToString(),
                        gvMenu.Rows[i].Cells[image].Text,
                        gvMenu.Caption,
                        ((TextBox)gvMenu.Rows[i].FindControl("txtComments")).Text,
                        ((TextBox)gvMenu.Rows[i].FindControl("txtQuantity")).Text
                        );
                    cart.Add(item);

                }
            }
        }


        internal Item CreateItem(string iID, string na, string de, string pr, string im, string type, string c, string q)
        {
            Item i = new Item();

            i.ItemID = iID;
            i.Name = na;
            i.Description = de;
            i.Price = float.Parse(pr);
            i.Image = im;
            i.Type = type;
            i.Comments = c;
            i.Quantity = int.Parse(q);

            return i;
        }
    }
}