using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmrtAprtmentClient.Model
{
    public class Property
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public string formerName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string market { get; set; }
        public string state { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Properties
    {
        public Property property { get; set; }
    }
}
