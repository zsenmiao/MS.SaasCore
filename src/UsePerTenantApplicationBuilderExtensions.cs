using Microsoft.AspNetCore.Builder;
using MS.SaasCore.Internal;
using System;

namespace MS.SaasCore
{
    public static class UsePerTenantApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePerTenant<TTenant>(this IApplicationBuilder app, Action<TenantPipelineBuilderContext<TTenant>, IApplicationBuilder> configuration)
        {
            Ensure.Argument.NotNull(app, nameof(app));
            Ensure.Argument.NotNull(configuration, nameof(configuration));

            app.Use(next => new TenantPipelineMiddleware<TTenant>(next, app, configuration).Invoke);
            return app;
        }
    }
}
