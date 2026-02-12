namespace in_tend_product_shop_cart_sampl.Dtos;

public class ShoppingCartDto
{
    public List<CartItemDto> Items { get; set; } = new();
    public int TotalItems { get; set; }
    public decimal Subtotal { get; set; }
}