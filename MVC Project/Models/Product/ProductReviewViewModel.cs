using System.ComponentModel.DataAnnotations;

public class ProductReviewViewModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    [StringLength(1000)]
    public string Comment { get; set; }
    public DateTime Date { get; set; }
}