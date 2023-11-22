using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Models
{
    public class Article
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public string Slug { get; set;}
        public bool IsNews { get; set; }
        public int Type { get; set; }
        public Collection<Files> Files{ get; set; }

    }
}
