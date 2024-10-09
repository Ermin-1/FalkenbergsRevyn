using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FalkenbergsRevyn.Controllers
{
    public class CommentController : BaseController<Comment>
    {
        public CommentController(AppDbContext context) : base(context) { }

        // Anpassad Create-metod för att sätta specifika standardvärden
        //[Authorize(Roles = "Admin")]
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

        // Index- och Details-metoder ärvs från BaseController och kan skyddas med Authorize
        //[Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Index()
        {
            return await base.Index();
        }

        //[Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Details(int? id)
        {
            return await base.Details(id);
        }

        //[Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Delete(int? id)
        {
            return await base.Delete(id);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> DeleteConfirmed(int id)
        {
            return await base.DeleteConfirmed(id);
        }
    }
}
