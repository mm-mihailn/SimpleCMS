using SimpleCMS.Data.Enums;
using SimpleCMS.Data.Models;

namespace SimpleCMS.Admin.Models.ViewModel
{
    public class ArticleViewModel
    {
        public List<Article> Articles { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Content { get; set; }
        public bool Published { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }

        public string CreatedById { get; set; }
    }
}
