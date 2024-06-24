using DynamicPricing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Net.Http.Headers;

namespace DynamicPricing.Data;

public class DynamicPricingContext : DbContext 
{
    public DynamicPricingContext(DbContextOptions<DynamicPricingContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Product => Set<Product>();
    public DbSet<Retailer> Retailer => Set<Retailer>();
    public DbSet<ProductGroup> ProductGroup => Set<ProductGroup>();
    public DbSet<RetailerProducts> RetailerProducts => Set<RetailerProducts>();
}