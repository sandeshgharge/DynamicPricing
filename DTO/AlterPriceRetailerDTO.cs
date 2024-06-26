namespace DynamicPricing.DTO;

public class AlterPriceRetailerDTO
{
    public Boolean isPercentage { get; set; }
    public double value { get; set; }
    public int productId { get; set; }
    public int retailerId { get; set; }
}