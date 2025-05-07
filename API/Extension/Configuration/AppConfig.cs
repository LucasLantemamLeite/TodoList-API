namespace TodoList.Extension.Configuration;

public partial class Configuration
{
    public static void AppConfig(WebApplication app)
    {
        app.MapControllers();
    }
}