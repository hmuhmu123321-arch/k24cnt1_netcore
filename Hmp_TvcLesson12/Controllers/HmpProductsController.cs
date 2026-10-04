using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hmp_TvcLesson12.Models;

namespace Hmp_TvcLesson12.Controllers
{
    public class HmpProductsController : Controller
    {
        private readonly HmpTvcLesson12Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HmpProductsController(HmpTvcLesson12Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: HmpProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.HmpProducts.ToListAsync());
        }

        // GET: HmpProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var hmpProduct = await _context.HmpProducts
                .FirstOrDefaultAsync(m => m.HmpId == id.Value);
            if (hmpProduct == null) return NotFound();

            return View(hmpProduct);
        }

        // GET: HmpProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HmpProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HmpId,HmpName,HmpImage,HmpPrice,HmpSalePrice,HmpStatus,HmpDescriptions,HmpCreatedDate,HmpCategoryId,HmpImageFile")] HmpProduct hmpProduct)
        {
            if (ModelState.IsValid)
            {
                // === XỬ LÝ UPLOAD ẢNH ===
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = Path.GetFileName(file.FileName); // Lấy đúng tên file, tránh path injection
                    var folderPath = Path.Combine(_hostEnvironment.WebRootPath, "Hmp_Product");

                    // Tạo thư mục nếu chưa tồn tại
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    var fullPath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    hmpProduct.HmpImage = fileName;
                }
                // === KẾT THÚC UPLOAD ===

                _context.Add(hmpProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hmpProduct);
        }

        // GET: HmpProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var hmpProduct = await _context.HmpProducts.FindAsync(id.Value);
            if (hmpProduct == null) return NotFound();

            return View(hmpProduct);
        }

        // POST: HmpProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HmpId,HmpName,HmpImage,HmpPrice,HmpSalePrice,HmpStatus,HmpDescriptions,HmpCreatedDate,HmpCategoryId,HmpImageFile")] HmpProduct hmpProduct)
        {
            if (id != hmpProduct.HmpId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // === XỬ LÝ UPLOAD ẢNH MỚI (NẾU CÓ) ===
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0 && files[0].Length > 0)
                    {
                        var file = files[0];
                        var fileName = Path.GetFileName(file.FileName);
                        var folderPath = Path.Combine(_hostEnvironment.WebRootPath, "Hmp_Product");

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        var fullPath = Path.Combine(folderPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        hmpProduct.HmpImage = fileName;
                    }
                    // === KẾT THÚC ===

                    _context.Update(hmpProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HmpProductExists(hmpProduct.HmpId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hmpProduct);
        }

        // GET: HmpProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var hmpProduct = await _context.HmpProducts
                .FirstOrDefaultAsync(m => m.HmpId == id.Value);
            if (hmpProduct == null) return NotFound();

            return View(hmpProduct);
        }

        // POST: HmpProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hmpProduct = await _context.HmpProducts.FindAsync(id);
            if (hmpProduct != null)
            {
                _context.HmpProducts.Remove(hmpProduct);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        private bool HmpProductExists(int id)
        {
            return _context.HmpProducts.Any(e => e.HmpId == id);
        }
    }
}