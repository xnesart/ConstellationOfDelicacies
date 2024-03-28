namespace ConstellationOfDelicacies.Bll.Models;

public class OrdersOutputModel
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsDeleted { get; set; }

    public string Comment { get; set; }

    public string Address { get; set; }

    public int NumberOfPersons { get; set; }

    public List<TasksOutputModel> Tasks { get; set; }

    public decimal TotalPrice { get; set; }
}