namespace ConstellationOfDelicacies.Dal.Dtos;

public class RolesDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public ICollection<UsersDto> User { get; set; }
}