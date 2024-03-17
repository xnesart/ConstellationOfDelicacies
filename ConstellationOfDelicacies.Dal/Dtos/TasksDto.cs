namespace ConstellationOfDelicacies.Dal.Dtos;

public class TasksDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Title { get; set; }
    public int WorkerId { get; set; }
    public int ProfileId { get; set; }
    public int StatusId { get; set; }
}