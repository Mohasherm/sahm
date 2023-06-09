using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using sahm.Client;
using sahm.Client.Authentication;
using sahm.Client.Extensions;
using sahm.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationHttpClient>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddLocalization();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddScoped<JobTitleService>();
builder.Services.AddScoped<CenterService>();
builder.Services.AddScoped<AssetService>();
builder.Services.AddScoped<CenterAssetService>();
builder.Services.AddScoped<TankService>();
builder.Services.AddScoped<ComplaintService>();


var host = builder.Build();
await host.SetDefaultCulture();

await host.RunAsync();