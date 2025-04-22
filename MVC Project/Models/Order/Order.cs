using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Pending";

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Required]
    [StringLength(500)]
    public string ShippingAddress { get; set; }

    [Required]
    [StringLength(50)]
    public string PaymentMethod { get; set; } 

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}