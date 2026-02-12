using in_tend_product_shop_cart_sampl.Models;
using in_tend_product_shop_cart_sampl.Repositories;

namespace in_tend_product_shop_cart_sampl.Services
{
    public class CartService : ICartService
    {
        private readonly IProductRepository _products; // dummy product data

        // singleton used for simple demo, shared
        private readonly Dictionary<int, int> _quantities = new();

        public CartService(IProductRepository products)
        {
            _products = products; 
        }

        public ShoppingCart GetCart()
        {
            var cart = new ShoppingCart();

            foreach (var kvp in _quantities)
            {
                var productId = kvp.Key;
                var quantity = kvp.Value;

                var product = _products.GetById(productId);
                if (product is null)
                {
                    continue;
                }

                cart.Items.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }

            return cart;
        }

        public bool AddItem(int productId, int quantity, out string? error)
        {
            error = null;

            if (quantity <= 0)
            {
                error = "Quantity must be greater than zero.";
                return false;
            }

            var product = _products.GetById(productId);
            if (product is null)
            {
                error = $"No product exists with id {productId}.";
                return false;
            }

            if (_quantities.TryGetValue(productId, out var existingQty))
            {
                _quantities[productId] = existingQty + quantity;
            }
            else
            {
                _quantities[productId] = quantity;
            }

            return true;
        }

        public bool ReduceItem(int productId, int quantity, out string? error)
        {
            error = null;

            if (quantity <= 0)
            {
                error = "Quantity must be greater than zero.";
                return false;
            }

            if (!_quantities.TryGetValue(productId, out var existingQty))
            {
                error = "That product is not in the cart.";
                return false;
            }

            var newQty = existingQty - quantity;

            if (newQty > 0)
            {
                _quantities[productId] = newQty;
            }
            else
            {
                // If it hits zero (or below), remove the item entirely
                _quantities.Remove(productId);
            }

            return true;
        }

        public bool RemoveItemAll(int productId, out string? error)
        {
            error = null;

            if (!_quantities.ContainsKey(productId))
            {
                error = "That product is not in the cart.";
                return false;
            }

            _quantities.Remove(productId);
            return true;
        }

        public void Clear() => _quantities.Clear();

    }
}
