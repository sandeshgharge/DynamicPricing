using System.ComponentModel.DataAnnotations;

namespace DynamicPricing.Models;

public class Retailer{

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Name { get; set; }
}