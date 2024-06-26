namespace DynamicPricing.DTO;

/// <summary>
/// DTO Object of product model
/// </summary>
public class ProductDTO{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int GroupId { get; set; }
    public double MRP { get; set;}
}