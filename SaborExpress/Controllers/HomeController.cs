using Microsoft.AspNetCore.Mvc;
using SaborExpress.Models;
using System.Diagnostics;

namespace SaborExpress.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index() // Está retornando o view ao acessar a página, isso se deve a interface IActionResult
        {
            TempData["Name"] = "Lele";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
