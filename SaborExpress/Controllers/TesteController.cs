using Microsoft.AspNetCore.Mvc;

namespace SaborExpress.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Demo()
        {
            return View();
        }


    }
}
