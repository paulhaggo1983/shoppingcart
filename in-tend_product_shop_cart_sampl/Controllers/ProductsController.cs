using in_tend_product_shop_cart_sampl.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using in_tend_product_shop_cart_sampl.Dtos;

namespace in_tend_product_shop_cart_sampl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _products;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository products, IMapper mapper)
        {
            _products = products;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll() // /api/products (Gets all products)
        {
            var items = _products.GetAll();
            var dto = _mapper.Map<List<ProductDto>>(items);
            return Ok(dto);
        }


        [HttpGet("{id:int}")] // /api/products/1 (Gets a single product)
        public IActionResult GetById(int id)
        {
            var product = _products.GetById(id);

            if (product is null)
            {
                return Problem(
                    title: "Product not found",
                    detail: $"No product with id {id}.",
                    statusCode: StatusCodes.Status404NotFound);
            }

            var dto = _mapper.Map<ProductDto>(product);
            return Ok(dto);
        }

    }
}
