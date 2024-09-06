using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Application.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime? JoiningDate { get; set; }

        [ForeignKey("CompanyId")]
        public int CompanyId {  get; set; }
        public Company? Company { get; set; }

    }
}
