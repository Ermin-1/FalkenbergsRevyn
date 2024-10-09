using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FalkenbergsRevyn.Controllers
{
    public class PostController : BaseController<Post>
    {
        public PostController(AppDbContext context) : base(context) { }

        [HttpGet]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Post());
            }
            else
            {
                return View(_context.Posts.Find(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("PostId, Title, Content, DateCreated, Comments")] Post post)
        {
            if (ModelState.IsValid)
            {
                if (ModelState["Comments"].Errors.Count > 0)
                {
                    ModelState["Comments"].Errors.Clear();
                }

                if (post.PostId == 0)
                {
                    post.DateCreated = DateTime.Now;
                    _context.Add(post);
                }
                else
                {
                    post.DateCreated = DateTime.Now;
                    _context.Update(post);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
    }
}
