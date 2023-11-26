using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWeb.Models
{
    [Table("administration")]
    public class Administration:ApplicationUser
    {
        public IEnumerable<Order>? Orders { get; }
    }
}
