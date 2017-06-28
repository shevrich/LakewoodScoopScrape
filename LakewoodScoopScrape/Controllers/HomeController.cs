using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LakewoodScoopScrape.Models;
using LakewoodScoop.Api;

namespace LakewoodScoopScrape.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ScoopViewModel vm = new ScoopViewModel();
            LkwdScoopScraper scraper = new LkwdScoopScraper();
            vm.Items = scraper.GetItems();
            return View(vm);
        }
    }
}