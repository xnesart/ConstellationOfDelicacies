using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstellationOfDelicacies.Bll.Models
{
    public class OrderInputModel
    {
        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public string? Comment { get; set; }

        public string? Address { get; set; }

        public int NumberOfPersons { get; set; }

    }
}
