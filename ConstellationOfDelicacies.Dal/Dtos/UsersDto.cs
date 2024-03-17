namespace ConstellationOfDelicacies.Dal.Dtos;

public class UsersDto
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public bool IsDeleted { get; set; }
}