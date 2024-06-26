using System.Collections;
using DynamicPricing.DTO;
using DynamicPricing.Service;
using Microsoft.AspNetCore.Mvc;

namespace DynamicPricing.Controller;

[ApiController]
[Route("[controller]")]
public class RetailerController : ControllerBase
{
    private readonly RetailerService _retailerService;

    public RetailerController(RetailerService retailerService)
    {
        _retailerService = retailerService;
    }

    [HttpPatch("updatePrices", Name = "Update prices for a retailer")]
    public IActionResult UpdatePricesForRetailer([FromBody] AlterPriceRetailerDTO alterPrice)
    {
        return Ok(_retailerService.UpdatePricesRetailerAsync(alterPrice));
    }

    [HttpGet("{retailerId}/priceRecommendation/{productId}", Name = "Get price recommendation for a product")]
    public IActionResult GetPriceRecommendationForRetailer(int retailerId, int productId){
        var recommendedPrice = _retailerService.GetPriceRecommendationForRetailer(retailerId, productId);
        if(recommendedPrice == null)
            return NotFound("Invalid Product ID.");
        else if(recommendedPrice == -1)
            return BadRequest("Invalid retailer ID or the Product do not belongs to Retailer.");
        return Ok(recommendedPrice);
    }

}