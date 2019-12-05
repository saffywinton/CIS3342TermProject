using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4Library
{
    class Transactions
    {
        public int transactionID { get; set; }
        public int senderWalletUserID { get; set; }
        public int receiverWalletUserID { get; set; }
        public float amount { get; set; }
        public string type { get; set; }
        public string date { get; set; }
    }
}
