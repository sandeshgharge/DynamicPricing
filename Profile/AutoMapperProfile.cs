using AutoMapper;
using DynamicPricing.DTO;
using DynamicPricing.Models;

namespace DynamicPricing.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDTO>();
    }
}