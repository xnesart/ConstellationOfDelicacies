namespace ConstellationOfDelicacies.Bll.Models;

public class UsersOutputModel
{
    public int Id { get; set; }
    public ICollection<ProfilesOutputModel> Profiles { get; set; }
    public ICollection<TasksOutputModel> Task { get; set; }
    public RolesOutputModel Role { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
}