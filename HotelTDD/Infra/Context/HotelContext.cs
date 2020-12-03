using HotelTDD.Domain;
using HotelTDD.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HotelTDD.Infra.Context
{
    public class HotelContext : DbContext
    {
        public DbSet<Clients> Client { get; set; }
        public DbSet<Occupations> Occupation { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<TypeRooms> TypeRoom { get; set; }
        public DbSet<Users> User { get; set; }
        public HotelContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new OccupationConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new TypeRoomConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
