using TodoList.Data;

namespace TodoList.Extension.Configuration;

public partial class Configuration
{

    public static void BuilderConfig(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<TodoListContext>();
    }

}