using System.ComponentModel.DataAnnotations;

namespace ConstellationOfDelicacies.Bll.Models.InputModels;

public class UsersInputModel
{
    public int? Id { get; set; }

    [Required]
    public ProfilesInputModel? Profile { get; set; }

    public RolesInputModel? Role { get; set; }

    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; }

    [Required]
    public string? Phone { get; set; }

    [Required]
    public string? Mail { get; set; }

    [Required]
    [MinLength(4)]
    public string? Password { get; set; }

}