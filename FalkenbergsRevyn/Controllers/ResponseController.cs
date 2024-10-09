using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FalkenbergsRevyn.Controllers
{
    public class ResponseController : BaseController<Response>
    {
        private readonly ILogger<ResponseController> _logger;

        public ResponseController(AppDbContext context, ILogger<ResponseController> logger) : base(context)
        {
            _logger = logger;
        }

        // Anpassad Index-metod med filtrering
        [HttpGet("Response/FilteredIndex")]
        public async Task<IActionResult> FilteredIndex(string filter)
        {
            var responsesQuery = _context.Responses.Include(r => r.Comment).AsQueryable();

            if (filter == "unanswered")
            {
                responsesQuery = responsesQuery.Where(r => !r.Comment.IsAnswered);
            }

            if (filter == "latest")
            {
                responsesQuery = responsesQuery.OrderByDescending(r => r.Comment.DatePosted);
            }

            var responses = await responsesQuery.ToListAsync();
            return View("Index", responses); // Specificera att den ska använda "Index"-vyn
        }

        public override async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Responses
                                         .Include(r => r.Comment)
                                         .FirstOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }
    }
}
