using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class ReviewViewModel
{
    public int ProductId { get; set; }
    public int ReviewId { get; set; }

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    [Required]
    [StringLength(1000)]
    public string Comment { get; set; }

    public List<Review> ExistingReviews { get; set; } = new List<Review>(); // Initialize empty list
    public SelectList Products { get; set; } = new SelectList(Enumerable.Empty<SelectListItem>()); // Initialize empty
}