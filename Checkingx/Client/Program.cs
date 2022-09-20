global using Checkingx.Shared;
using Checkingx.Client;
using Checkingx.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Sotsera.Blazor.Toaster.Core.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();
builder.Services.AddToaster(config =>
{
    config.PositionClass = Defaults.Classes.Position.BottomRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = false;
});
builder.Services.AddScoped<IProjectServiceClient, ProjectServiceClient>();
builder.Services.AddScoped<ICheckItemServiceClient, CheckItemServiceClient>();
builder.Services.AddScoped<ICheckingServiceClient, CheckingServiceClient>();

await builder.Build().RunAsync();
