using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRepoPatternAssignment.Models
{
    public class Room
    {
        [Key]
        [DisplayName("Room Id")]
        public int RoomId { get; set; }

        [DisplayName("Room Number")]
        public int? RoomNumber { get; set; }

        [DisplayName("Room Type")]
        public string? RooomType { get; set; }

        [Range(500, 100000, ErrorMessage = "Price is should be 500 to 100000 ")]
        public decimal? Price { get; set; }

        [ForeignKey("HotelId")]
        public int? HotelId { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
