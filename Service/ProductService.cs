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

    public IEnumerable<Product> GetAll(){
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
        from rp in _dbConnect.RetailerProducts
        join p in _dbConnect.Product on rp.ProductId equals p.Id
        join r in _dbConnect.Retailer on rp.RetailerId equals r.Id
        where p.Id == id
        select new
        {
            RetailerName = r.Name,
            rp.Price,
        };

    }
    public Double GetMaxPrice(int id)
    {
        return _dbConnect.RetailerProducts.
        Where(rp => rp.ProductId == id).
        Min(rp => rp.Price);
    }

    public IEnumerable? GetCompetitorsOfGrp(int id)
    {
        return 
        from p in _dbConnect.Product
        join rp in _dbConnect.RetailerProducts on p.Id equals rp.ProductId
        join r in _dbConnect.Retailer on rp.RetailerId equals r.Id
        where p.GroupId == id
        select new 
        {
            RetailerName = r.Name
        };
    }
}