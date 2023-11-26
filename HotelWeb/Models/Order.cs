using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HotelWeb.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("order_date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime OrderDate { get; set; }


        [Column("expired_date")]
        public DateTime ExpiredDate { get; set; }

        [Column("money_total")]
        public float MoneyTotal { get; set; }

        [DefaultValue(false)]
        [Column("accept")]
        public bool Accept { get; set; }

        [DefaultValue(false)]
        [Column("cancel")]
        public bool Cancel { get; set; }

        [ForeignKey("Customer")]
        [Column("cus_id")]
        public int ?CustomerId { get; set; }
        public Customer ?Customer { get; set; }

        [ForeignKey("Administration")]
        [Column("admin_id")]
        public int ?AdminId { get; set; }
        public Administration? Administration { get; set; }
        
    }
}
