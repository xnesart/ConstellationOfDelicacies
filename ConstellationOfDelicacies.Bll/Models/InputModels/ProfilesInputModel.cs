namespace ConstellationOfDelicacies.Bll.Models.InputModels;

public class ProfilesInputModel
{
    public int? Id { get; set; }
    public SpecializationInputModel Specialization{ get; set; }
    public string? Title { get; set; }
}