using AutoMapper;
using SignalRDtoLayer.ProductDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,GetProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,ResultProductWithCategory>().ReverseMap();
            CreateMap<Product,ResultProductWithCategory>().ForMember(x=>x.CategoryName,y=>y.MapFrom(x=>x.Category.CategoryName)).ReverseMap();

        }
    }
}
