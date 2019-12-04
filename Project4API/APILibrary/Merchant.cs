using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibrary
{
    public class Merchant
    {
        public int merchantID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string bankInfo { get; set; }
        public string apiKey { get; set; }
    }
}
