using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Application.Models
{
    public class Company
    {
        [Key]
        [DisplayName("Company Id")]
        public int CompanyId { get; set; }
        [DisplayName("Company Name")]
        public string? Name { get; set; }

        //Navigation Property
        public ICollection<Employee>? Employees { get; set; }
    }
}
