using FormulaOneTech.Components;
using FormulaOneTech.Services.Circuit;
using FormulaOneTech.Services.Ergast;
using FormulaOneTech.Services.OpenF1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<IErgastService, ErgastService>();
builder.Services.AddHttpClient<IErgastService, ErgastService>(client =>
{
    client.BaseAddress = new Uri("https://ergast.com/api/f1/");
});

builder.Services.AddHttpClient<IOpenF1Service, OpenF1Service>(client =>
{
    client.BaseAddress = new Uri("https://api.openf1.org/v1/");
});

builder.Services.AddSingleton<ImageMappingService>();

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
