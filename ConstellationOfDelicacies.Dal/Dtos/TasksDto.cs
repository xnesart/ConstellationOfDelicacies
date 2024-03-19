namespace ConstellationOfDelicacies.Dal.Dtos;

public class TasksDto
{
    public int Id { get; set; }
    public OrdersDto Order { get; set; }
    public List<ProfilesDto> Profiles { get; set; }
    public string Title { get; set; }
    public List<UsersDto>? Workers { get; set; }
    public TaskStatusesDto Status { get; set; }
    public bool IsDeleted { get; set; }
}