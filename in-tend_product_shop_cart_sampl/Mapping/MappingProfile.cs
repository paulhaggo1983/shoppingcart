using AutoMapper;
using in_tend_product_shop_cart_sampl.Dtos;
using in_tend_product_shop_cart_sampl.Models;

namespace in_tend_product_shop_cart_sampl.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile() // used for DTOs/automapper to decouple from the api
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CartItem, CartItemDto>();
        CreateMap<ShoppingCart, ShoppingCartDto>();
    }
}
