using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PVPK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVPK.Controllers
{
    public class PageController : Controller
    {
        private readonly dbMarketsContext _context;
        public PageController(dbMarketsContext context)
        {
            _context = context;
        }
        //[Route("blogs.html", Name = "Blog")]
        //public IActionResult Index(int? page)
        //{
        //    var pageNumber = page == null || page <= 0 ? 1 : page.Value;
        //    var pageSize = 10;
        //    var lsTinDangs = _context.TinDangs
        //        .AsNoTracking()
        //        .OrderByDescending(x => x.PostId);
        //    PagedList<TinDang> models = new PagedList<TinDang>(lsTinDangs, pageNumber, pageSize);
        //    ViewBag.CurrentPage = pageNumber;
        //    return View(models);
        //}

        [Route("/page/{Alias}", Name = "PageDetails")]
        public IActionResult Details(string Alias)
        {
            if (string.IsNullOrEmpty(Alias)) return RedirectToAction("Index", "Home");
            var page = _context.Pages.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
            if (page == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(page);
        }
    }
}
