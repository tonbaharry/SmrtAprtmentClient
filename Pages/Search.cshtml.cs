using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmrtAprtmentClient.Model;

namespace SmrtAprtmentClient.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ILogger<SearchModel> _logger;
        private readonly IConfiguration _configuration;

        public SearchModel(ILogger<SearchModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IList<Management> imanagement { get; set; }
        public IList<Properties> iproperty { get; set; }
        [BindProperty]
        public string SearchQuery { get; set; }
        public List<RequestType> requestTypes { get; set; }
        public bool isResult { get; set; }

        public async Task<IActionResult> OnPostAsync(int type_)
        {
            string validateResult = validateData(type_, SearchQuery);
            this.requestTypes = APIClient.Request.PopulateRequestTypes();
            var accessToken = HttpContext.Session.GetString("LoginResponse");
            if (string.IsNullOrEmpty(validateResult))
            {
                
                switch (requestTypes.Where(x => x.RequestId.Equals(type_)).ToList()[0].RequestName)
                {
                    case "Management":
                        imanagement = await APIClient.Request.GetManagementAsync(_configuration["APIBaseUrl"] + "SearchManagement?query=" + SearchQuery, accessToken); 
                        break;
                    case "Properties":
                        iproperty = await APIClient.Request.GetPropertiesAsync(_configuration["APIBaseUrl"] + "SearchProperty?query=" + SearchQuery, accessToken); 
                        break;
                }
                

                if (!ModelState.IsValid)
                {
                    return Page();
                }
                isResult = true;
                
                return Page();
            }
            else
            {
                TempData["PostBackMessage"] = "<script>alert('" + validateResult + "');</script>";
                return Page();
            }
        }

        public async Task OnGetAsync()
        {
            var accessToken = HttpContext.Session.GetString("LoginResponse");
            if(accessToken == null)
            {
                Redirect("./Login");
            }
            this.isResult = false;
            this.requestTypes = APIClient.Request.PopulateRequestTypes();
        }

        private string validateData(int type, string searchQuery)
        {
            if(type == 0)
              return "Tick the Request Type you desire";
            if (string.IsNullOrEmpty(searchQuery))
                return "Kindly enter the search keyword before proceeding";
            return String.Empty;
        }
    }
}
