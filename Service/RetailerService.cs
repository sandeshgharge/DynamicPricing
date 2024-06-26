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