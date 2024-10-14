using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using FalkenbergsRevyn.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Index(string filter, string category)
        {
            //_logger.LogInformation($"Filter: {filter}, Category: {category}");
            //var feedbackViewModel = new FeedbackViewModel
            //{
            //    PositiveComments = await GetFilteredComments("Positiva", filter, category),
            //    CriticalComments = await GetFilteredComments("Kritik", filter, category),
            //    Questions = await GetFilteredComments("Frågor", filter, category)
            //};
            //return View(feedbackViewModel);
            //var feedbackViewModel = new FeedbackViewModel
            //{
            //    PositiveComments = await GetFilteredComments("Positiva", filter, category),
            //    CriticalComments = await GetFilteredComments("Kritik", filter, category),
            //    Questions = await GetFilteredComments("Frågor", filter, category)
            //};
            //return View(feedbackViewModel);


            //var comments = await _context.Comments.Where(c => !c.IsArchived).ToListAsync();

            //var positiveComments = comments.Where(c => c.Category == "Positiva").ToList();
            //var criticalComments = comments.Where(c => c.Category == "Kritik").ToList();
            //var questions = comments.Where(c => c.Category == "Frågor").ToList();
            //if (!string.IsNullOrEmpty(filter))
            //{
            //    switch (filter)
            //    {
            //        case "unanswered":
            //            if (category == "Positiva")
            //            {
            //                positiveComments = positiveComments.Where(c => !c.IsAnswered).ToList();
            //            }
            //            else if (category == "Kritik")
            //            {
            //                criticalComments = criticalComments.Where(c => !c.IsAnswered).ToList();
            //            }
            //            else if (category == "Frågor")
            //            {
            //                questions = questions.Where(c => !c.IsAnswered).ToList();
            //            }
            //            break;

            //        case "latest":

            //            if (category == "Positiva")
            //            {
            //                positiveComments = positiveComments.OrderByDescending(c => c.DatePosted).ToList();
            //            }
            //            else if (category == "Kritik")
            //            {
            //                criticalComments = criticalComments.OrderByDescending(c => c.DatePosted).ToList();
            //            }
            //            else if (category == "Frågor")
            //            {
            //                questions = questions.OrderByDescending(c => c.DatePosted).ToList();
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //var feedbackViewModel = new FeedbackViewModel
            //{
            //    PositiveComments = positiveComments,
            //    CriticalComments = criticalComments,
            //    Questions = questions,
            //};
            //return View(feedbackViewModel);
            var query = _context.Comments.Where(c => !c.IsArchived);

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
                    _ => query
                };
            }
            else
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
        private IQueryable<Comment> ApplyFilter(IQueryable<Comment> query, string filter)
        {
            return filter switch
            {
                "unanswered" => query.Where(c => !c.IsAnswered),
                "latest" => query.OrderByDescending(c => c.DatePosted),
                _ => query.OrderByDescending(c => c.DatePosted)
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
