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
        const int COMMENTSROW  = 8;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                int totalQuantity = 0;
                float total = 0;

                Cart cart = (Cart)Session["Cart"];
                gvCart.DataSource = cart.GetList();
                gvCart.DataBind();

                for (int i = 0; i < cart.GetSize(); i++)
                {
                    totalQuantity = totalQuantity + int.Parse(gvCart.Rows[i].Cells[QUANTITYROW].Text);
                    total = total + float.Parse(gvCart.Rows[i].Cells[PRICEROW].Text, System.Globalization.NumberStyles.Currency);
                }

                gvCart.Columns[QUANTITYROW - 1].FooterText = "Total Quantity";
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

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ArrayList rowNums = GetRowNumbers();
            Cart cart = (Cart)Session["Cart"];
            cart.DeleteIndexs(rowNums);
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
                        gvMenu.Rows[i].Cells[COMMENTSROW].Text
                        );
                    cart.ModCart("Add", item);

                }
            }
        }

        internal Item CreateItem(string iID, string na, string de, string pr, string im, string type, string c)
        {
            Item i = new Item();

            i.ItemID = iID;
            i.Name = na;
            i.Description = de;
            i.Price = float.Parse(pr);
            i.Image = im;
            i.Type = type;
            i.Comments = c;

            return i;
        }
    }
}