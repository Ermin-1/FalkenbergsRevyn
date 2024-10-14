//Lets us create new comments and view them to check if they correctly gets a category of Kritik, Positv, fråga or Övrigt
using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FalkenbergsRevyn.Controllers
{
    public class UserCommentController : Controller
    {
        private readonly AppDbContext _context;

        public UserCommentController(AppDbContext context)
        {
            _context = context;
        }


        // GET: UserComment/Create
        [Authorize(Roles = "Admin,User")]
        public IActionResult Create(int postId)
        {
            var viewModel = new CommentViewModel { PostId = postId };
            return View("AddComment", viewModel); // Explicitly load the AddComment view
        }

        // POST: UserComment/Create
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
                    Category = CommentCategorizer.CategorizeComment(model.Content) // Automatically categorize comment
                };

                _context.Comments.Add(newComment);
                await _context.SaveChangesAsync();

                // Redirect back to the post details page or index page
                return RedirectToAction("Details", "Post", new { id = model.PostId });
            }

            return View("AddComment", model); // Reload form if validation fails
        }
    }
}
