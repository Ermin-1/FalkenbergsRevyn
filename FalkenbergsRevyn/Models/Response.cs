using System.ComponentModel.DataAnnotations;

namespace FalkenbergsRevyn.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public string ResponseContent { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime DateResponded { get; set; }

        public int CommentId { get; set; }    // Relationen: svar hör till en kommentar public Comment Comment { get; set; }  // Navigeringsegenskap till Comment
        public Comment? Comment { get; set; }

    }
}
