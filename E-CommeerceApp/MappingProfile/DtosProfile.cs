using AutoMapper;
using E_CommeerceApp.Dtos.Products;
using E_CommeerceApp.Models;

namespace E_CommeerceApp.MappingProfile
{
    public class DtosProfile : Profile
    {
        public DtosProfile()
        {
            CreateMap<CreateProductDto,Products>();
            CreateMap<UpdateProductDto,Products>();
            CreateMap<Products, ProductDto>();
        }
    }
}
