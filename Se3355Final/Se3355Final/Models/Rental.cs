namespace Se3355Final.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Rental
{
    [Key]
    public int RentalId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("Car")]
    public int CarId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }

    public bool Completed { get; set; }
    
    public virtual User User { get; set; }
    public virtual Car Car { get; set; }
}