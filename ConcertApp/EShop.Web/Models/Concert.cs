using System.ComponentModel.DataAnnotations;

namespace ConcertApp.Web.Models
{
    public class Concert
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ConcertName { get; set; }
        [Required]
        public string ConcertDate { get; set; }
        [Required]
        public string ConcertImage { get; set; }
        [Required]
        public double ConcertPrice { get; set; }
        [Required]
        public string ConcertPlace { get; set; }
        public virtual ICollection<ConcertTicket>? AllTicketsForMyConcert { get; set; }
    }
}
