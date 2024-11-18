using System.ComponentModel.DataAnnotations;

namespace Markoubeh.Models
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }

        [Required]
        public Guid carId {  get; set; }

        [Required]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime endDate { get; set; }
    }
}
