using System.ComponentModel.DataAnnotations;

namespace ConstellationOfDelicacies.Bll.Models.InputModels;

public class RegistrationInputModel
{
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string MiddleName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    public string Email { get; set; }

    public string Phone { get; set; }

    [Required]
    [MinLength(4)]
    public string Password { get; set; }
    
    public RolesInputModel Role { get; set; }
}