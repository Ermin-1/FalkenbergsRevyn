using FalkenbergsRevyn.Models;

namespace FalkenbergsRevyn.ViewModels
{
    public class FeedbackCategoryViewModel
    {
        public string Title { get; set; }
        public string CurrentFilter { get; set; }
        public string CategoryType { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
