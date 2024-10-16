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
        public async Task<IActionResult> Index(string filter, string category, int? num)
        {
            int displayCount = num ?? 5; // Default number of comments to display
            var query = _context.Comments.Include(c => c.Responses).AsQueryable();

            // Check if the category is provided
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(c => c.Category == category);
            }

            // Apply filtering logic based on the selected filter
            switch (filter)
            {
                case "unanswered":
                    query = query.Where(c => !c.IsAnswered);
                    break;
                case "latest":
                    query = query.OrderByDescending(c => c.DatePosted);
                    break;
                case "oldest":
                    query = query.OrderBy(c => c.DatePosted);
                    break;
                case "all": // Make sure to handle the case for "all" to show all comments
                    break;
                default:
                    // No filtering needed, show all comments
                    break;
            }

            // Fetch comments based on the applied filters and categories
            var comments = await query.ToListAsync();

            var feedbackViewModel = new FeedbackViewModel
            {
                PositiveComments = comments.Where(c => c.Category == "Positiva").ToList(),
                CriticalComments = comments.Where(c => c.Category == "Kritik").ToList(),
                Questions = comments.Where(c => c.Category == "Frågor").ToList(),
                CurrentFilter = filter,
                CurrentCategory = category,
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
