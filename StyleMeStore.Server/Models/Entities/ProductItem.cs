namespace StyleMeStore.Server.Models.Entities;

public class ProductItem
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Type { get; set; }

    [Required]
    [StringLength(20)]
    public string Size { get; set; }

    [Required]
    [StringLength(50)]
    public string Colour { get; set; }

    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public DateOnly AvailableOn { get; set; }
}