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
    public partial class ForgotPass : System.Web.UI.Page
    {
        GetData gd = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecover_Click(object sender, EventArgs e)
        {
            DataSet ds = gd.GetProfile(txtEmail.Text);
            Email objEmail = new Email();

            String strTO = txtEmail.Text;

            String strFROM = "Admin@doorgrub.com";

            String strSubject = "Your Password";

            



            try

            {
                String strMessage = "Your password is: " + ds.Tables[0].Rows[0]["password"];
                objEmail.SendMail(strTO, strFROM, strSubject, strMessage);

                lblEmail.Text = "Your password has been sent to your email address";

            }

            catch (Exception ex)

            {

                lblEmail.Text = "This email does not exist";

            }
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccessPage.aspx");
        }
    }
}