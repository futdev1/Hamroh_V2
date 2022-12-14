using Hamroh_V2.Data.Contexts;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Entities.DriverAds;

namespace Hamroh_V2.Data.Repositories
{
    public class DriverAdRepository : GenericRepository<DriverAd>, IDriverAdRepository
    {
        public DriverAdRepository(Hamroh_V2DbContext dbContext) : base(dbContext)
        {
        }
    }
}
