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
                    vwt.date = ds.Tables[0].Rows[i]["date"].ToString();
                    vwt.type = ds.Tables[0].Rows[i]["type"].ToString();

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
                    vwt.date = ds.Tables[0].Rows[i]["date"].ToString();
                    vwt.type = ds.Tables[0].Rows[i]["type"].ToString();
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
            fp.AddParameter(ref objCommand, "@url", m.URL);
            fp.AddParameter(ref objCommand, "@bankRounting", m.bankRouting);
            fp.AddParameter(ref objCommand, "@bankAccount", m.bankAccount);
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
        [HttpPost("CreateVirtualWallet/{AccountHolderInformation}/{MerchantAccountID}/{APIKey}")]
        public object CreateVirtualWallet(WalletUser AccountHolderInformation, int
         MerchantAccountID, string APIKey)
        {
            //Check if API key matches
            if (CheckAPIKey(MerchantAccountID, APIKey))
            {
           
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreateWalletUser";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@email", AccountHolderInformation.email);
            fp.AddParameter(ref objCommand, "@password", AccountHolderInformation.password);
            fp.AddParameter(ref objCommand, "@bankRounting", AccountHolderInformation.bankRouting);
            fp.AddParameter(ref objCommand, "@bankAccount", AccountHolderInformation.bankAccount);
            fp.AddParameter(ref objCommand, "@amount", 0);

            objDB.DoUpdateUsingCmdObj(objCommand);

                //get virtual wallet ID
                //Gets a new SQL Command object
                objCommand = new SqlCommand();

                //Sets which stored procedure the command object will use
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetWalletID";
                DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
                return ds.Tables[0].Rows[0]["WalletID"].ToString();
            }
            return -1;
        }

        [HttpPost("ProcessPayment/{VirtualWalletIDPay}/{VirtualWalletIDCharge}/{amount}/{type}/{MerchantAccountID}/{APIKey}")]
        public object ProcessPayment(int VirtualWalletIDPay, int VirtualWalletIDCharge, float
         amount, string type, int MerchantAccountID, string APIKey)

        {
            //Check if API key matches
            if (CheckAPIKey(MerchantAccountID, APIKey))
            {
              
                    
                    if (GetAccountBalance(VirtualWalletIDPay) >= amount)
                    {
                    //update sender balance
                        FundAccount(VirtualWalletIDPay, (-amount), MerchantAccountID, APIKey);
                        //update receiver balance
                        FundAccount(VirtualWalletIDPay, amount, MerchantAccountID, APIKey);
                        //record transaction
                        RecordTransaction(VirtualWalletIDPay, VirtualWalletIDCharge, amount, type);
                    }
                return 1;
            }
                
                return -1;
        }

        [HttpPut("FundAccount/{VirtualWalletID}/{amount}/{MerchantAccountID}/{APIKey}")]
        public object FundAccount(int VirtualWalletID, float amount, int
        MerchantAccountID, string APIKey)


        {
            //Check if API key matches
            if (CheckAPIKey(MerchantAccountID, APIKey))
            {
                float balanceBefore = GetAccountBalance(VirtualWalletID);
                float newBalance = balanceBefore + amount;

                //Adds new balance to user's account

                //Gets a new SQL Command object
                objCommand = new SqlCommand();

                //Sets which stored procedure the command object will use
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_FundAccount";

                //Inputs parameters to the command object
                fp.AddParameter(ref objCommand, "@virtualWalletID", VirtualWalletID);

                fp.AddParameter(ref objCommand, "@amount", newBalance.ToString());


                objDB.DoUpdateUsingCmdObj(objCommand);
                RecordTransaction(-1, VirtualWalletID, amount, "fund");
                return 1;
            }

            return -1;
        }

        //Gets current account balance
        internal float GetAccountBalance(int VirtualWalletID)
        {
           
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAccountBalance";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@virtualWalletID", VirtualWalletID);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            float balanceBefore = float.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
            return balanceBefore;
        }
        internal int RecordTransaction(int Sender, int Receiver, float amount, string type)
        {
            //Gets a new SQL Command object
            objCommand = new SqlCommand();

            //Sets which stored procedure the command object will use
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_RecordTransaction";

            //Inputs parameters to the command object
            fp.AddParameter(ref objCommand, "@sender", Sender);
            fp.AddParameter(ref objCommand, "@receiver", Receiver);
            fp.AddParameter(ref objCommand, "@type", type);
            fp.AddParameter(ref objCommand, "@amount", amount.ToString());
            fp.AddParameter(ref objCommand, "@date", DateTime.Today.ToShortDateString() + " " + DateTime.Today.ToShortTimeString());

            return objDB.DoUpdateUsingCmdObj(objCommand);
           
        }
    }
}