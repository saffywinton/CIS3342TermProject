using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIClassLibrary

namespace Project4API.Controllers
{
    [Produces("application/json")]
    [Route("api/service/PaymentGateway")]
    public class PaymentGatewayController : Controller
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand;
        FillParameters fp = new FillParameters();

        [HttpGet("GetTransactions/{VirtualWalletID}/{MerchantAccountID}/{APIKEY}")]
        public List<Transactions> GetTransactions(int vwID, int maID, string apiKey)
        {
            //Check APIKEY

            ArrayList transactions = new ArrayList();

            DataSet ds = GetTransationsByVirtualWallet(vwID, maID);



            return transactions;
        }

        internal DataSet GetTransationsByVirtualWallet(int vwID, int maID)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetTransationsByVirtualWallet";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@virtualWallet", vwID)

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
    }
}