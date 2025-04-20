using MVC_Project.Models;

public class OrderDetailViewModel
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Subtotal { get; set; }
    public decimal DeliveryFee { get; set; }
    public decimal Total { get; set; }
    public string Status { get; set; }
    public ShippingInfoViewModel ShippingInfo { get; set; }
    public IEnumerable<OrderItemViewModel> Items { get; set; }
}