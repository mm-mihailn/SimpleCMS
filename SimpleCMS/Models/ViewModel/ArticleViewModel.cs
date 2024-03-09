using SimpleCMS.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SimpleCMS.Web.Models.ViewModel
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
