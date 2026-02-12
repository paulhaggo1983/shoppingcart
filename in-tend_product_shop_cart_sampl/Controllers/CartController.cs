using in_tend_product_shop_cart_sampl.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using in_tend_product_shop_cart_sampl.Dtos;

namespace in_tend_product_shop_cart_sampl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cart;
        private readonly IMapper _mapper;

        public CartController(ICartService cart, IMapper mapper)
        {
            _cart = cart;
            _mapper = mapper;
        }

        private ShoppingCartDto GetCartDto()
        {
            var cart = _cart.GetCart();
            return _mapper.Map<ShoppingCartDto>(cart);
        }


        [HttpGet]
        public IActionResult GetCart() // /api/cart
        {
            return Ok(GetCartDto());
        }



        [HttpPost("items")] // adding new product or adding to existing  - /api/cart/items?productId=1&quantity=2
        public IActionResult AddItem([FromQuery] int productId, [FromQuery] int quantity = 1)
        {
            if (!_cart.AddItem(productId, quantity, out var error))
            {
                return Problem(
                                            title: "Could not add item",
                                            detail: error,
                                            statusCode: StatusCodes.Status400BadRequest);

            }

            return Ok(GetCartDto());
        }


        [HttpPatch("items/{productId:int}")] // reduces qty only (will not add new). /api/cart/items/{productId}?quantity=1
        public IActionResult ReduceItem(int productId, [FromQuery] int quantity = 1)
        {
            if (!_cart.ReduceItem(productId, quantity, out var error))
            {
                return Problem(
                                             title: "Could not reduce item",
                                             detail: error,
                                             statusCode: StatusCodes.Status400BadRequest);

            }

            return Ok(GetCartDto());
        }

        [HttpDelete("items/{productId:int}")] // /api/cart/items/{productId}
        public IActionResult RemoveItemAll(int productId)
        {
            if (!_cart.RemoveItemAll(productId, out var error))
            {
                return Problem(
                    title: "Could not remove item",
                    detail: error,
                    statusCode: StatusCodes.Status400BadRequest);
            }

            return Ok(GetCartDto());
        }

        [HttpDelete]
        public IActionResult ClearCart() // /api/cart
        {
            _cart.Clear();
            return Ok(GetCartDto());
        }
    }
}
