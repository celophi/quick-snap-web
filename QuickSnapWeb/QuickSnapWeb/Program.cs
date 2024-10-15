using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Caching.Memory;
using QuickSnapWeb.Accounts;
using QuickSnapWeb.Configuration;
using QuickSnapWeb.Pictures;

namespace QuickSnapWeb;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddTransient<IAccountsProvider, AccountsProvider>();
        builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
        builder.Services.AddTransient<IAccountsRepository, AccountsRepository>();
        builder.Services.AddTransient<IPictureRepository, PictureRepository>();
        builder.Services.AddTransient<IPictureProvider, PictureProvider>();

        builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection("ApiOptions"));

        await builder.Build().RunAsync();
    }
}
