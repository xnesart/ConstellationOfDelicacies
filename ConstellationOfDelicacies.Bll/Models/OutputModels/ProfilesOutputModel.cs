namespace ConstellationOfDelicacies.Bll.Models;

public class ProfilesOutputModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal CostPerDay { get; set; }
    public List<UsersOutputModel> Workers { get; set; }  
    public List<TasksOutputModel> Tasks { get; set; }
    public SpecializationsOutputModel Specialization { get; set; }
}