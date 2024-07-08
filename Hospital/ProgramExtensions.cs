using FraemworksDrivers;
using FraemworksDrivers.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API.Hospital
{
    public static class ProgramExtensions
    {
        public static WebApplicationBuilder AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            return builder;
        }

        public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<HospitalDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            DependencyInjection.ConfigureServices(builder.Services);
            Core.DependencyInjection.ConfigureServices(builder.Services);
            return builder;
        }

        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }

        public static WebApplicationBuilder AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            return builder;
        }

        public static WebApplicationBuilder AddMvcControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            return builder;
        }

        public static WebApplication ConfigureMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
