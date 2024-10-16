using FalkenbergsRevyn.Models;

namespace FalkenbergsRevyn.ViewModels
{
    public class FeedbackViewModel
    {
        public List<Comment> PositiveComments { get; set; }
        public List<Comment> CriticalComments { get; set; }
        public List<Comment> Questions { get; set; }
        public string? CurrentFilterPositiva { get; set; }
        public string? CurrentFilterKritik { get; set; }
        public string? CurrentFilterFrågor { get; set; }
        public string? CurrentCategory { get; set; }
        public int? CommentNumber { get; set; }
    }

}

