using in_tend_product_shop_cart_sampl.Models;

namespace in_tend_product_shop_cart_sampl.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {

        // inmemory products
        private readonly List<Product> _products = new()
{
    new Product
    {
        Id = 1,
        Name = "Haribo",
        Description = "Jelly  sweets",
        Price = 1.50m
    },
    new Product
    {
        Id = 2,
        Name = "Maltesers",
        Description = "Chocolate Balls, Good for Films",
        Price = 1.35m
    },
    new Product
    {
        Id = 3,
        Name = "Dairy Milk",
        Description = "Classic bar",
        Price = 1.25m
    },
    new Product
    {
        Id = 4,
        Name = "Skittles",
        Description = "Skittles des",
        Price = 1.20m
    },
    new Product
    {
        Id = 5,
        Name = "Wine Gums",
        Description = ".",
        Price = 1.40m
    }
};


        public IReadOnlyList<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);


    }
}
