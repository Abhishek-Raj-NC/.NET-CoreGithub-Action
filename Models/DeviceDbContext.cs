using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Device_Migration_Admin_Portal.Models
{
    public class DeviceDbContext : DbContext
    {
        public DeviceDbContext(DbContextOptions<DeviceDbContext> options) : base(options) { }

        public DbSet<DeviceMigration> DeviceMigration { get; set; }
    }
}
