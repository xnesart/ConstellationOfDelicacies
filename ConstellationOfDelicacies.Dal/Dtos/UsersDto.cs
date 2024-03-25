namespace ConstellationOfDelicacies.Dal.Dtos;

public class UsersDto
{
    public int Id { get; set; }

    public ICollection<ProfilesDto> Profiles { get; set; }

    public ICollection<TasksDto> Tasks { get; set; }

    public RolesDto Role { get; set; }

    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string LastName { get; set; }

    public string? Phone { get; set; }

    public string Mail { get; set; }

    public string Password { get; set; }

    public bool IsDeleted { get; set; }
}