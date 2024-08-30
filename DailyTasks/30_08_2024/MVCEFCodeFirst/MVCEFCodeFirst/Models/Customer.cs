using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MVCEFCodeFirst.Models
{
    public class Customer
    {

        [Key]
        public int CustId {  get; set; }
        public string CustName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


        public List<Order>? orders { get; set; }
    }
}
