using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SaborExpress.Context;
using SaborExpress.Models;

namespace SaborExpress.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminSnacksController : Controller
    {
        private readonly AppDbContext _context;

        public AdminSnacksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminSnacks
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.Snacks.Include(s => s.Category);
        //    return View(await appDbContext.ToListAsync());
        //}
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Name")
        {
            var result = _context.Snacks.Include(l => l.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                result = result.Where(p => p.Name.Contains(filter));
            }

            var model = await PagingList.CreateAsync(result, 3, pageindex, sort, "Name");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }
        // GET: Admin/AdminSnacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Snacks == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SnackId == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // GET: Admin/AdminSnacks/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Admin/AdminSnacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SnackId,Name,ShortDescription,LongDescription,Price,ImageUrl,ThumbnailImageUrl,IsFavoriteSnack,InStock,CategoryId")] Snack snack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", snack.CategoryId);
            return View(snack);
        }

        // GET: Admin/AdminSnacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Snacks == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks.FindAsync(id);
            if (snack == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", snack.CategoryId);
            return View(snack);
        }

        // POST: Admin/AdminSnacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SnackId,Name,ShortDescription,LongDescription,Price,ImageUrl,ThumbnailImageUrl,IsFavoriteSnack,InStock,CategoryId")] Snack snack)
        {
            if (id != snack.SnackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnackExists(snack.SnackId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", snack.CategoryId);
            return View(snack);
        }

        // GET: Admin/AdminSnacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Snacks == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SnackId == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // POST: Admin/AdminSnacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Snacks == null)
            {
                return Problem("Entity set 'AppDbContext.Snacks'  is null.");
            }
            var snack = await _context.Snacks.FindAsync(id);
            if (snack != null)
            {
                _context.Snacks.Remove(snack);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnackExists(int id)
        {
            return _context.Snacks.Any(e => e.SnackId == id);
        }
    }
}
