using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FalkenbergsRevyn.Controllers
{
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var comments = await _context.Comments.ToListAsync();
            return View(comments);
        }

        // Detaljerad vy för en specifik kommentar
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)  // Fixade stavfel från "Detilas" till "Details"
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

        // Skapa en ny kommentar
        //[Authorize (Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,Category")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.DatePosted = DateTime.Now;
                comment.IsAnswered = false;
                comment.IsArchived = false;
                comment.PostId = 1; // Här kan du implementera hur det kopplas till ett inlägg

                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(comment);
        }

        // Ta bort en kommentar (GET)
        //[Authorize(Roles = "Admin")]
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

        // Bekräfta och ta bort en kommentar (POST)
        //[Authorize(Roles = "Admin")]
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
