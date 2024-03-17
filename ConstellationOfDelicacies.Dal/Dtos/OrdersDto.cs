namespace ConstellationOfDelicacies.Dal.Dtos;

public class OrdersDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsDeleted { get; set; }
    public string Comment { get; set; }
    public string Address { get; set; }
    public int NumberOfPersons { get; set; }
}