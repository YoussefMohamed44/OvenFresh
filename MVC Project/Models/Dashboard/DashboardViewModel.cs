using MVC_Project.Models;

public class DashboardViewModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public int OrderCount { get; set; }
    public int ReviewCount { get; set; }
    public IEnumerable<OrderSummaryViewModel> RecentOrders { get; set; }
}