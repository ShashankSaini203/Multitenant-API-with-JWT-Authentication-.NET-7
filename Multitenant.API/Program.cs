using Core.Interfaces;
using Core.Settings;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Infrastructure.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //Added for JWT token - Shashank
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                                ValidAudience = builder.Configuration["Jwt:Audience"],
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                            };
                        });
        builder.Services.AddHttpContextAccessor(); //Added for MultiTenancy - Shashank
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Multitenant.API", Version = "v1" });
        });
        builder.Services.AddTransient<IRepository, RepositoryService>();  //Added for MultiTenancy - Shashank
        builder.Services.AddTransient<ITenantService, TenantService>(); //Added for MultiTenancy - Shashank
        builder.Services.Configure<TenantSetting>(builder.Configuration.GetSection(nameof(TenantSetting))); //Added for MultiTenancy - Shashank
        builder.Services.AddAndMigrateTenantDatabases(builder.Configuration);  //Added for MultiTenancy - Shashank
                                                                               //services.GetOptions<TenantSetting>(nameof(TenantSetting));
                                                                               //services.AddDbContext<ApplicationDbContext>(options =>
                                                                               //options.UseSqlServer("Data Source=.;Initial Catalog=Shared;Integrated Security=True;MultipleActiveResultSets=True"));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Multitenant.API v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthentication();  //Added for JWT token - Shashank
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}