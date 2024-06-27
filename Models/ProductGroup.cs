using System.ComponentModel.DataAnnotations;

namespace DynamicPricing.Models;

/// <summary>
/// Repersents a Product Group Entity
/// </summary>
public class ProductGroup{

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }
}