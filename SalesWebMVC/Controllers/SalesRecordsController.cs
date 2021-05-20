using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? init, DateTime? final)
        {
            if (!init.HasValue) init = new DateTime(2018, 9, 1);
            if (!final.HasValue) final = new DateTime(2018, 10, 31);

            ViewData["InitDate"] = init.Value.ToString("dd/MM/yyyy");
            ViewData["FinalDate"] = final.Value.ToString("yyyy/MM/dd");

            var sales = await _salesRecordService.FindByDateAsync(init, final);
            return View(sales);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? init, DateTime? final)
        {
            if (!init.HasValue) init = new DateTime(2018, 9, 1);
            if (!final.HasValue) final = new DateTime(2018, 10, 31);

            ViewData["InitDate"] = init.Value.ToString("yyyy/MM/dd");
            ViewData["FinalDate"] = final.Value.ToString("yyyy/MM/dd");

            var sales = await _salesRecordService.FindByDateGroupingAsync(init, final);
            return View(sales);
        }
    }
}
