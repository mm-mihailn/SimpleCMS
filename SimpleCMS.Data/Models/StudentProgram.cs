using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Models
{
    public class StudentProgram
    {
        public StudentProgram()
        {
            DayOfTheWeek = string.Empty;
            SubjectName = string.Empty;
        }
        public int Id { get; set; }
        public string Class { get; set; }
        public int LessonsNumber { get; set; }
        public string DayOfTheWeek { get; set;}
        public string SubjectName { get; set;}
    }
}
