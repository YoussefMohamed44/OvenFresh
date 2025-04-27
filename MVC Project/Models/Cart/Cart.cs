using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Cart
{
    [Key]
    public int CartId { get; set; }

    [Required]
    [ForeignKey("User")]
    public string UserId { get; set; } // Change from int to string

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
}