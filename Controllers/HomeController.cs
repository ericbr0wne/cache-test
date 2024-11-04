using System;
using Microsoft.AspNetCore.Mvc;

namespace chache_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly CacheService _cacheService;

        public HomeController(CacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public IActionResult Index()
        {
            var cachedDateTime = _cacheService.GetOrSetCurrentDateTime(); 
            Console.WriteLine("TWHAA");
            ViewBag.CachedDateTime = cachedDateTime; 
            return View();
        }
    }
}
