using Microsoft.EntityFrameworkCore;
using Talabat.APIs.Extensions;
using Talabat.APIs.Middlewares;
using Talabat.Repository.Data;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(
                connectionstring,
                b => b.MigrationsAssembly(typeof(StoreContext).Assembly.FullName));


            });

            builder.Services.AddApplicationService();




            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwggerExtensions();

            var app = builder.Build();


            using var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var _dbContext = service.GetRequiredService<StoreContext>();
            var LoggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync();
                await StoreDataSeed.DataSeedAsync(_dbContext);

            }
            catch (Exception ex)
            {
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "The Error Occured when the applying Migration");

            }


            #region configure Kestral Midddleware

            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddleware();

            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();

            //app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();
            #endregion


            app.Run();
        }
    }
}
