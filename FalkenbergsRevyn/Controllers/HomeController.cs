using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using FalkenbergsRevyn.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FalkenbergsRevyn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        //private readonly CommentController _commentController;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            //_commentController = commentController;
        }

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

           
            var responses = await responsesQuery.ToListAsync();

      
            var res = await _context.Responses.Include(c => c.Comment) 
                                          .ToListAsync();


            var feedbackViewModel = new FeedbackViewModel
            {
                PositiveComments = await _context.Comments.Where(c => c.Category == "Positiva").ToListAsync(),
                CriticalComments = await _context.Comments.Where(c => c.Category == "Kritik").ToListAsync(),
                Questions = await _context.Comments.Where(c => c.Category == "Question").ToListAsync()
            };
            return View(feedbackViewModel);

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
