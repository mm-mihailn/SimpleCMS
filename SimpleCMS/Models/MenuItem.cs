using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Models
{
    public class MenuItem
    {
        public MenuItem()
        {
            Title = Title = Guid.NewGuid().ToString();
            Link = String.Empty;
            SubMenuItems = new List<MenuItem>();
            Published = false;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public bool Published { get; set; }
        public int? ParentId { get; set; }
        public MenuItem? Parent { get; set; }
        public ICollection<MenuItem> SubMenuItems { get; set; }
    }
}
