using System.ComponentModel.DataAnnotations;

namespace ConstellationOfDelicacies.Bll.Models.InputModels;

public class RegistrationInputModel
{
    
    [Required]
    public string Name { get; set; }
    [Required]
    public string MiddleName { get; set; }
    
    public string LastName { get; set; }
    
    [Required]
    public string Email { get; set; }
    public string Phone { get; set; }

    [Required]
    public string Password { get; set; }
    
    public RolesInputModel Role { get; set; }
}