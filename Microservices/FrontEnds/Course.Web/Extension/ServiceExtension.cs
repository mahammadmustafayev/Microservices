using Course.Web.Handler;
using Course.Web.Models;
using Course.Web.Services;
using Course.Web.Services.Interfaces;

namespace Course.Web.Extension;

public static class ServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
    {
        var serviceApiSettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
        services.AddHttpClient<IIdentityService, IdentityService>();

        services.AddHttpClient<ICatalogService, CatalogService>(opt =>

        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Catalog.Path}");

        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IPhotoStockService, PhotoStockService>(opt =>

        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.PhotoStock.Path}");
            var test = opt.BaseAddress;
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IUserService, UserService>(opt =>
        {
            opt.BaseAddress = new Uri(serviceApiSettings.IdentityBaseUri);
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IBasketService, BasketService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Basket.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

    }
}
