using System.Collections;
using DynamicPricing.Data;
using DynamicPricing.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DynamicPricing.Service;

public class ProductService {
    private readonly DynamicPricingContext _dbConnect;

    public ProductService(DynamicPricingContext dbConnect)
    {
        _dbConnect = dbConnect;
    }

    public List<Product> GetAll(){
        return _dbConnect.Product
        .AsNoTracking()
        .ToList();
    }

    /// <summary>
    /// This API fetches a product on passing a valid Product Id.
    /// </summary>
    /// <param name="id">The Id of the product to fetched.</param>
    /// <returns>Product Details</returns>
    public Product? GetProduct(int id){
        return _dbConnect.Product
        .AsNoTracking()
        .FirstOrDefault(p => p.Id == id);
    }

    /// <summary>
    /// This service fetches all the prices of a Product that belongs to different Retailers.
    /// </summary>
    /// <param name="id">The Id of the product to fetch different valuation from Retailers.</param>
    /// <returns>List of Prices</returns>
    public IEnumerable? GetAllPricesProduct(int id){
        return 
        /*
        from rp in _dbConnect.RetailerProducts
        join p in _dbConnect.Product on rp.ProductId equals p.Id
        join r in _dbConnect.Retailer on rp.RetailerId equals r.Id
        where p.Id == id
        select new
        {
            RetailerName = r.Name,
            rp.Price,
        };
        */
        _dbConnect.RetailerProducts
        .Join(_dbConnect.Product,
            rp => rp.ProductId,
            p => p.Id,
            (rp, p) => new { rp, p })
        .Join(_dbConnect.Retailer,
            rpp => rpp.rp.RetailerId,
            r => r.Id,
            (rpp, r) => new { rpp.rp, rpp.p, r })
        .Where(rpp => rpp.p.Id == id)
        .Select(rpp => new 
        {
            RetailerName = rpp.r.Name,
            rpp.rp.Price
        });
    }

    /// <summary>
    /// This service fetches the highest tier price of a product.
    /// </summary>
    /// <param name="id">The Id of the product to fetch it's highest tier 1 price.</param>
    /// <returns>Highest tier 1 price of a product</returns>
    public Double? GetMaxPrice(int id)
    {
        Double maxPriceOfProduct = 0;
        try
        {   
            maxPriceOfProduct = _dbConnect.RetailerProducts.
                                Where(rp => rp.ProductId == id).
                                Max(rp => rp.Price);
        }
        catch(InvalidOperationException e)
        {
            Console.Write(e);
            return null;
        }
        return maxPriceOfProduct;
    }

    /// <summary>
    /// This service fetches all the other retailers whose competitors has to be fetched
    /// </summary>
    /// <param name="productGroupId">Group ID whose whose competitors has to fetched.</param>
    /// <returns>List of Competitors</returns>
    public IEnumerable? GetCompetitorsOfGrp(int productGroupId)
    {
        return 
        (from p in _dbConnect.Product
        join rp in _dbConnect.RetailerProducts on p.Id equals rp.ProductId
        join r in _dbConnect.Retailer on rp.RetailerId equals r.Id
        where p.GroupId == productGroupId
        select new 
        {
            RetailerName = r.Name
        }).Distinct();

    }
}