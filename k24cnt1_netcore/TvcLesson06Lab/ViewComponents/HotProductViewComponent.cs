using Microsoft.AspNetCore.Mvc;
using TvcLesson06Lab.Models;
using TvcLesson06Lab.Models;

namespace TvcLesson06Lab.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var hotProducts = new List<Product>
            {
                new Product { ProductId = 4, ProductName = "Bundle Limited Champion 2024", ImageUrl = "/images/champion 2024.jpg", Price = 32990000 },
                new Product { ProductId = 5, ProductName = "Bundle Limited Champion 2025", ImageUrl = "/images/champion 2025.jpg", Price = 35990000 },
                new Product { ProductId = 6, ProductName = "Bundle Limited Champion 2026", ImageUrl = "/images/champion 2026.jpg", Price = 41990000 }
            };
            return View(hotProducts);
        }
    }
}