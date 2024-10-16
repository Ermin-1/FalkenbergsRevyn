using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using FalkenbergsRevyn.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

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
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Index(string filter, int? num)
        {
            int displayCount = num ?? 5;

            var query = _context.Comments.Include(c => c.Responses).AsQueryable();

            // Apply the filter to the comments
            query = filter switch
            {
                "unanswered" => query.Where(r => !r.IsAnswered),
                "latest" => query.OrderByDescending(r => r.DatePosted),
                "oldest" => query.OrderBy(r => r.DatePosted),
                _ => query.OrderByDescending(r => r.DatePosted)
            };

            // Fetch all comments and categorize them
            var comments = await query.ToListAsync();
            var feedbackViewModel = new FeedbackViewModel
            {
                PositiveComments = comments.Where(c => c.Category == "Positiva").Take(displayCount).ToList(),
                CriticalComments = comments.Where(c => c.Category == "Kritik").Take(displayCount).ToList(),
                Questions = comments.Where(c => c.Category == "Frågor").Take(displayCount).ToList(),
                CurrentFilter = filter,
                CommentNumber = displayCount
            };

            return View(feedbackViewModel);
        }

        [Authorize(Roles = "Admin,User")]

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

        [Authorize(Roles = "Admin,User")]
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

        [Authorize(Roles = "Admin,User")]
        private IQueryable<Comment> ApplyFilter(IQueryable<Comment> comments, string filter)
        {
            return filter switch
            {
                "unanswered" => comments.Where(c => !c.IsAnswered),
                "latest" => comments.OrderByDescending(c => c.DatePosted),
                "oldest" => comments.OrderBy(c => c.DatePosted),
                _ => comments.OrderByDescending(c => c.DatePosted)
            };
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin,User")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
