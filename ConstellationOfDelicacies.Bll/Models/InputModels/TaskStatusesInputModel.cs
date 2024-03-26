namespace ConstellationOfDelicacies.Bll.Models.InputModels;

public class TaskStatusesInputModel
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public List<TasksInputModel> Tasks { get; set; }
}