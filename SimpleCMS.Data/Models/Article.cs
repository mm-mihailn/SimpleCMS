using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SimpleCMS.Data.Enums;

namespace SimpleCMS.Data.Models
{
    public class Article
    {
        public Article()
        {
            CreatedById = Guid.Empty.ToString();
            Title = Guid.NewGuid().ToString();
            Files = new List<Files>();
            Slug = Title;
            Type = ArticleType.General;
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Content { get; set; }
        public bool Published { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public string Slug { get; set;}
        public ArticleType Type { get; set; }

        public string Image { get; set; }
        public string CreatedById { get; set; }
        
        public ICollection<Files> Files{ get; set; }

    }
}
