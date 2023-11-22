using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Models
{
    public class Files
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
    }
}
