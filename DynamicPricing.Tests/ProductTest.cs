using AutoMapper;
using DynamicPricing.Controller;
using DynamicPricing.Data;
using DynamicPricing.DTO;
using DynamicPricing.Service;
using Xunit;

namespace DynamicPricing.Tests;

public class ProductTest
{
    ProductController _controller;
    public ProductTest(DynamicPricingContext dbConnect, IMapper _mapper)
    {
        _controller = new ProductController(new ProductService(dbConnect), _mapper);
    }
    [Fact]
    public void FetchProductTest()
    {
        Assert.IsType<ProductDTO>(_controller.GetProduct(1));
    }
}