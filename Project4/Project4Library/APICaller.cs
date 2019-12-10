using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Data;                      // needed for DataSet class
using APILibrary;
using System.Collections;

namespace Project4Library
{
    public class APICaller
    {
        GetData gd = new GetData();
        Serializor serial = new Serializor();

        private string url = "http://cis-iis2.temple.edu/Fall2019/CIS3342_tug90052/TermProjectWS/api/service/PaymentGateway/";

        public WalletUser GetWalletUser(string email)
        {
            string name = "GetWalletUser/ ";

            String data = ProcessWebRequest(name, email);

            // Deserialize a JSON string
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<WalletUser>(data);
        }

        public void ProcessPayment(string senderID, string recieverID,string amount, string type)
        {
            string apiKey = GetAPIKey();
            string merchantID = GetMerchantID();
            string name = "ProcessPayment/";
            string vars = senderID + "/" + recieverID + "/" + amount + "/" + type + "/" + merchantID + "/" + apiKey;

            ProcessWebRequest(name, vars);
        }

        public void UpdatePaymentAccount(string account, string email, string pass, string bankA, string bankR)
        {
            string apiKey = GetAPIKey();
            string merchantID = GetMerchantID();
            string name = "UpdatePaymentAccount/";

            WalletUser wu = new WalletUser();
            wu.email = email;
            wu.password = pass;
            wu.bankAccount = bankA;
            wu.bankRouting = bankR;

            byte[] byteArray = serial.serializeObject(wu);

            string vars = wu + "/" + merchantID + "/" + apiKey;

            ProcessWebRequest(name, vars);
        }

        public void FundAccount(string account, string amount)
        {
            string apiKey = GetAPIKey();
            string merchantID = GetMerchantID();
            string name = "FundAccount/";
            string vars = account + "/" + amount + "/" + merchantID + "/" + apiKey;

            ProcessWebRequest(name, vars);
        }

        public int CreateWalletUser(string account, string email, string pass, string bankA, string bankR)
        {
            string apiKey = GetAPIKey();
            string merchantID = GetMerchantID();
            string name = "CreateVirtualWallet/";

            WalletUser wu = new WalletUser();
            wu.email = email;
            wu.password = pass;
            wu.bankAccount = bankA;
            wu.bankRouting = bankR;
            wu.amount = 0;

            byte[] byteArray = serial.serializeObject(wu);

            string vars = wu + "/" + merchantID + "/" + apiKey;

            String data = ProcessWebRequest(name, vars);
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<int>(data);
        }

        public ArrayList GetTransactions(string acount)
        {
            string apiKey = GetAPIKey();
            string merchantID = GetMerchantID();
            string name = "GetTransactions/";

            string vars = merchantID + "/" + apiKey;

            String response = ProcessWebRequest(name, vars);
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<ArrayList>(response);
        }

        internal string GetAPIKey()
        {
            DataSet apiTable = gd.GetAPIKey();
            return apiTable.Tables[0].Rows[0]["APIKey"].ToString();
        }

        internal string GetMerchantID()
        {
            DataSet apiTable = gd.GetAPIKey();
            return apiTable.Tables[0].Rows[0]["MerchantID"].ToString();
        }

        internal String ProcessWebRequest(string methodName, string variables)
        {
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(url + methodName + variables);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return data;
        }
    }
}
