namespace ConstellationOfDelicacies.Dal.Dtos;

public class ProfilesDto
{
    public int Id { get; set; }
    public SpecializationsDto Specialization { get; set; }
    public string Title { get; set; }
    public List<UsersDto> Workers { get; set; }
    public decimal CostPerDay { get; set; }
    public List<TasksDto> Tasks { get; set; }
}