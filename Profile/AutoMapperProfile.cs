using AutoMapper;
using DynamicPricing.DTO;
using DynamicPricing.Models;

namespace DynamicPricing.Profiles;

/// <summary>
/// AutoMapper profile used to convert conventional models to DTO objects for Data transfer.
/// </summary>
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDTO>();
    }
}