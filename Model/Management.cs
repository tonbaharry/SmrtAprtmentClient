using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmrtAprtmentClient.Model
{
    public class Mgmt
    {
        public int mgmtID { get; set; }
        public string name { get; set; }
        public string market { get; set; }
        public string state { get; set; }
    }

    public class Management
    {
        public Mgmt mgmt { get; set; }

    }
}
