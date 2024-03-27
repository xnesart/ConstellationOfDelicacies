using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Bll.Models;

public class TasksOutputModel
{
    public int Id { get; set; }

    public OrdersOutputModel Order { get; set; }

    public string Title { get; set; }

    public bool IsDeleted { get; set; }

    public List<UsersOutputModel> Workers { get; set; }

    public TaskStatusesOutputModel Status { get; set; }

    public List<ProfilesOutputModel> Profiles { get; set; }

}