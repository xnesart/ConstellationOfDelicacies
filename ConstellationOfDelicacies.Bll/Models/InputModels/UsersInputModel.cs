using System.ComponentModel.DataAnnotations;

namespace ConstellationOfDelicacies.Bll.Models.InputModels;

public class UsersInputModel
{
    public int Id { get; set; }
    public List<ProfilesOutputModel> Profiles { get; set; }
    public List<TasksOutputModel> Task { get; set; }
    public RolesOutputModel Role { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string Mail { get; set; }

    [Required]
    public string Password { get; set; }
    public bool IsDeleted { get; set; }
}