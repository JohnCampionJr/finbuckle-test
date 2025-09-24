using System.Reflection.Emit;
using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Abstractions;
using Finbuckle.MultiTenant.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Net9MultiTenant.Models;

namespace Net9MultiTenant.Data
{
    public class ApplicationDbContext : MultiTenantIdentityDbContext
    {

        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ApplicationDbContext(IMultiTenantContextAccessor multiTenantContextAccessor, IHttpContextAccessor http, DbContextOptions<ApplicationDbContext> options)
            : base(multiTenantContextAccessor, options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // If necessary call the base class method.
            // Recommended to be called first.
            base.OnModelCreating(builder);

            builder.Entity<ToDoItem>().IsMultiTenant();

        }

    }
}
