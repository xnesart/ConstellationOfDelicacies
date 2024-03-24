namespace ConstellationOfDelicacies.Dal.Dtos;

public class ProfilesDto
{
    public int Id { get; set; }
    public SpecializationsDto Specialization { get; set; }
    public string Title { get; set; }
    public  ICollection<UsersDto>? Users { get; set; }
    public  ICollection<TasksDto> Tasks { get; set; }
}