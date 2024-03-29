using System.ComponentModel.DataAnnotations;

namespace ConcertApp.Web.Models
{
    public class ConcertTicket
    {
        [Key]
        public Guid Id { get; set; }
        public int NumberOfPeople { get; set; }
        public virtual ConcertAppUser CreatedBy { get; set; }
        public Guid ConcertId { get; set; }
        public virtual Concert TicketForConcert { get; set; }
    }
}
