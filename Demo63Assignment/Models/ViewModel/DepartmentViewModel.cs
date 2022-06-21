using System.ComponentModel.DataAnnotations;

namespace Demo63Assignment.Models.ViewModel
{
    public class DepartmentViewModel
    {      
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }      
        public string Description { get; set; }
    }
}
