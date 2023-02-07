using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudBlazor;
using UiT.Blazor.Ordsky;
using UiT.Components.DI;
using UiT.Blazor.Ordsky.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Egendefinert Config, strongly typed
// builder.Services.Configure<MyConfiguration>(options => builder.Configuration.GetSection("MyConfig").Bind(options));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// Koble opp custom komponenter
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.MaxDisplayedSnackbars = 10;
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 3500;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddScoped<MyUIManager>(); // UiT UI
builder.Services.AddScoped<MyOrdsky>();



await builder.Build().RunAsync();
