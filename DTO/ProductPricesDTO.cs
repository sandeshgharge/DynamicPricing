namespace DynamicPricing.DTO;

/// <summary>
/// DTO object used to return prices of all the retailers
/// </summary>
public class ProductPricesDTO
{
    public string? RetailerName { get; set; }
    public int Price { get; set; }
}