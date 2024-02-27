using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleCMS.Admin.Models.ViewModel
{
    public class RichTextEditorViewModel
    {
        [AllowHtml]
        [Display(Name = "Message")]
        public string? Message { get; set; }

    }
}
