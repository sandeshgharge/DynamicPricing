using System.Collections;
using DynamicPricing.Models;
using DynamicPricing.Service;
using Microsoft.AspNetCore.Mvc;

namespace DynamicPricing.Controller;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _prodService;
    public ProductController(ProductService prodService)
    {
        _prodService = prodService;
    }

    // [HttpGet(Name = "Get list of all products")]
    public IEnumerable<Product> GetAllProducts(){
        return _prodService.GetAll();
    }

    [HttpGet("{id}",Name = "Get product details")]
    public Product? GetProduct(int id){
        return _prodService.GetProduct(id);
    }

    [HttpGet("prices/{id}",Name = "Get all prices for a product")]
    public IEnumerable? GetAllPricesProduct(int id){
        return _prodService.GetAllPricesProduct(id);
    }

    [HttpGet("maxPrices/{id}",Name = "Get highest tier 1 price for a product")]
    public Double? GetMaxPriceProduct(int id){
        return _prodService.GetMaxPrice(id);
    }

    [HttpGet("competitors/{id}", Name = "Get all competitors for a product group")]
    public IEnumerable? GetCompetitorsOfGrp(int id)
    {
        return _prodService.GetCompetitorsOfGrp(id);
    }
}