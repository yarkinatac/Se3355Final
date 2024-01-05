namespace Se3355Final.Models;

using System.ComponentModel.DataAnnotations;

public class Office
{
    [Key]
    public int OfficeId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string City { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public double Latitude { get; set; }

    [Required]
    public double Longitude { get; set; }
}