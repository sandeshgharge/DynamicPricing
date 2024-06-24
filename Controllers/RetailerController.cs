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
        return _retailerService.UpdatePricesRetailer(alterPrice);
    }

    [HttpGet("priceRecommendation/{id}", Name = "Get price recommendation for a product")]
    public Double? GetPriceRecommendationForRetailer(int retailerId, int productId){
        return _retailerService.GetPriceRecommendationForRetailer(retailerId, productId);
    }

}