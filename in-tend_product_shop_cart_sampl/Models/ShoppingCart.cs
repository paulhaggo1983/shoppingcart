namespace in_tend_product_shop_cart_sampl.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; } = new();

        public int TotalItems => Items.Sum(i => i.Quantity);

        public decimal Subtotal => Items.Sum(i => i.LineTotal);

    }
}
