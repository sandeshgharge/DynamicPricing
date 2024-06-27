using System.ComponentModel.DataAnnotations;

namespace DynamicPricing.Models;

/// <summary>
/// Represents a product entity.
/// </summary>
public class Product{

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }

    public int GroupId { get; set; }
    public double MRP { get; set;}
}