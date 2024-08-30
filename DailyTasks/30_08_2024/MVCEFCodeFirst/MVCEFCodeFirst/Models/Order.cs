using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEFCodeFirst.Models
{
    public class Order
    {
        public int OrderId {  get; set; }

        public string ProductName {  get; set; }

        public DateTime? OrderDate { get; set; }
        public int CustId  { get; set; }

        //Navigation Property - one order -one customer
        [ForeignKey("CustId")]
        public Customer? Customer { get; set; }
    }
}
