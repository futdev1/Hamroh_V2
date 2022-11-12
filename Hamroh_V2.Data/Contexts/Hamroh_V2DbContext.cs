using Hamroh_V2.Domain.Entities.Clients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        public virtual DbSet<Client> Clients { get; set; }
    }
}
