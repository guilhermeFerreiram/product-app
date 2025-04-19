using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Product.App.Client;
using Product.App.Client.Services.Interfaces;
using Product.App.Client.Services;
using Product.App.Client.RefitServices;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//default HttpClient config
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    });

//Refit config
builder.Services.AddRefitClient<IProductAppBackendRefitService>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    });

//Dependency Injection
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();

