using System.ComponentModel.DataAnnotations;

namespace ConstellationOfDelicacies.Bll.Models.InputModels
{
    public class LoginInputModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
