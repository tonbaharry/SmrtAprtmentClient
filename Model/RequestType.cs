using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmrtAprtmentClient.Model
{
    public class RequestType
    {
        [BindProperty]
        public int RequestId { get; set; }

        [BindProperty]
        public string RequestName { get; set; }
    }
}
