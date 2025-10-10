using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net9MultiTenant.Data;
using Net9MultiTenant.Models;

namespace Net9MultiTenant.Pages
{    
    public class NoTenantModel(ILogger<IndexModel> logger) : PageModel
    {
        public async Task OnGet()
        {

        }
    }
}
