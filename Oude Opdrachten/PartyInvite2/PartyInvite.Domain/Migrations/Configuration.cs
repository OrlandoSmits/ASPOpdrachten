using PartyInvite.Domain.Entities;

namespace PartyInvite.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Concrete.EFDbContext context)
        {
            context.GuestResponses.AddOrUpdate(
                new GuestResponse
                {
                    Email = "jochem@gmail.com",
                    Name = "jochem",
                    Phone = "1",
                    WillAttend = true,
                },
                new GuestResponse
                {
                    Email = "piet@gmail.com",
                    Name = "piet",
                    Phone = "2",
                    WillAttend = true,
                },
                new GuestResponse
                {
                    Email = "jan@gmail.com",
                    Name = "jan",
                    Phone = "3",
                    WillAttend = false,
                },
                new GuestResponse
                {
                    Email = "katja@gmail.com",
                    Name = "katja",
                    Phone = "4",
                    WillAttend = true,
                },
                new GuestResponse
                {
                    Email = "laura@gmail.com",
                    Name = "laura",
                    Phone = "5",
                    WillAttend = true,
                });
        }
    }
}
