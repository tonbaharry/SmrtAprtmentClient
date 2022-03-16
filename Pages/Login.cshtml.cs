using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmrtAprtmentClient.Model;

namespace SmrtAprtmentClient.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly IConfiguration _configuration;
        public LoginResponse loginResponse { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public LoginModel(ILogger<LoginModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            string validateLogin = validateData();
            if (string.IsNullOrEmpty(validateLogin))
            {
                var request = new LoginRequest
                {
                    UserName = UserName,
                    Password = Password
                };
                loginResponse = await APIClient.Request.LoginAsync(_configuration["APIBaseUrl"] + "api/Auth/login", request);
            }

            if (string.IsNullOrEmpty( loginResponse.Token))
            {
                TempData["PostBackMessage"] = "<script>alert('Login Failed');</script>";
                return Page();
            }
            HttpContext.Session.SetString("LoginResponse", loginResponse.Token); 
            // return Page();
            return RedirectToPage("./Search");
        }

        private string validateData()
        {
            if(string.IsNullOrEmpty(UserName))
            {
                return "Kindly provide user name before Login";
            }

            if (string.IsNullOrEmpty(Password))
            {
                return "Kindly provide Password before Login";
            }
            return String.Empty;
        }
    }
}
