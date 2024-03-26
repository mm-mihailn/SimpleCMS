using System.ComponentModel.DataAnnotations;
namespace SimpleCMS.Admin.Models.ViewModel
{
    public class RichTextEditorViewModel
    {
        
        [Display(Name = "Message")]
        public string? Message { get; set; }

    }
}
