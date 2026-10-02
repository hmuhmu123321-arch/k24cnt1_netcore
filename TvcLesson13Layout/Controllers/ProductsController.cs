using Microsoft.AspNetCore.Mvc;

namespace TvcLesson13.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(String keyword)
        {
            ViewData["Keyword"] = keyword;
            return View();
        }

        public IActionResult Hots()
        {
            return View();
        }
    }
}