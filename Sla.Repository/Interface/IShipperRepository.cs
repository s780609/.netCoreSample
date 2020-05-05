using Sla.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sla.Repository.Interface
{
    public interface IShipperRepository
    {
        Task<int> AddAsync(Shipper entity);

        Task<IEnumerable<Shipper>> GetAsync();

        Task<Shipper> GetAsync(int id);

        Task<int> UpdateAsync(Shipper entity);

        Task<int> DeleteAsync(Shipper entity);
    }
}