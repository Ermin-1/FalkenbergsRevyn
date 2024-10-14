namespace FalkenbergsRevyn.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }  // Kritik, Frågor, Positiva kommentarer
        public bool IsAnswered { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsArchived { get; set; }

        public int PostId { get; set; }       // Relationen: kommentar hör till ett inlägg public Post Post { get; set; }        // Navigeringsegenskap till Post  public ICollection<Response> Responses { get; set; }  // Relationen: en kommentar kan ha flera svar

    }
}
