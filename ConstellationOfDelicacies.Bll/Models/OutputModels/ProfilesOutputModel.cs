namespace ConstellationOfDelicacies.Bll.Models;

public class ProfilesOutputModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal CostPerDay { get; set; }
    public ICollection<UsersOutputModel> Workers { get; set; }
    public ICollection<TasksOutputModel> Tasks { get; set; }
    public SpecializationsOutputModel Specialization { get; set; }
}