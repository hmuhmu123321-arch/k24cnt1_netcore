using Microsoft.AspNetCore.Mvc;

namespace TvcLesson02Demo.Controllers
{
    public class TvcProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
