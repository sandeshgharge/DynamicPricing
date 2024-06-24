using System.Collections;
using DynamicPricing.Data;
using DynamicPricing.DTO;
using DynamicPricing.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DynamicPricing.Service;

public class RetailerService
{
    private readonly DynamicPricingContext _dbconnect;

    public RetailerService(DynamicPricingContext dbConnect)
    {
        _dbconnect = dbConnect;
    }

    public IActionResult UpdatePricesRetailer(AlterPriceRetailerDTO alterPrice)
    {
        return null;
    }

    public Double? GetPriceRecommendationForRetailer(int retailerId, int productId)
    {
        Double minPriceOfProduct = _dbconnect.RetailerProducts.
        Where(rp => rp.ProductId == productId).
        Min(rp => rp.Price);
        RetailerProducts? minPriceOfRetailerProduct = _dbconnect.RetailerProducts.FirstOrDefault(rp => rp.RetailerId == retailerId && rp.ProductId == productId);

        if(minPriceOfRetailerProduct?.Price < minPriceOfProduct)
            return minPriceOfRetailerProduct?.Price;
        else if(minPriceOfRetailerProduct?.MinPrice > minPriceOfProduct)
            return minPriceOfRetailerProduct?.MinPrice;
        else
            return minPriceOfProduct;
    }
}