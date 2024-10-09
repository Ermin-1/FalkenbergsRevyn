using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FalkenbergsRevyn.Controllers
{
    public class CommentController : BaseController<Comment>
    {
        public CommentController(AppDbContext context) : base(context) { }

        // Överlagrad Create-metod för att ställa in specifika standardvärden för en kommentar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.DatePosted = DateTime.Now;
                comment.IsAnswered = false;
                comment.IsArchived = false;
                comment.PostId = 1; // Här kan du implementera hur det kopplas till ett specifikt inlägg

                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(comment);
        }

        // Skapa och ta bort åtgärder hanteras av BaseController
        // Index- och Details-metoder från BaseController laddar respektive vy för alla kommentarer eller enskild kommentar

        public override async Task<IActionResult> Index()
        {
            var comments = await _context.Comments.ToListAsync();
            return View(comments);
        }
    }
}
