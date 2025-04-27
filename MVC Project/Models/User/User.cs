using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User : IdentityUser
{
     
    [StringLength(50)]
    public string FullName { get; set; }

    [Required]
    [StringLength(20)]
    public string Role { get; set; } = "Customer";

    [Required]
    [StringLength(255)]
    public string Address { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<PasswordResetToken> PasswordResetTokens { get; set; }
    public virtual Cart Cart { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}