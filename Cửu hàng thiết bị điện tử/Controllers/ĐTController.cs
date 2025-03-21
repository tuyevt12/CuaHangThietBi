using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cửu_hàng_thiết_bị_điện_tử.Data;
using Cửu_hàng_thiết_bị_điện_tử.Models;

namespace Cửu_hàng_thiết_bị_điện_tử.Controllers
{
    public class ĐTController : Controller
    {
        private readonly Cửu_hàng_thiết_bị_điện_tửContext _context;

        public ĐTController(Cửu_hàng_thiết_bị_điện_tửContext context)
        {
            _context = context;
        }

        // GET: ĐT
        public async Task<IActionResult> Index(string selectedCategory, string searchString)
        {
            // Lấy danh sách danh mục (Categories) từ database
            IQueryable<string> categoryQuery = from d in _context.ĐT
                                               orderby d.Category
                                               select d.Category;

            var devices = from d in _context.ĐT
                          select d;

            // Tìm kiếm theo tên sản phẩm
            if (!string.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(s => s.ProductName!.Contains(searchString));
            }

            // Lọc theo danh mục sản phẩm
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                devices = devices.Where(x => x.Category == selectedCategory);
            }

            var deviceCategoryVM = new DeviceCategoryViewModel
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Devices = await devices.ToListAsync()
            };

            return View(deviceCategoryVM);
        }

        // GET: ĐT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var đT = await _context.ĐT
                .FirstOrDefaultAsync(m => m.Id == id);
            if (đT == null)
            {
                return NotFound();
            }

            return View(đT);
        }

        // GET: ĐT/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ĐT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,ManufactureDate,Category,Brand,Price,Stock,Description,ImageUrl")] ĐT đT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(đT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(đT);
        }

        // GET: ĐT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var đT = await _context.ĐT.FindAsync(id);
            if (đT == null)
            {
                return NotFound();
            }
            return View(đT);
        }

        // POST: ĐT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,ManufactureDate,Category,Brand,Price,Stock,Description,ImageUrl")] ĐT đT)
        {
            if (id != đT.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(đT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ĐTExists(đT.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(đT);
        }

        // GET: ĐT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var đT = await _context.ĐT
                .FirstOrDefaultAsync(m => m.Id == id);
            if (đT == null)
            {
                return NotFound();
            }

            return View(đT);
        }

        // POST: ĐT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var đT = await _context.ĐT.FindAsync(id);
            if (đT != null)
            {
                _context.ĐT.Remove(đT);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ĐTExists(int id)
        {
            return _context.ĐT.Any(e => e.Id == id);
        }
    }
}
