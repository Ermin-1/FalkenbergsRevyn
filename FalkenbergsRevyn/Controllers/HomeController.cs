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

            var comments = await _context.Comments.Where(c => !c.IsArchived).ToListAsync();
    //.GroupJoin(
    //    _context.Responses,
    //    comment => comment.CommentId,
    //    response => response.CommentId, 
    //    (comment, responses) => new { Comment = comment, Responses = responses } 
    //)
    //.SelectMany(
    //    x => x.Responses.DefaultIfEmpty(), 
    //    (x, response) => new { x.Comment, Response = response }
    //)
    //.ToListAsync();

            //await _context.Comments.Where(c=>c.IsArchived == false).ToListAsync();
            var positiveComments = comments.Where(c => c.Category == "Positiva").ToList();
            var criticalComments = comments.Where(c => c.Category == "Kritik").ToList();
            var questions = comments.Where(c => c.Category == "Frågor").ToList();
            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter)
                {
                    case "unanswered":
                        if (category == "positive")
                        {
                            positiveComments = positiveComments.Where(c => !c.IsAnswered).ToList();
                        }
                        else if (category == "critical")
                        {
                            criticalComments = criticalComments.Where(c => !c.IsAnswered).ToList();
                        }
                        else if (category == "questions")
                        {
                            questions = questions.Where(c => !c.IsAnswered).ToList();
                        }
                        break;

                    case "latest":

                        if (category == "positive")
                        {
                            positiveComments = positiveComments.OrderByDescending(c => c.DatePosted).ToList();
                        }
                        else if (category == "critical")
                        {
                            criticalComments = criticalComments.OrderByDescending(c => c.DatePosted).ToList();
                        }
                        else if (category == "questions")
                        {
                            questions = questions.OrderByDescending(c => c.DatePosted).ToList();
                        }
                        break;
                    default:
                        break;
                }
            }
            var feedbackViewModel = new FeedbackViewModel
            {
                PositiveComments = positiveComments,
                CriticalComments = criticalComments,
                Questions = questions,
            };
            return View(feedbackViewModel);

            // Funderar... jag funderar...
            //var commentsQuery = _context.Comments.Include(c => c.Responses).AsQueryable();

            //if (!string.IsNullOrEmpty(category))
            //{
            //    commentsQuery = commentsQuery.Where(c => c.Category == category);
            //}

            //if (!string.IsNullOrEmpty(filter))
            //{
            //    switch (filter)
            //    {
            //        case "unanswered":
            //            commentsQuery = commentsQuery.Where(c => !c.IsAnswered);
            //            break;
            //        case "latest":
            //            commentsQuery = commentsQuery.OrderByDescending(c => c.DatePosted);
            //            break;
            //    }
            //}

            //var comments = await commentsQuery.ToListAsync();

            //var feedbackViewModel = new FeedbackViewModel
            //{
            //    PositiveComments = comments.Where(c => c.Category == "Positiva").ToList(),
            //    CriticalComments = comments.Where(c => c.Category == "Kritik").ToList(),
            //    Questions = comments.Where(c => c.Category == "Frågor").ToList(),
            //};

            //return View(feedbackViewModel);
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