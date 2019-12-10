using APILibrary;
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
    public partial class FundAcct : System.Web.UI.Page
    {
        APICaller apc = new APICaller();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFund_Click(object sender, EventArgs e)
        {
            //I jerry rigged it to give out a walletuser to fix the problem here. Not sure if it works to well though. -Ieuan
           WalletUser funded = apc.FundAccount("vwID", txtFundAmount.Text);
            
        }
    }
}