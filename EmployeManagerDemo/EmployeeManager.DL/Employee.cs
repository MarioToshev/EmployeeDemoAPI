using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmoloyeeManager.DL;

public class Employee
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [Key]
    [EmailAddress]
    public string Email { get; set; }
}