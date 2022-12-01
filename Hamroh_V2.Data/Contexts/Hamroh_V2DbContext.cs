using Hamroh_V2.Domain.Entities.ClientAds;
using Hamroh_V2.Domain.Entities.Clients;
using Hamroh_V2.Domain.Entities.DriverAds;
using Hamroh_V2.Domain.Entities.Drivers;
using Microsoft.EntityFrameworkCore;

namespace Hamroh_V2.Data.Contexts
{
    public class Hamroh_V2DbContext : DbContext
    {
        public Hamroh_V2DbContext(DbContextOptions<Hamroh_V2DbContext> options)
            : base(options)
        {

        }

        public Hamroh_V2DbContext()
        {
            //salom
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAd> ClientAds { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverAd> DriverAds { get; set; }
    }
}
