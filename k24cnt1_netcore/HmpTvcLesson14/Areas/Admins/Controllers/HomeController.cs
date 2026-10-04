using Microsoft.AspNetCore.Mvc;

namespace HmpTvcLesson14.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}