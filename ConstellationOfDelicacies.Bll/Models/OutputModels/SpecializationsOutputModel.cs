namespace ConstellationOfDelicacies.Bll.Models;

public class SpecializationsOutputModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<ProfilesOutputModel> Profiles { get; set; }
}