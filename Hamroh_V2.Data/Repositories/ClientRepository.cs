using Hamroh_V2.Data.Contexts;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Entities.Clients;

namespace Hamroh_V2.Data.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(Hamroh_V2DbContext dbContext) : base(dbContext)
        {
        }
    }
}
