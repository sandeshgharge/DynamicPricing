namespace DynamicPricing.DTO;

/// <summary>
/// This class object is used to update the prices of a product as per retailers needs.
/// </summary>
public class AlterPriceRetailerDTO
{
    public Boolean isPercentage { get; set; }
    public double value { get; set; }
    public int productId { get; set; }
    public int retailerId { get; set; }
}