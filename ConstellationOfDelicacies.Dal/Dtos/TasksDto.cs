namespace ConstellationOfDelicacies.Dal.Dtos;

public class TasksDto
{
    public int Id { get; set; }
    public OrdersDto Order { get; set; }
    public ICollection<ProfilesDto> Profiles { get; set; }
    public string Title { get; set; }
    public ICollection<UsersDto>? Users { get; set; }
    public TaskStatusesDto Status { get; set; }
    public bool IsDeleted { get; set; }
}