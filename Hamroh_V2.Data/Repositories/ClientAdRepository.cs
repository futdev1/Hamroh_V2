using Hamroh_V2.Data.Contexts;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Entities.ClientAds;

namespace Hamroh_V2.Data.Repositories
{
    public class ClientAdRepository : GenericRepository<ClientAd>, IClientAdRepository
    {
        public ClientAdRepository(Hamroh_V2DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
