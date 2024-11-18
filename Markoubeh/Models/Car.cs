using System.ComponentModel.DataAnnotations;

namespace Markoubeh.Models
{
    public class Car
    {
        public Guid carId { get; set; }

        [Required]
        public string manufacture { get; set; }

        [Required]
        public string model { get; set; }

        [Required]
        public int year { get; set; }

        [Required]
        public string color { get; set; }

        [Required]
        public double price { get; set; } //per day

        public bool available { get; set; } = true;

        [Required]
        public string imgURL { get; set; }

        public string? description { get; set; }
    }
}
