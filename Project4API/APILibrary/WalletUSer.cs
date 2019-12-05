using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibrary
{
    public class WalletUser
    {
        public int walletID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public float amount { get; set; }
        public string bankAccount { get; set; }
        public string bankRouting { get; set; }
    }
}
