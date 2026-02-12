namespace in_tend_product_shop_cart_sampl.Models
{
    public class CartItem
    {

        public required Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal LineTotal => Product.Price * Quantity;


    }
}
