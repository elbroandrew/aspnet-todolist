using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models;

public class Product
{
    [Key]
    public long Id { get; set; }
    public required string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}