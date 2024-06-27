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

    /// <summary>
    /// This API can be used to alter prices of a product as needed.
    /// Price can be altered in 2 ways, in the form of discount or a specific value.
    /// A flag in the body object is used to method of deduction
    /// </summary>
    /// <param name="alterPrice">
    /// This is a body object containing -
    /// Product ID - Whose price has to be altered.
    /// Retailer ID - Retailer who wants to alter the price of a product.
    /// isDiscount - Flag which confirms if the value is in the form of discount or direct value.
    /// Value - The amount that has be to deducted from the current price.</param>
    /// <returns>String stating the update if the prices as updated.</returns>
    [HttpPatch("updatePrices", Name = "Update prices for a retailer")]
    public IActionResult UpdatePricesForRetailer([FromBody] AlterPriceRetailerDTO alterPrice)
    {
        return Ok(_retailerService.UpdatePricesRetailerAsync(alterPrice));
    }

    /// <summary>
    /// This API is used to recommend a price for a retailer, considering the valuation of a product by other competitors.
    /// </summary>
    /// <param name="retailerId">Retailer Id who needs the recommedations.</param>
    /// <param name="productId">Product Id whose recommendation we need.</param>
    /// <returns>Recommended value.</returns>
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