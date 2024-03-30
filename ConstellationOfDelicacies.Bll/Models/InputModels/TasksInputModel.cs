using System.ComponentModel.DataAnnotations;

namespace ConstellationOfDelicacies.Bll.Models.InputModels;

public class TasksInputModel
{
    public int? Id { get; set; }

    [Required]
    public int? SpId { get; set; }

    [Required]
    public int? PrId { get; set; }

    public int? WorkerId { get; set; } 

    public OrderInputModel Order { get; set; }

    public List<ProfilesInputModel> Profiles { get; set; }

    [Required]
    public string Title { get; set; }

    public List<UsersInputModel>? Users { get; set; }

    public TaskStatusesInputModel Status { get; set; }

    public bool IsDeleted { get; set; }
}