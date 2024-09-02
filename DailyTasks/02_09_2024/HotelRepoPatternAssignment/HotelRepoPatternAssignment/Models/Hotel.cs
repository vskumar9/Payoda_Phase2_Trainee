using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelRepoPatternAssignment.Models
{
    public class Hotel
    {
        [Key]
        [DisplayName("Hotel Number")]
        public int HotelId{ get; set; }

        [DisplayName("Hotel Name")]
        [StringLength(30, ErrorMessage = "Hotel Name should be below 30 characters", MinimumLength =5)]
        public string HotelName { get; set; }

        public ICollection<Room> Room { get; set; }


    }
}
