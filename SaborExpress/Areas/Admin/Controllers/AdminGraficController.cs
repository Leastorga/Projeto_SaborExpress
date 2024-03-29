﻿using Microsoft.AspNetCore.Mvc;
using SaborExpress.Areas.Admin.Services;

namespace SaborExpress.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficController : Controller
    {
        private readonly SalesServiceChart _salesGrafic;

        public AdminGraficController(SalesServiceChart salesGrafic)
        {
            _salesGrafic = salesGrafic ?? throw
                new ArgumentNullException(nameof(salesGrafic)); ;
        }
        public JsonResult SnacksSales(int days)
        {
            var snacksTotalSales = _salesGrafic.GetSnacksSales(days);
            return Json(snacksTotalSales);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MonthlySales()
        {
            return View();
        }
        [HttpGet]
        public IActionResult WeeklySales()
        {
            return View();
        }
    }
}
