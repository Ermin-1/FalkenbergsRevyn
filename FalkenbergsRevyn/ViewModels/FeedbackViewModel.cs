using FalkenbergsRevyn.Models;

namespace FalkenbergsRevyn.ViewModels
{
    public class FeedbackViewModel
    {
        public List<Comment> PositiveComments { get; set; } = new List<Comment>();
        public List<Comment> CriticalComments { get; set; } = new List<Comment>();
        public List<Comment> Questions { get; set; } = new List<Comment>();
    }
}

