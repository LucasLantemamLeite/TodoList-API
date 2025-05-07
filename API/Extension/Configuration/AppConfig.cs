using TodoList.Services.TokenKey;

namespace TodoList.Extension.Configuration;

public partial class Configuration
{
    public static void AppConfig(WebApplication app)
    {
        app.MapControllers();
        TokenKey.JwtKey = app.Configuration.GetValue<string>("JwtKey");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.UseAuthorization();
    }
}