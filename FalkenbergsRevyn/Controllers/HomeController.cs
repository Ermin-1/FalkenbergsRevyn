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
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index(string filter, string category)
        {

            var query = _context.Comments.Include(c => c.Responses).Where(c => !c.IsArchived);

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(c => c.Category == category);
            }

            if (!string.IsNullOrEmpty(filter))
            {

                query = filter switch
                {
                    "unanswered" => query.Where(c => !c.IsAnswered),
                    "latest" => query.OrderByDescending(c => c.DatePosted),
                    "oldest" => query.OrderBy(c => c.DatePosted),
                    "all" => query, 
                    _ => query
                };
            }

            if (string.IsNullOrEmpty(filter))
            {
                query = query.OrderByDescending(c => c.DatePosted);
            }

            var comments = await query.ToListAsync();

            var feedbackViewModel = new FeedbackViewModel
            {
                PositiveComments = comments.Where(c => c.Category == "Positiva").ToList(),
                CriticalComments = comments.Where(c => c.Category == "Kritik").ToList(),
                Questions = comments.Where(c => c.Category == "Frågor").ToList(),
                
            };
            return View(feedbackViewModel);
        }


        private IEnumerable<Comment> FilterComments(IEnumerable<Comment> comments, string filter)
        {
            switch (filter)
            {
                case "latest":
                    return comments.OrderByDescending(c => c.DatePosted).ToList();
                case "unanswered":
                    return comments.ToList().Where(c => !c.Responses.Any()).ToList();
                default:
                    return comments.ToList();
            }
        }
        private async Task<List<Comment>> GetFilteredComments(string categoryName, string filter, string requestedCategory)
        {
            var query = _context.Comments.Include(c => c.Responses)
                .Where(c => !c.IsArchived && c.Category == categoryName);

            if (categoryName.ToLower() == requestedCategory?.ToLower())
            {
                query = ApplyFilter(query, filter);
            }

            return await query.ToListAsync();
        }


        private IQueryable<Comment> ApplyFilter(IQueryable<Comment> query, string filter)
        {
            return filter switch
            {
                "unanswered" => query.Where(c => !c.IsAnswered),
                "latest" => query.OrderByDescending(c => c.DatePosted),
                _ => query.OrderByDescending(c => c.DatePosted)
            };
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
