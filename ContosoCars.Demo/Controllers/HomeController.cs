using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoCars.Demo.Models;

namespace ContosoCars.Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            Console.WriteLine(User.Identity.Name);
            Dictionary<string, string> claims = new Dictionary<string, string>();

            foreach (var item in ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims)
            {
                if (item.Properties.Count >0 )
                {
                    foreach (var prop in item.Properties)
                    {
                        claims.Add(prop.Value, item.Value);
                        break;
                    }
                }
                else
                {
                    claims.Add(item.Type, item.Value);
                }
            }

            ViewBag.Claims = claims;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
