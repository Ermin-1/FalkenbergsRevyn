using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace FalkenbergsRevyn.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Posts.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        //Get: Post/AddorEdit
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



        //Post : Post/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("PostId, Title, Content, DateCreated, Comments")]Post post)
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

        //Get : Post/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);

            if(post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        //Post : Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfiremed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if(post != null)
            {
                _context.Posts.Remove(post);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
