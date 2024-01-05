namespace Se3355Final.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8)]
    public string Password { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string City { get; set; }


    public virtual ICollection<Rental> Rentals { get; set; }
}