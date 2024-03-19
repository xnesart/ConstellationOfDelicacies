namespace ConstellationOfDelicacies.Dal.Dtos;

public class SpecializationsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<ProfilesDto> Profiles { get; set; }
}