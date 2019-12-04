using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibrary
{
    public class VirtualWalletTransactions
    {
        public int transactionID { get; set; }
        public int senderWalletUserID { get; set; }
        public int receiverWalletUserID { get; set; }
        public float amount { get; set; }

    }
}
