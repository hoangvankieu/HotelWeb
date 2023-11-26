using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWeb.Models
{
    [Table("customer")]
    public class Customer:ApplicationUser
    {
        [Column("order_number")]
        public int ?OrderNumber { get; set; }

        public IEnumerable<Order>? Order { get; set; }
    }
}
