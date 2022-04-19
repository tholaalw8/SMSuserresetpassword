using Microsoft.AspNetCore.Mvc;
using SMSuserresetpassword.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Text;

namespace SMSuserresetpassword.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async  Task<IActionResult> Index()
        {


            User user = new User();


           
            user.getAduser();
            Console.WriteLine("waiting....");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}