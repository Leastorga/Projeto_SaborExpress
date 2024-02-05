using Microsoft.AspNetCore.Mvc;
using SaborExpress.Areas.Admin.Services;

namespace SaborExpress.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSalesReportsController : Controller
    {
        private readonly SalesServiceReport salesServiceReport;

        public AdminSalesReportsController(SalesServiceReport _salesServiceReport)
        {
            salesServiceReport = _salesServiceReport;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSalesReport(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await salesServiceReport.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
    }
}
