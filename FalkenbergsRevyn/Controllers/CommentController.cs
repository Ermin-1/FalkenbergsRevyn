using Microsoft.AspNetCore.Mvc;

namespace FalkenbergsRevyn.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
