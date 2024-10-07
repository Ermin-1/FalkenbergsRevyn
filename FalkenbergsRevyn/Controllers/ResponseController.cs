using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FalkenbergsRevyn.Controllers
{
    public class ResponseController : Controller
    {
        private readonly AppDbContext _context;
        public ResponseController(AppDbContext context)
        {
            _context = context;
        }

        //GET: Response
        public async Task<IActionResult> Index()
        {
            var responses = await _context.Responses.Include(r => r.CommentId).ToListAsync();
            return View(responses);
        }

        //GET: Response/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses.Include(r => r.CommentId).FirstOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        //GET: Response/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Response/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponseId,ResponseContent,DateResponded,CommentId")] Response response)
        {
            if (ModelState.IsValid)
            {
                _context.Add(response);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(response);
        }

        //GET: Response/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);

        }

        // POST: Responses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponseId,ResponseContent,DateResponded,CommentId")] Response response)
        {
            if (id != response.ResponseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(response);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Responses.Any(r=>r.ResponseId == response.ResponseId))
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
            return View(response);
        }

        //GET: Response/Delete/5
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses.Include(r=> r.CommentId).FirstOrDefaultAsync(m=> m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        //POST: Response/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _context.Responses.FindAsync(id);
            _context.Responses.Remove(response);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
