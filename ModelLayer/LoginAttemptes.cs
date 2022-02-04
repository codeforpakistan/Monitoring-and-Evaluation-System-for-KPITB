using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class LoginAttemptes
    {
        public int ID { get; set; }
        public int LoginCount { get; set; }
        public string HostName { get; set; }
        public string IPv4Address { get; set; }
        public string BrowserName { get; set; }
        public string MACAddress { get; set; }
        public bool? IsLocked { get; set; }
        public DateTime? EntryDateTime { get; set; }
        public DateTime? LoginDateTime { get; set; }
        public DateTime? NextLoginDateTime { get; set; }
        public int? User_ID { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
