using Microsoft.AspNetCore.Html;

namespace FalkenbergsRevyn.ViewModels
{
    public class ModalViewModel
    {
        public string ModalId { get; set; }
        public string Title { get; set; }
        public IHtmlContent Body { get; set; }
        public string Footer { get; set; }
        public List<IHtmlContent> FooterButtons { get; set; }
    }
}
