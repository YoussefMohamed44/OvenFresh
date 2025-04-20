using System.ComponentModel.DataAnnotations;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    public string ImageUrl { get; set; }
    public string CategoryName { get; set; }
    public int CategoryId { get; set; }
    public double AverageRating { get; set; }
    public int ReviewCount { get; set; }
    public DateTime DateAdded { get; set; }
}