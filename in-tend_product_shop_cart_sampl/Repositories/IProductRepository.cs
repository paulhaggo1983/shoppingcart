using in_tend_product_shop_cart_sampl.Models;

namespace in_tend_product_shop_cart_sampl.Repositories
{
    public interface IProductRepository
    {
        IReadOnlyList<Product> GetAll();
        Product? GetById(int id);

    }
}
