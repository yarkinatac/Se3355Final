namespace Se3355Final.Models;

using System.ComponentModel.DataAnnotations;

public class Car
{
    [Key]
    public int CarId { get; set; }

    [Required]
    public string Make { get; set; }

    [Required]
    public string Model { get; set; }

    [Required]
    public string Transmission { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Mileage { get; set; }

    [Required]
    public decimal Deposit { get; set; }

    [Required]
    public int Age { get; set; }

    public string imageUrl { get; set; }


    public virtual ICollection<Rental> Rentals { get; set; }
}
