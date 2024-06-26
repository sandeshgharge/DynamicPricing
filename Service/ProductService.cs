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

    public Product? GetProduct(int id){
        return _dbConnect.Product
        .AsNoTracking()
        .FirstOrDefault(p => p.Id == id);
    }


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