public class CartViewModel
{
    public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

    public decimal Subtotal => Items.Sum(i => i.Price * i.Quantity);
    public decimal DeliveryFee => Subtotal < 50 ? 5.99m : 0m;
    public decimal Total => Subtotal + DeliveryFee;
}