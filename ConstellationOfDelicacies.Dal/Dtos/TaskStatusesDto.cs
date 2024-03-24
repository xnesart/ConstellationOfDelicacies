namespace ConstellationOfDelicacies.Dal.Dtos;

public class TaskStatusesDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<TasksDto> Tasks { get; set; }
}