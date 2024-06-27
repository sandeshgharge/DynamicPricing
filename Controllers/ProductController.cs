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


    /// <summary>
    /// This API fetches a product on passing a valid Product Id.
    /// </summary>
    /// <param name="productId">The Id of the product to fetched.</param>
    /// <returns>Product Details</returns>
    [HttpGet("{productId}",Name = "Get product details")]
    public ActionResult <ProductDTO> GetProduct(int productId){
        var productObj = _prodService.GetProduct(productId);
        if(productObj != null)
            return Ok(_mapper.Map<ProductDTO>(productObj));

        return NotFound("Invalid Product ID.");
    }

    /// <summary>
    /// This API is used to get all the prices of a Product that belongs to different Retailers.
    /// </summary>
    /// <param name="productId">The Id of the product to fetch different valuation from Retailers.</param>
    /// <returns>List of Prices</returns>
    [HttpGet("prices/{productId}",Name = "Get all prices for a product")]
    public ActionResult GetAllPricesProduct(int productId){
        var resObj = _prodService.GetAllPricesProduct(productId);
        if(resObj != null)
            return Ok(resObj);

        return NotFound("Invalid Product ID.");
    }

    /// <summary>
    /// This API is used to fetch the highest tier price of a product.
    /// </summary>
    /// <param name="productId">The Id of the product to fetch it's highest tier 1 price.</param>
    /// <returns>Highest tier 1 price of a product</returns>
    [HttpGet("maxPrices/{productId}",Name = "Get highest tier 1 price for a product")]
    public ActionResult GetMaxPriceProduct(int productId){
        var maxPrice =_prodService.GetMaxPrice(productId);

        if(maxPrice != null)
            return Ok(maxPrice);

        return NotFound("Invalid Product ID.");
    }

    /// <summary>
    /// This API fetches all the other retailers whose competitors has to be fetched
    /// </summary>
    /// <param name="productGroupId">Group ID whose whose competitors has to fetched.</param>
    /// <returns>List of Competitors</returns>
    [HttpGet("competitors/{productGroupId}", Name = "Get all competitors for a product group")]
    public IEnumerable? GetCompetitorsOfGrp(int productGroupId)
    {
        return _prodService.GetCompetitorsOfGrp(productGroupId);
    }
}