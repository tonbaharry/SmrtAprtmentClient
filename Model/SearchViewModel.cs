using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmrtAprtmentClient.Model
{
    public class SearchViewModel: PageModel
    {
        public IEnumerable<SearchViewModel> SearchViewModels { get; set; }
        public Management management { get; set; }
        public Properties properties { get; set; }
    }
}
