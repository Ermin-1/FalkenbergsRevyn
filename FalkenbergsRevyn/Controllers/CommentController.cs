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
        //private readonly OpenAIChatBot _openAIChatBot;

        public CommentController(AppDbContext context) : base(context)
        {
            _context = context;
            //_openAIChatBot = openAIChatBot;
        }

        [Route("Comment/Index")]
        public async Task<IActionResult> Index()
        {
            var comments = await _context.Comments.ToListAsync();
            return View(comments);
        }

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

        [Route("Comment/Create")]
        public IActionResult Create()
        {
            return View();
        }

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
                //await _openAIChatBot.ProcessComments(comment);
                return RedirectToAction(nameof(Index));
            }

            return View(comment);
        }

        [Route("Comment/Delete/{id}")]

        //[Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Delete(int? id)
        {
            return await base.Delete(id);
        }

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
    }
}

