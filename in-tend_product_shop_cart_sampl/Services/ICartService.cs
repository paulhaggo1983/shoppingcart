using in_tend_product_shop_cart_sampl.Models;

namespace in_tend_product_shop_cart_sampl.Services
{
    public interface ICartService
    {

        ShoppingCart GetCart();
        bool AddItem(int productId, int quantity, out string? error);
        bool ReduceItem(int productId, int quantity, out string? error);
        bool RemoveItemAll(int productId, out string? error);

        void Clear();


    }
}
