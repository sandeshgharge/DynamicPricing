using System.ComponentModel.DataAnnotations;

namespace DynamicPricing.Models;

/// <summary>
/// Represents the relationship between retailers and products.
/// </summary>
public class RetailerProducts{

    [Key]
    public int Id { get; set; }
    public int RetailerId { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public double MinPrice { get; set; }
}