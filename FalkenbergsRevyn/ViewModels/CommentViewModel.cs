using System.ComponentModel.DataAnnotations;

namespace FalkenbergsRevyn.Models
{
    public class CommentViewModel
    {
        [Required(ErrorMessage = "Kommentar är obligatoriskt.")]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}
