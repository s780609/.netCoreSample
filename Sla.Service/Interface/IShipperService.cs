using Sla.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sla.Service.Interface
{
    public interface IShipperService
    {
        Task<int> AddAsync(ShipperDto dto);

        Task<IEnumerable<ShipperDto>> GetAsync();

        Task<ShipperDto> GetAsync(int id);

        Task<int> UpdateAsync(ShipperDto dto);

        Task<int> DeleteAsync(int id);
    }
}