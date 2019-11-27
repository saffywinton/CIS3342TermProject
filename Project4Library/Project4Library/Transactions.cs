using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4Library
{
    class Transactions
    {
        public int SenderWalletUserID { get; set; }
        public int ReceiverWalletUserID { get; set; }
        public float Amount { get; set; }
        public string Type { get; set; }
    }
}
