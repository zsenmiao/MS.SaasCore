using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MS.SaasCore
{
    public interface ITenantResolver<TTenant>
    {
        Task<TenantContext<TTenant>> ResolveAsync(HttpContext context);
    }
}