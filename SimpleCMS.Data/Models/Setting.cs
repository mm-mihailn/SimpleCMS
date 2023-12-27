using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMS.Data.Models
{
    public class Setting
    {
        public Setting()
        {
            Name = String.Empty;
            Value = String.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
