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
            int displayCount = num ?? 5; // Default display count
            var query = _context.Comments.Include(c => c.Responses).AsQueryable();

            // Apply category filtering if provided
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(c => c.Category == category);
            }

            // Apply filter sorting based on the selected filter
            switch (filter)
            {
                case "unanswered":
                    query = query.Where(r => !r.IsAnswered);
                    break;
                case "latest":
                    query = query.OrderByDescending(r => r.DatePosted);
                    break;
                case "oldest":
                    query = query.OrderBy(r => r.DatePosted);
                    break;
                default:
                    query = query.OrderByDescending(r => r.DatePosted);
                    break;
            }

            // Execute the query and retrieve all comments for the specified category
            var filteredComments = await query.ToListAsync();

            // Populate the FeedbackViewModel with categorized comments
            var feedbackViewModel = new FeedbackViewModel
            {
                PositiveComments = filteredComments.Where(c => c.Category == "Positiva").Take(displayCount).ToList(),
                CriticalComments = filteredComments.Where(c => c.Category == "Kritik").Take(displayCount).ToList(),
                Questions = filteredComments.Where(c => c.Category == "Frågor").Take(displayCount).ToList(),
                CurrentFilterPositiva = filter, // Set current filter for Positive comments
                CurrentFilterKritik = filter, // Set current filter for Critical comments
                CurrentFilterFrågor = filter, // Set current filter for Questions
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
