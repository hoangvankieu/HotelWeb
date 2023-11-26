using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelWeb.Models
{
    [Table("room")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; } = "";

        [Column("price")]
        [Required]
        public double Price { get; set; }


        [Column("description")]
        [StringLength(500)]
        public string ?Description { get; set; }
        public IEnumerable<RoomImage>? Images { get; }
    }
}
