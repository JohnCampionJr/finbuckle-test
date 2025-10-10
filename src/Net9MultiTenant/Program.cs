using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.EntityFrameworkCore.Stores.EFCoreStore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Net9MultiTenant;
using Net9MultiTenant.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("test-fb9"));
builder.Services.AddDbContext<EFCoreStoreDbContext<TenantInfo>>(options => options.UseInMemoryDatabase("test-fb9"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

// add Finbuckle.MultiTenant services
builder.Services.AddMultiTenant<TenantInfo>()
    .WithBasePathStrategy(options => options.RebaseAspNetCorePathBase = true)
    .ShortCircuitWhenTenantNotResolved(new Uri("/notenant", UriKind.Relative))
    .WithEFCoreStore<EFCoreStoreDbContext<TenantInfo>, TenantInfo>()
    .WithPerTenantAuthentication();


var app = builder.Build();

await SeedService.Seed(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// add the Finbuckle.MultiTenant middleware
app.UseMultiTenant();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
