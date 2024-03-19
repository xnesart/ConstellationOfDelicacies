namespace ConstellationOfDelicacies.Bll.Models;

public class WorkerOutputModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RoleId { get; set; }
    public int SubRoleId { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
}