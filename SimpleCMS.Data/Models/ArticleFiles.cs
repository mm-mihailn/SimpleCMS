using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Models
{
    public class ArticleFiles
    {
        [Key]
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int FileId { get; set; }
        public Files File  { get; set; }
    }
}
