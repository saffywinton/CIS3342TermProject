using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4
{
    public partial class ErrorLabel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        internal void FillError(string s)
        {
            lblError.Text = s;
        }
    }
}