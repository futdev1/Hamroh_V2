using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IClientAdRepository ClientAds { get; }

        IClientRepository Clients { get; }

        IDriverAdRepository DriverAds { get; }

        IDriverRepository Drivers { get; }

        Task SaveChangesAsync();
    }
}
