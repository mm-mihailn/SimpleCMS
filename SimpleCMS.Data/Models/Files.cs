using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Models
{
    public class Files
    {
        public Files()
        {
            Name = String.Empty;
            Path = String.Empty;
            MimeType = String.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }


        public List<Article> Articles { get; set; }
    }
}
