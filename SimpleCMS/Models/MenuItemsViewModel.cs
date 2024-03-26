using SimpleCMS.Data.Models;

namespace SimpleCMS.Web.Models
{
    public class MenuItemsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public bool Published { get; set; }
        public int? ParentId { get; set; }
        public MenuItem? Parent { get; set; }
        public ICollection<MenuItem> SubMenuItems { get; set; }
    }
}
