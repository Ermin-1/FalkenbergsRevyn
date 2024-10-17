//Lets us create new comments and view them to check if they correctly gets a category of Kritik, Positv, fråga or Övrigt
using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using FalkenbergsRevyn.OpenAI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FalkenbergsRevyn.Controllers
{
    public class UserCommentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly OpenAIChatBot _openAIChatBot;

        public UserCommentController(AppDbContext context, OpenAIChatBot openAIChatBot)
        {
            _context = context;
            _openAIChatBot = openAIChatBot;
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Create(int postId)
        {
            var viewModel = new CommentViewModel { PostId = postId };
            return View("AddComment", viewModel);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newComment = new Comment
                {
                    Content = model.Content,
                    PostId = model.PostId,
                    DatePosted = DateTime.Now,
                    IsAnswered = false,
                    Category = CommentCategorizer.CategorizeComment(model.Content)
                };

                _context.Comments.Add(newComment);
                await _context.SaveChangesAsync();
                _openAIChatBot.ProcessComments(newComment);
                await _context.SaveChangesAsync();

                if (newComment.Category == "Positiva")
                {
                    await _openAIChatBot.ProcessComments(newComment);
                }

                return RedirectToAction("Details", "Post", new { id = model.PostId });
            }

            return View("AddComment", model);
        }
    }
}
