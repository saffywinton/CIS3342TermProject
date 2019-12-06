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

namespace Project4Library
{
    public class APICaller
    {
        private string url = "";

        public WalletUser GetWalletUser(string email)
        {
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(url + "GetWalletUser/ " + email);
            WebResponse response = request.GetResponse();
            
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // Deserialize a JSON string into a double.
            JavaScriptSerializer js = new JavaScriptSerializer();
            WalletUser result = js.Deserialize<WalletUser>(data);

            return result;
        }
    }
}
