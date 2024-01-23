using Microsoft.AspNetCore.Mvc;

namespace SaborExpress.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
