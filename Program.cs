using TodoList.Extension.Configuration;

var builder = WebApplication.CreateBuilder(args);

Configuration.BuilderConfig(builder);

var app = builder.Build();

app.Run();
