using Course.Web.Models;
using Course.Web.Services;
using Course.Web.Services.Interfaces;

namespace Course.Web.Extension;

public static class ServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
    {
        var serviceApiSettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        // services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
        services.AddHttpClient<IIdentityService, IdentityService>();
    }
}
