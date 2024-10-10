using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FalkenbergsRevyn.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime DateCreated { get; set; }
        public ICollection<Comment> ? Comments { get; set; } = new List<Comment>(); // Relationen: ett inlägg har flera kommentarer
    }
}
