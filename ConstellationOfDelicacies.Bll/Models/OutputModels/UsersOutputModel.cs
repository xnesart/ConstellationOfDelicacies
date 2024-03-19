namespace ConstellationOfDelicacies.Bll.Models;

public class UsersOutputModel
{
    public int Id { get; set; }
    public List<ProfilesOutputModel> Profiles { get; set; }
    public List<TasksOutputModel> Task { get; set; }
    public RolesOutputModel Role { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public bool IsDeleted { get; set; }
}