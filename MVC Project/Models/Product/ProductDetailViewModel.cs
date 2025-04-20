using MVC_Project.Models;

public class ProductDetailViewModel
{
    public ProductViewModel Product { get; set; }
    public IEnumerable<ProductReviewViewModel> Reviews { get; set; }
    public ProductReviewViewModel NewReview { get; set; }
}