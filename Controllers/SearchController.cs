using Microsoft.AspNetCore.Mvc;
using SmrtAprtmentClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmrtAprtmentClient.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            return View();
        }
    }
}
