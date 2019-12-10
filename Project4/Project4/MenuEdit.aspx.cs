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
    public partial class MenuEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("AccessPage.aspx");
            }
            if (!IsPostBack)
            {
                GetData gd = new GetData();
                DataSet ds = gd.GetItem(Session["getItemID"].ToString());
                txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                txtImage.Text = ds.Tables[0].Rows[0]["Image"].ToString();
                txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                txtType.Text = ds.Tables[0].Rows[0]["Type"].ToString();
                int rid = Convert.ToInt32(ds.Tables[0].Rows[0]["RestrauntID"]);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GetData gd = new GetData();
            DataSet ds = gd.GetItem(Session["getItemID"].ToString());
            SetData sd = new SetData();
            sd.UpdateItem(Session["getItemID"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["RestrauntID"]), txtName.Text, txtDescription.Text, txtPrice.Text, txtImage.Text, txtType.Text);
            Response.Write("<script>alert('Item Updated');</script>");
            Response.Redirect("RestaurantManageMenu.aspx");
        }
    }
}