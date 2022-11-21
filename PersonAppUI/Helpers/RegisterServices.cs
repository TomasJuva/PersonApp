using PersonAppLibrary.DataAccess;
using PersonAppUI.Services;

namespace PersonAppUI.Helpers;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddLocalization(opts => opts.ResourcesPath = "Resources");
        
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddScoped<IFileService, FileService>();

        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddSingleton<IPersonData, PersonData>();
    }
}
