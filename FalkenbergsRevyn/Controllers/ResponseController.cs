using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;
using System.Linq;

namespace FalkenbergsRevyn.Controllers
{
    public class ResponseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ResponseController> _logger;

        public ResponseController(AppDbContext context, ILogger<ResponseController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //GET: Response
        public async Task<IActionResult> Index(string filter)
        {
            var responsesQuery = _context.Responses.Include(r => r.Comment).AsQueryable();

            // Filtrering på obesvarade kommentarer

            if (filter == "unanswered")
            {
                responsesQuery = responsesQuery.Where(r => !r.Comment.IsAnswered);
            }


            // Sortering på senaste kommentarer (baserat på datum för responsen)
            if (filter == "latest")
            {
                responsesQuery = responsesQuery.OrderByDescending(r => r.Comment.DatePosted);
            }


            // Returnera en lista (IEnumerable) med Responses
            var responses = await responsesQuery.ToListAsync();
            return View(responses);
        }

        //GET: Response/Details/5
        public async Task<IActionResult> Details(int? id)

        {
            if (id == null)
            {
                return NotFound();
            }

            // Inkluderar relaterad Comment-entitet
            var response = await _context.Responses
                                         .Include(r => r.Comment) // Inkludera den relaterade Comment-entiteten
                                         .FirstOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }


        //GET: Response/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Response/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponseId,ResponseContent,DateResponded,CommentId")] Response response)
        {
            if (ModelState.IsValid)
            {
                response.DateResponded = DateTime.Now;
                _context.Add(response);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Response/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            // Returnerar vyn för att redigera en enskild Response
            return View(response); // Detta laddar Edit.cshtml som förväntar sig en enskild Response-modell
        }


        // POST: Responses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponseId,ResponseContent,DateResponded,CommentId")] Response response)
        {
            if (id != response.ResponseId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                // Logga detaljer om vad som saknas eller är ogiltigt i ModelState
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        _logger.LogError($"ModelState error for key '{key}': {error.ErrorMessage}");
                    }
                }

                // Återvänd till vyn så användaren kan se felet
                return View(response);
            }

            try
            {
                _context.Update(response);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Responses.Any(r => r.ResponseId == response.ResponseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }



        //GET: Response/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Inkluderar relaterad Comment-entitet
            var response = await _context.Responses
                                         .Include(r => r.Comment) // Inkludera den relaterade Comment-entiteten
                                         .FirstOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        //POST: Response/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _context.Responses.FindAsync(id);
            _context.Responses.Remove(response);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
