using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FalkenbergsRevyn.Controllers
{
    public abstract class BaseController<T> : Controller where T : class
    {
        protected readonly AppDbContext _context;

        protected BaseController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,User")]
        protected async Task<IActionResult> GetItemOrNotFound(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Check if T is Response and include Comment if so
            var item = typeof(T) == typeof(Response)
                ? await _context.Set<T>().Include("Comment").FirstOrDefaultAsync(e => EF.Property<int>(e, "ResponseId") == id)
                : await _context.Set<T>().FindAsync(id);

            return item == null ? NotFound() : View(item);
        }

        [Authorize(Roles = "Admin,User")]
        public virtual async Task<IActionResult> Index()
        {
            var items = await _context.Set<T>().ToListAsync();
            return View(items);
        }

        [Authorize(Roles = "Admin,User")]
        public virtual async Task<IActionResult> Details(int? id)
        {
            return await GetItemOrNotFound(id);
        }

        [Authorize(Roles = "Admin,User")]
        public virtual IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(T item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [Authorize(Roles = "Admin,User")]
        public virtual async Task<IActionResult> Delete(int? id)
        {
            return await GetItemOrNotFound(id);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
