using SWGalacticArchives.Components;
using SWGalacticArchives.Models;
using SWGalacticArchives.Services.Implementations;
using SWGalacticArchives.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IVehicleService, VehicleService>(client =>
{
    client.BaseAddress = new Uri("https://www.swapi.tech/api");
});

builder.Services.AddHttpClient<IPlanetService, PlanetService>(client =>
{
    client.BaseAddress = new Uri("https://www.swapi.tech/api");
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddBootstrapBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
