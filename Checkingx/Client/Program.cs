global using Checkingx.Shared;
using Checkingx.Client;
using Checkingx.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProjectServiceClient, ProjectServiceClient>();
builder.Services.AddScoped<ICheckItemServiceClient, CheckItemServiceClient>();
builder.Services.AddScoped<ICheckingServiceClient, CheckingServiceClient>();

await builder.Build().RunAsync();
