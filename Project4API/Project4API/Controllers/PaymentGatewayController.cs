using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APILibrary;

namespace Project4API.Controllers
{
    [Produces("application/json")]
    [Route("api/service/PaymentGateway")]
    public class PaymentGatewayController : Controller
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand;
        FillParameters fp = new FillParameters();

        //Returns all transactions that involved a particular account
        [HttpGet("GetTransactions/{VirtualWalletID}/{MerchantAccountID}/{APIKEY}")]
        public ArrayList GetTransactions(int vwID, int maID, string apiKey)
        {
            ArrayList transactions = new ArrayList();

            if (CheckAPIKey(maID, apiKey))
            {
                DataSet ds = GetIncomingTransationsByVirtualWallet(vwID);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    VirtualWalletTransactions vwt = new VirtualWalletTransactions();
                    vwt.transactionID = int.Parse(ds.Tables[0].Rows[i]["transactionID"].ToString());
                    vwt.senderWalletUserID = int.Parse(ds.Tables[0].Rows[i]["senderWalletUserID"].ToString());
                    vwt.receiverWalletUserID = int.Parse(ds.Tables[0].Rows[i]["receiverWalletUserID"].ToString());
                    vwt.amount = float.Parse(ds.Tables[0].Rows[i]["amount"].ToString());
                    transactions.Add(vwt);
                }

                ds = GetOutGoingTransationsByVirtualWallet(vwID);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    VirtualWalletTransactions vwt = new VirtualWalletTransactions();
                    vwt.transactionID = int.Parse(ds.Tables[0].Rows[i]["transactionID"].ToString());
                    vwt.senderWalletUserID = int.Parse(ds.Tables[0].Rows[i]["senderWalletUserID"].ToString());
                    vwt.receiverWalletUserID = int.Parse(ds.Tables[0].Rows[i]["receiverWalletUserID"].ToString());
                    vwt.amount = -1 * float.Parse(ds.Tables[0].Rows[i]["amount"].ToString());
                    transactions.Add(vwt);
                }

                return transactions;
            }
            return null;
        }

        //Allows the user to update their email and password in the virtual wallet database
        [HttpPut("UpdatePaymentAccount/{VirtualWalletID}/{AccountHolderInfomation}/{MerchantAccountID}/{APIKEY}")]
        public int UpdatePaymentAccount(int vwID, WalletUser accountInfo, int maID, string apiKey)
        {
            if (CheckAPIKey(maID, apiKey))
            {
                return UpdateWalletAccount(vwID, accountInfo);
            }
            return -1;
        }

        //Creates a merchant
        [HttpGet("CreateMerchant/{MerchantAccount}")]
        public string CreateMerchant(Merchant m)
        {
            ApiKeyCreator akc = new ApiKeyCreator();
            m.apiKey = akc.GetKey();

            MerchantDatabaseEntry(m);

            return m.apiKey;
        }

        internal int MerchantDatabaseEntry(Merchant m)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateMerchant";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@email", m.email);
            fp.AddParameter(ref objCommand, "@password", m.password);
            fp.AddParameter(ref objCommand, "@name", m.name);
            fp.AddParameter(ref objCommand, "@bankInfo", m.bankInfo);
            fp.AddParameter(ref objCommand, "@apiKey", m.apiKey);

            return objDB.DoUpdateUsingCmdObj(objCommand);

        }

        internal int UpdateWalletAccount(int vwID, WalletUser accountInfo)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateVirtualWallet";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@virtualWallet", vwID);

            fp.AddParameter(ref objCommand, "@email", accountInfo.email);
            fp.AddParameter(ref objCommand, "@password", accountInfo.password);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        internal DataSet GetOutGoingTransationsByVirtualWallet(int vwID)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetOutGoingTransationsByVirtualWallet";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@SenderVirtualWallet", vwID);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        internal DataSet GetIncomingTransationsByVirtualWallet(int vwID)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetIncomingTransationsByVirtualWallet";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@ReceiverVirtualWallet", vwID);

            //Returns the DataSet
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        //Checks if the APIKey matches the merchantID
        internal bool CheckAPIKey(int merchantID, string apiKey)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAPIKEY";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@merchantID", merchantID);
            fp.AddParameter(ref objCommand, "@apiKey", apiKey);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            if(ds.Tables[0].Rows.Count != 0)
            {
                return true;
            }
            return false;
        }
    }
}