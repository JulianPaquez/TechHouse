using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities;

public abstract class  User 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }   

    public string Username { get; set; }

    public string Password { get; set; }
    
    public string UserType { get; set; }
}