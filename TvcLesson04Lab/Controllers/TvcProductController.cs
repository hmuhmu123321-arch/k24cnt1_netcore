using Microsoft.AspNetCore.Mvc;
using TvcLesson04Lab.Models;

namespace TvcLesson04Lab.Controllers
{
    public class TvcProductController : Controller
    {
        private readonly List<TvcCategory> tvcCategories = new()
        {
            new TvcCategory { Id = 1, Name = "Skin Limited", Icon = "fa-crown", Description = "Các bộ skin giới hạn sự kiện" },
            new TvcCategory { Id = 2, Name = "Skin Huyền Thoại", Icon = "fa-dragon", Description = "Skin có hiệu ứng biến hình đặc biệt" },
            new TvcCategory { Id = 3, Name = "Skin Tuyệt Phẩm", Icon = "fa-gem", Description = "Chất lượng cao nhất với hiệu ứng nạp đạn riêng" },
            new TvcCategory { Id = 4, Name = "Skin Hiện Đại", Icon = "fa-bolt", Description = "Phong cách công nghệ tương lai" },
            new TvcCategory { Id = 5, Name = "Skin Đen Tối & U Ám", Icon = "fa-ghost", Description = "Tông màu u tối và ma mị" }
        };

        private readonly List<TvcProduct> tvcProducts = new()
        {
            new TvcProduct
            {
                Id = 1,
                Name = "Bộ trang phục Champion 2021 Bundle",
                Description = "Bộ sưu tập Champions 2021 trong VALORANT sở hữu phong cách thiết kế mang tính biểu tượng vô cùng sang trọng.",
                Price = 250000,
                SalePrice = 220000,
                Category = "Skin Limited",
                ImageUrl = "/images/champion 2021.jpg",
                ReleaseYear = 2024,
                Platform = "PC",
                Rating = 8.8,
                Publisher = "Riot Games",
                Developer = "Riot Games",
                IsHot = true,
                IsNew = true
            },
            new TvcProduct
            {
                Id = 2,
                Name = "Bộ Trang Phục Kuronami Bundle",
                Description = "Bộ trang phục mang phong cách Nhẫn giả hiện đại với hiệu ứng kết liễu thời tiết độc đáo.",
                Price = 2200000,
                SalePrice = 1890000,
                Category = "Skin Huyền Thoại",
                ImageUrl = "/images/kuronami.jpg",
                ReleaseYear = 2024,
                Platform = "PC",
                Rating = 9.8,
                Publisher = "Riot Games",
                Developer = "Riot Games",
                IsHot = true,
                IsNew = false
            },
            new TvcProduct
            {
                Id = 3,
                Name = "Bộ Trang Phục Elderflame (Rồng Thiêng)",
                Description = "Triệu hồi sức mạnh của những con rồng cổ đại. Skin Ultra Edition đầu tiên.",
                Price = 2490000,
                SalePrice = 1990000,
                Category = "Skin Tuyệt Phẩm",
                ImageUrl = "/images/elderflame.jpg",
                ReleaseYear = 2020,
                Platform = "PC",
                Rating = 9.4,
                Publisher = "Riot Games",
                Developer = "Riot Games",
                IsHot = false,
                IsNew = false
            },
            new TvcProduct
            {
                Id = 4,
                Name = "Bộ Trang Phục Prime (Tối Thượng)",
                Description = "Thiết kế sang trọng với tông màu vàng-trắng-tím đẳng cấp.",
                Price = 1790000,
                SalePrice = 1490000,
                Category = "Skin Hiện Đại",
                ImageUrl = "/images/prime.jpg",
                ReleaseYear = 2020,
                Platform = "PC",
                Rating = 9.6,
                Publisher = "Riot Games",
                Developer = "Riot Games",
                IsHot = true,
                IsNew = false
            },
            new TvcProduct
            {
                Id = 5,
                Name = "Bộ Trang Phục Reaver (Kẻ Cướp Linh Hồn)",
                Description = "Tông màu u tối huyền bí, tiếng nạp đạn ma mị.",
                Price = 1790000,
                SalePrice = 1390000,
                Category = "Skin Đen Tối & U Ám",
                ImageUrl = "/images/reaver.jpg",
                ReleaseYear = 2020,
                Platform = "PC",
                Rating = 9.7,
                Publisher = "Riot Games",
                Developer = "Riot Games",
                IsHot = true,
                IsNew = false
            },
            new TvcProduct
            {
                Id = 6,
                Name = "Bộ Trang Phục Champions 2024",
                Description = "Phiên bản giới hạn dành riêng cho giải đấu vô địch thế giới Valorant Champions.",
                Price = 1590000,
                SalePrice = 1590000,
                Category = "Skin Limited",
                ImageUrl = "/images/champion 2024.jpg",
                ReleaseYear = 2024,
                Platform = "PC, PS5, Xbox Series X/S",
                Rating = 9.9,
                Publisher = "Riot Games",
                Developer = "Riot Games",
                IsHot = true,
                IsNew = true
            }
        };

        public IActionResult Index(int? categoryId = null)
        {
            // Tự động tính số lượng sản phẩm theo danh mục
            foreach (var cat in tvcCategories)
            {
                cat.ProductCount = tvcProducts.Count(p => p.Category == cat.Name);
            }

            ViewBag.TvcCategories = tvcCategories;

            List<TvcProduct> filteredProducts = tvcProducts;

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                var selectedCategory = tvcCategories.FirstOrDefault(c => c.Id == categoryId.Value);
                if (selectedCategory != null)
                {
                    filteredProducts = tvcProducts.Where(p => p.Category == selectedCategory.Name).ToList();
                    ViewBag.SelectedCategory = categoryId.Value;
                }
            }
            else
            {
                ViewBag.SelectedCategory = null;
            }

            ViewBag.TvcProducts = filteredProducts;
            return View();
        }

        [Route("chi-tiet-san-pham/{id?}", Name = "tvcproductdetail")]
        public IActionResult TvcSanPham(int? id)
        {
            TvcProduct? tvcProduct = id.HasValue
                ? tvcProducts.FirstOrDefault(x => x.Id == id.Value)
                : tvcProducts.FirstOrDefault();

            ViewBag.TvcProduct = tvcProduct;

            if (tvcProduct != null)
            {
                ViewBag.RelatedProducts = tvcProducts
                    .Where(p => p.Category == tvcProduct.Category && p.Id != tvcProduct.Id)
                    .Take(4)
                    .ToList();
            }

            return View();
        }
    }
}