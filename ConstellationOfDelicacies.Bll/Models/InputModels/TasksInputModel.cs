namespace ConstellationOfDelicacies.Bll.Models.InputModels;

public class TasksInputModel
{
    public int Id { get; set; }
    public OrderInputModel Order { get; set; }
    public List<ProfilesInputModel> Profiles { get; set; }
    public string Title { get; set; }
    public List<UsersInputModel>? Users { get; set; }
    public TaskStatusesInputModel Status { get; set; }
    public bool IsDeleted { get; set; }
}