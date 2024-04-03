namespace ConstellationOfDelicacies.Bll.Models.InputModels;

public class AccountEditInputModel
{
    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }
    
    public string? Phone { get; set; }

    public string? Mail { get; set; }
    public string? NewMail { get; set; }
    
    public string? Password { get; set; }
    public string? NewPassword { get; set; }
}