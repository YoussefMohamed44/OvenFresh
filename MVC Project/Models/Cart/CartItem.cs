using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class CartItem
{
    [Key]
    public int CartItemId { get; set; }

    [Required]
    [ForeignKey("Cart")]
    public int CartId { get; set; }

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [Required]
    [Range(1, 100)]
    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public virtual Cart Cart { get; set; }
    public virtual Product Product { get; set; }
}