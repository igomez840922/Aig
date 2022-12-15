using BlazorHero.CleanArchitecture.Client.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args).AddRootComponents();
builder.AddClientServices(builder.Configuration);
await builder.Build().RunAsync();



