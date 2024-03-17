namespace ConstellationOfDelicacies.Dal.Dtos;

public class OrdersDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsDeleted { get; set; }
}