using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmrtAprtmentClient.Model
{
    public class SearchViewModel: PageModel
    {
        
        public List<Management> management { get; set; }
        public List<Properties> properties { get; set; }
    }
}
