using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelWeb.Models
{
    public class OrderDetail
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Order")]

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room ?Room { get; set; }
    }
}
