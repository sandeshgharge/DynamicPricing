using DynamicPricing.Data;
using DynamicPricing.DTO;
using DynamicPricing.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicPricing.Service;

public class RetailerService
{
    private readonly DynamicPricingContext _dbconnect;

    public RetailerService(DynamicPricingContext dbConnect)
    {
        _dbconnect = dbConnect;
    }

    /// <summary>
    /// This Service alters prices of a product as needed.
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

    public async Task<string?> UpdatePricesRetailerAsync(AlterPriceRetailerDTO alterPrice)
    {
        int retailerId = alterPrice.retailerId;
        double valueToReduce = alterPrice.value;            
        if(alterPrice?.productId != null)
        {
            var productId = alterPrice.productId;
            var retailerProduct = await _dbconnect.RetailerProducts
            .FirstAsync<RetailerProducts>(rp => rp.ProductId == productId && rp.RetailerId == retailerId);

            var currentPrice = retailerProduct.Price;
            var newValue = currentPrice;
            if(alterPrice.isPercentage)
            {
                newValue = currentPrice*(1-(valueToReduce/100));
            }
            else
            {
                newValue = currentPrice - valueToReduce;
            }

            if(newValue > retailerProduct.MinPrice)
            {
                retailerProduct.Price = newValue;
                await _dbconnect.SaveChangesAsync();
            }
            else
            {
                retailerProduct.Price = retailerProduct.MinPrice;
                await _dbconnect.SaveChangesAsync();
                return "Minimum CAP value reached.";
            }
        }
        else
        {
            // Logic to update multiple rows, in case Product ID is absent
        }
        return "Price udpated.";
    }

    /// <summary>
    /// This Service recommend a price for a retailer, considering the valuation of a product by other competitors.
    /// The price is recommended using Minimum price set by a retailer, current minimum value in the market and current valuation of the product by the retailer.
    /// </summary>
    /// <param name="retailerId">Retailer Id who needs the recommedations.</param>
    /// <param name="productId">Product Id whose recommendation we need.</param>
    /// <returns>Recommended value.</returns>
    public Double? GetPriceRecommendationForRetailer(int retailerId, int productId)
    {
        Double minPriceOfProduct = 0;
        try
        {   
            minPriceOfProduct = _dbconnect.RetailerProducts.
                Where(rp => rp.ProductId == productId).
                Min(rp => rp.Price);
        }
        catch(InvalidOperationException e)
        {
            Console.Write(e);
            return null;
        }
        
        RetailerProducts? retailerProduct = _dbconnect.RetailerProducts.FirstOrDefault(rp => rp.RetailerId == retailerId && rp.ProductId == productId);
        
        if(retailerProduct == null)
            return -1;
        else if(retailerProduct.Price < minPriceOfProduct)
            return retailerProduct.Price;
        else if(retailerProduct.MinPrice > minPriceOfProduct)
            return retailerProduct.MinPrice;
        else
            return minPriceOfProduct;
    }
}