namespace in_tend_product_shop_cart_sampl.Dtos;

public class CartItemDto
{
    public ProductDto Product { get; set; } = new();
    public int Quantity { get; set; }
    public decimal LineTotal { get; set; }
}