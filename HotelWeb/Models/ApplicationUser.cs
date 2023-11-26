using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelWeb.Models
{
    public class ApplicationUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [StringLength(100)]
        [Column("name")]
        public string? Name { get; set; }

        [StringLength(15)]
        [Column("phone")]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        [Column("email")]
        public  string? Email { get; set; }
        [Column("image")]
        [StringLength(100)]
        public string? Image { get; set; }
        [Column("role")]
        [StringLength(30)]
        public string? Role { get; set; }
    }
}
