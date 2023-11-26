using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWeb.Models
{
    [Table("room_image")]
    public class RoomImage
    {
        [Key]
        public int Id { get; set; }
        [Column("main_img")]
        public bool MainImg { get; set; } =false;
        [Column("path")]
        public string ?Path { set; get; }
        [Column("room_id")]
        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public Room ?Room { get; set; }
    }
}
