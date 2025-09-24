using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.EntityFrameworkCore.Stores.EFCoreStore;
using Microsoft.EntityFrameworkCore;

namespace Net9MultiTenant.Data
{
    public class MultiTenantStoreDbContext : EFCoreStoreDbContext<TenantInfo>
    {
        public MultiTenantStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use InMemory, but could be MsSql, Sqlite, MySql, etc...
            //optionsBuilder.UseMongoDB("mongodb://localhost/fb9-tenant-store");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
