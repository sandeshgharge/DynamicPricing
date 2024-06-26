using System.Collections;
using AutoMapper;
using DynamicPricing.DTO;
using DynamicPricing.Models;
using DynamicPricing.Profiles;
using DynamicPricing.Service;
using Microsoft.AspNetCore.Mvc;

namespace DynamicPricing.Controller;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _prodService;
    private readonly IMapper _mapper;

    public ProductController(ProductService prodService, IMapper mapper)
    {
        _prodService = prodService;
        _mapper = mapper;
    }

    [HttpGet("{productId}",Name = "Get product details")]
    public ActionResult <ProductDTO> GetProduct(int productId){
        var productObj = _prodService.GetProduct(productId);
        if(productObj != null)
            return Ok(_mapper.Map<ProductDTO>(productObj));

        return NotFound("Invalid Product ID.");
    }

    [HttpGet("prices/{productId}",Name = "Get all prices for a product")]
    public ActionResult GetAllPricesProduct(int productId){
        var resObj = _prodService.GetAllPricesProduct(productId);
        if(resObj != null)
            return Ok(resObj);

        return NotFound("Invalid Product ID.");
    }

    [HttpGet("maxPrices/{productId}",Name = "Get highest tier 1 price for a product")]
    public ActionResult GetMaxPriceProduct(int productId){
        var maxPrice =_prodService.GetMaxPrice(productId);

        if(maxPrice != null)
            return Ok(maxPrice);

        return NotFound("Invalid Product ID.");
    }

    [HttpGet("competitors/{productGroupId}", Name = "Get all competitors for a product group")]
    public IEnumerable? GetCompetitorsOfGrp(int productGroupId)
    {
        return _prodService.GetCompetitorsOfGrp(productGroupId);
    }
}