using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project.Models;

public class ProductListViewModel
{
    public IEnumerable<ProductViewModel> Products { get; set; }
    public IEnumerable<CategoryViewModel> Categories { get; set; }
    public int? SelectedCategory { get; set; }
    public string SortBy { get; set; }
    public List<SelectListItem> SortOptions { get; set; }
}