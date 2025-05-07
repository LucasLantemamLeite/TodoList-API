using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TodoList.Data;
using TodoList.Services.TokenKey;

namespace TodoList.Extension.Configuration;

public partial class Configuration
{
    public static void BuilderConfig(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<TodoListContext>();
        builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenKey.JwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
}