using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project4Library;

namespace Project4
{
    public partial class CustomerCart : System.Web.UI.Page
    {
        const int IDROW = 1;
        const int QUANTITYROW = 2;
        const int NAMEROW = 3;
        const int DESCRIPTIONROW = 4;
        const int IMAGEROW = 5;
        const int PRICEROW = 6;
        const int TYPEROW = 7;
        const int COMMENTSROW = 8;

        APICaller apic = new APICaller();
        SetData sd = new SetData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ErrorLabel.FillError("");

                if (Session["Cart"] != null)
                {
                    int totalQuantity = 0;
                    float total = 0;

                    Cart cart = (Cart)Session["Cart"];
                    gvCart.DataSource = cart.GetList();
                    gvCart.DataBind();

                    for (int i = 0; i < cart.GetSize(); i++)
                    {
                        totalQuantity = totalQuantity + int.Parse(((TextBox)gvCart.Rows[i].FindControl("txtQuantity")).Text);
                        total = total + float.Parse(gvCart.Rows[i].Cells[PRICEROW].Text.Substring(1));
                    }

                    gvCart.Columns[0].FooterText = "Total Quantity";
                    gvCart.Columns[QUANTITYROW].FooterText = totalQuantity.ToString();
                    gvCart.Columns[PRICEROW - 1].FooterText = "Total Price:";
                    gvCart.Columns[PRICEROW].FooterText = total.ToString();

                    gvCart.DataBind();
                }
                else
                {
                    ErrorLabel.FillError("Your cart is empty, please select some items and comeback.");
                    btnCheckOut.Visible = false;
                    btnClear.Visible = false;
                    btnDelete.Visible = false;
                }
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                Cart CheckOutCart = new Cart();
                FillCartFromGridView(ref CheckOutCart, gvCart);
                Customer user = (Customer)Session["User"];
                string restaurantNum = Session["Restaurant"].ToString();

                apic.ProcessPayment(user.WalletID, restaurantNum, CheckOutCart.GetCartTotal().ToString(), "Payment");

                Session["Cart"] = null;

                sd.CreateOrder(int.Parse(user.UserID), int.Parse(restaurantNum), CheckOutCart);

                ErrorLabel.FillError("Your order has been placed successfully");
            }
            catch
            {
                ErrorLabel.FillError("An error occured while processing your payment. You may not have enough money. Please go to your profile and add funds. Then you can return here and place your order.");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ArrayList rowNums = GetRowNumbers();
            Cart cart = (Cart)Session["Cart"];
            cart.DeleteIndexs(rowNums);
            Session["Cart"] = cart;
            gvCart.DataSource = cart.GetList();
            gvCart.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ErrorLabel.FillError("Your cart has been deleted");
            Session["Cart"] = null;
        }

        internal ArrayList GetRowNumbers()
        {
            ArrayList rowNums = new ArrayList();

            for (int i = 0; i < gvCart.Rows.Count; i++)
            {
                CheckBox cbox;

                cbox = (CheckBox)gvCart.Rows[i].FindControl("chkSelect");

                if (cbox.Checked)
                {
                    rowNums.Add(i);
                }
            }
            return rowNums;
        }

        internal void FillCartFromGridView(ref Cart cart, GridView gvMenu)
        {
            for (int i = 0; i < gvMenu.Rows.Count; i++)
            {
                CheckBox cbox;

                cbox = (CheckBox)gvMenu.Rows[i].FindControl("chkSelect");

                if (cbox.Checked)
                {
                    Item item = CreateItem(
                        gvMenu.Rows[i].Cells[IDROW].Text,
                        gvMenu.Rows[i].Cells[NAMEROW].Text,
                        gvMenu.Rows[i].Cells[DESCRIPTIONROW].Text,
                        gvMenu.Rows[i].Cells[PRICEROW].Text,
                        gvMenu.Rows[i].Cells[IMAGEROW].Text,
                        gvMenu.Rows[i].Cells[TYPEROW].Text,
                        ((TextBox)gvMenu.Rows[i].FindControl("txtComments")).Text,
                        ((TextBox)gvMenu.Rows[i].FindControl("txtQuantity")).Text
                        );
                    cart.ModCart("Add", item);

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