using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TvcLesson06Lab.Models;
using TvcLesson06Lab.Models;

namespace TvcLesson06Lab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var newProducts = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Bundle Limited Champion 2021", ImageUrl = "/images/champion 2021.jpg", Price = 27490000 },
                new Product { ProductId = 2, ProductName = "Bundle Limited Champion 2022", ImageUrl = "/images/champion 2022.jpg", Price = 21990000 },
                new Product { ProductId = 3, ProductName = "Bundle Limited Champion 2023", ImageUrl = "/images/champion 2023.jpg", Price = 34840000 }
            };

            ViewBag.NewProducts = newProducts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}