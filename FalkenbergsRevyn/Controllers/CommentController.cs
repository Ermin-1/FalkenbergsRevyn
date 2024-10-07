using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FalkenbergsRevyn.Controllers
{
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;
        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var comments = await _context.Comments.ToListAsync();
            return View(comments);
        }


        public async Task<IActionResult> Detilas(int? id)

        {
            if (id == null)
            {
                return NotFound();

            }
            var comment = await _context.Comments.FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // In case we need to add more comments

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Content, Category")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.DatePosted = DateTime.Now;
                comment.IsAnswered = false;
                comment.IsArchived = false;
                comment.PostId = 1; // Need to think how to connect this to a post

            }
        }
                public async Task<IActionResult> Create([Bind("CommentId,CommentContent, Category")] Comment comment)
                {
                    if (ModelState.IsValid)
                    {

                        _context.Add(comment);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    return View(comment);
                }

                [HttpDelete]
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    var comment = await _context.Comments.FirstOrDefaultAsync(m => m.CommentId == id);
                    if (comment == null)
                    {
                        return NotFound();
                    }
                    return View(comment);
                }
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var comment = await _context.Comments.FindAsync(id);

                    if (comment != null)
                    {
                        _context.Comments.Remove(comment);
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToAction(nameof(Index));
                }
    }
}
