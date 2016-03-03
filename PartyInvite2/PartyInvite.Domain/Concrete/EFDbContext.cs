using System.Data.Entity;
using PartyInvite.Domain.Entities;

namespace PartyInvite.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<GuestResponse> GuestResponses { get; set; }
    }
}

