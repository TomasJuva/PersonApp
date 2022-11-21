using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PersonAppUI.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureServices();

var app = builder.Build();


RequestLocalizationOptions GetLocalizationOptions()
{
    var cultures = builder!.Configuration.GetSection("Cultures").GetChildren().ToDictionary(x => x.Key, x => x.Value);
    var supportedCultures = cultures.Keys.ToArray();
    var localizationOptions = new RequestLocalizationOptions()
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
    return localizationOptions;
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRequestLocalization(GetLocalizationOptions());

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
