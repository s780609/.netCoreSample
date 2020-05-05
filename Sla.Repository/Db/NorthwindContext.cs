using Microsoft.EntityFrameworkCore;
using Sla.Repository.Entities;

namespace Sla.Repository.Db
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public DbSet<Shipper> Shippers { get; set; }
    }
}