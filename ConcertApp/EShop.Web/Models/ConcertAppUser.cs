using Microsoft.AspNetCore.Identity;

namespace ConcertApp.Web.Models
{
    public class ConcertAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<ConcertTicket>? MyTickets { get; set; }
    }
}
