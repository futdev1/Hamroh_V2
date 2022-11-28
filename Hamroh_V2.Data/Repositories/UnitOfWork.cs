using Hamroh_V2.Data.Contexts;
using Hamroh_V2.Data.IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Hamroh_V2.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Hamroh_V2DbContext dbContext;
        private readonly IConfiguration config;

        //Repositories
        public IClientAdRepository ClientAds { get; private set; }

        public IClientRepository Clients { get; private set; }

        public IDriverAdRepository DriverAds { get; private set; }

        public IDriverRepository Drivers { get; private set; }

        public UnitOfWork(Hamroh_V2DbContext dbContext, IConfiguration config)
        {
            this.dbContext = dbContext;
            this.config = config;

            Clients = new ClientRepository(dbContext);
            ClientAds = new ClientAdRepository(dbContext);
            Drivers = new DriverRepository(dbContext);
            DriverAds = new DriverAdRepository(dbContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
