using SimpleCMS.Data.Models;

namespace SimpleCMS.Web.Models
{
    public class SpecialtiesViewModel
    {
            public List<Specialtie> Specialties { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        
    }
}
