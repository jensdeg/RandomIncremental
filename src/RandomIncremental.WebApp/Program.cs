using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RandomIncremental;
using RandomIncremental.WebApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<Game>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<Game>().GameStats);

var app = builder.Build();

var game = app.Services.GetRequiredService<Game>();
game.GameStats.TickRate = 8;
game.Start();

await app.RunAsync();
