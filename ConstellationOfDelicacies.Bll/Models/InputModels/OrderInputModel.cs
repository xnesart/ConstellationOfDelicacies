using System.ComponentModel.DataAnnotations;

namespace ConstellationOfDelicacies.Bll.Models.InputModels
{
    public class OrderInputModel
    {
        public int? Id { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public DateOnly OrderDateOnly { get; set; }

        [Required]
        public TimeOnly OrderTimeOnly { get; set; }

        [Required]
        [StringLength(255)]
        public string? Comment { get; set; }

        [Required]
        [StringLength(255)]
        public string? Address { get; set; }

        [Range(1, 1000)]
        public int NumberOfPersons { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
