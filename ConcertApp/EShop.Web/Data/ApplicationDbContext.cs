using ConcertApp.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ConcertAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConcertTicket> ConcertTickets { get; set; }
        public virtual DbSet<Concert> Concerts { get; set; }

    }
}
