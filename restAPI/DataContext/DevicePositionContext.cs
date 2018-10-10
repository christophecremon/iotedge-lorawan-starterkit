using DataContracts.Controllers;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Models
{
    public class DevicePositionContext : DbContext
    {
        public DevicePositionContext(DbContextOptions<DevicePositionContext> options)
            : base(options)
        {
        }

        public DbSet<DeviceMapPoint> DevicePositions { get; set; }
    }
}