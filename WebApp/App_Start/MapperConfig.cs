using AutoMapper;
using Domain.Model;
using WebApp.Models;
using WebApp.Models.Order;
using WebApp.Models.Product;

namespace WebApp
{
    public class MapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>()
                    .ForMember(dest => dest.TotalPrice,
                        exp => exp.MapFrom(src => src.Price));
                cfg.CreateMap<CreateProductViewModel, Product>();
                cfg.CreateMap<EditProductViewModel, Product>();
                cfg.CreateMap<Product, EditProductViewModel>();
                cfg.CreateMap<Product, BuyProductViewModel>();

                cfg.CreateMap<Order, OrderViewModel>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}