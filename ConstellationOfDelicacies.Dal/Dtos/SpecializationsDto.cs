namespace ConstellationOfDelicacies.Dal.Dtos;

public class SpecializationsDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public ICollection<ProfilesDto> Profiles { get; set; }
}