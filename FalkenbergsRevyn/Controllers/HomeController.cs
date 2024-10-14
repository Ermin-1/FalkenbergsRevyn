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
            _logger.LogInformation($"Filter: {filter}, Category: {category}");
            var feedbackViewModel = new FeedbackViewModel
            {
                PositiveComments = await GetFilteredComments("Positiva", filter, category),
                CriticalComments = await GetFilteredComments("Kritik", filter, category),
                Questions = await GetFilteredComments("Frågor", filter, category)
            };
            return View(feedbackViewModel);



            //var comments = await _context.Comments.Where(c => !c.IsArchived).ToListAsync();

            //var positiveComments = comments.Where(c => c.Category == "Positiva").ToList();
            //var criticalComments = comments.Where(c => c.Category == "Kritik").ToList();
            //var questions = comments.Where(c => c.Category == "Frågor").ToList();
            //if (!string.IsNullOrEmpty(filter))
            //{
            //    switch (filter)
            //    {
            //        case "unanswered":
            //            if (category == "positive")
            //            {
            //                positiveComments = positiveComments.Where(c => !c.IsAnswered).ToList();
            //            }
            //            else if (category == "critical")
            //            {
            //                criticalComments = criticalComments.Where(c => !c.IsAnswered).ToList();
            //            }
            //            else if (category == "questions")
            //            {
            //                questions = questions.Where(c => !c.IsAnswered).ToList();
            //            }
            //            break;

            //        case "latest":

            //            if (category == "positive")
            //            {
            //                positiveComments = positiveComments.OrderByDescending(c => c.DatePosted).ToList();
            //            }
            //            else if (category == "critical")
            //            {
            //                criticalComments = criticalComments.OrderByDescending(c => c.DatePosted).ToList();
            //            }
            //            else if (category == "questions")
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

        }

        public async Task<IActionResult> Index2(string filter, string category)
        {

            var feedbackViewModel = new FeedbackViewModel
            {
                PositiveComments = await GetFilteredComments("Positiva", filter, category),
                CriticalComments = await GetFilteredComments("Kritik", filter, category),
                Questions = await GetFilteredComments("Frågor", filter, category)
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
                _ => query 
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