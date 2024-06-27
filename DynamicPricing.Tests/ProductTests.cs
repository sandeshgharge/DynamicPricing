using AutoMapper;
using DynamicPricing.Controller;
using DynamicPricing.Data;
using DynamicPricing.DTO;
using DynamicPricing.Service;
using Xunit;

namespace DynamicPricing.Tests;

public class ProductTests
{
    private ProductController _controller;
    public ProductTests(DynamicPricingContext dbConnect, IMapper mapper)
    {   
        _controller = new ProductController(new ProductService(dbConnect), mapper);
    }
    [Fact]
    public void GetProduct()
    {
        Assert.IsType<ProductDTO>(_controller.GetProduct(1));
    }
}