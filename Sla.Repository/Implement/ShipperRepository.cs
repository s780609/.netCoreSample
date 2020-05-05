using Microsoft.EntityFrameworkCore;
using Sla.Repository.Db;
using Sla.Repository.Entities;
using Sla.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sla.Repository.Implement
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly NorthwindContext _context;

        public ShipperRepository(NorthwindContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">Shipper</param>
        /// <returns>異動筆樹</returns>
        public async Task<int> AddAsync(Shipper entity)
        {
            this._context.Set<Shipper>().Add(entity);
            var count = await this._context.SaveChangesAsync();

            return count;
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="entity">Shipper</param>
        /// <returns>異動筆樹</returns>
        public async Task<int> DeleteAsync(Shipper entity)
        {
            this._context.Set<Shipper>().Remove(entity);
            var count = await this._context.SaveChangesAsync();

            return count;
        }

        /// <summary>
        /// 取得所有Shipper
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Shipper>> GetAsync()
        {
            var shippers = await this._context.Set<Shipper>().ToListAsync();

            return shippers;
        }

        /// <summary>
        /// 取得一筆Shipper
        /// </summary>
        /// <param name="id">ShipperID</param>
        /// <returns>Shipper</returns>
        public async Task<Shipper> GetAsync(int id)
        {
            var shipper = await this._context.Set<Shipper>().FindAsync(id);

            return shipper;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">Shipper</param>
        /// <returns>異動筆數</returns>
        public async Task<int> UpdateAsync(Shipper entity)
        {
            this._context.Set<Shipper>().Update(entity);
            var count = await this._context.SaveChangesAsync();

            return count;
        }
    }
}