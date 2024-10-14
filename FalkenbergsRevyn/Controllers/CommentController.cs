using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using FalkenbergsRevyn.OpenAI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FalkenbergsRevyn.Controllers
{

    /*[ApiController]
    [Route("api/[controller]")]*/
    public class CommentController : BaseController<Comment>
    {
        private readonly AppDbContext _context;
        private readonly OpenAIChatBot _openAIChatBot;

        public CommentController(AppDbContext context, OpenAIChatBot openAIChatBot) : base(context)
        {
            _context = context;
            _openAIChatBot = openAIChatBot;
            _openAIChatBot = openAIChatBot;
        }

        [Authorize(Roles = "Admin,User")]
        [Route("Comment/Index")]
        public async Task<IActionResult> Index()
        {
            var comments = await _context.Comments.ToListAsync();
            return View(comments);
        }

        [Authorize(Roles = "Admin,User")]
        [Route("Comment/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
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


        [Authorize(Roles = "Admin,User")]
        [Route("Comment/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Comment/Create")]
        public async Task<IActionResult> Create([Bind("Content,Category")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.DatePosted = DateTime.Now;
                comment.IsAnswered = false;
                comment.IsArchived = false;
                
                comment.PostId = 1; // Här kan du implementera hur det kopplas till ett specifikt inlägg

                _context.Add(comment);
                await _context.SaveChangesAsync();
                await _openAIChatBot.ProcessComments(comment);
                return RedirectToAction(nameof(Index));
            }

            return View(comment);
        }

        [Authorize(Roles = "Admin,User")]
        [Route("Comment/Delete/{id}")]

        //[Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Delete(int? id)
        {
            return await base.Delete(id);
        }


        [Authorize(Roles = "Admin,User")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Comment/Delete/{id}")]
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

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public async Task<IActionResult> ArchiveComment(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                comment.IsArchived = true;
                comment.IsAnswered = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

