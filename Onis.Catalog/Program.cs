using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Onis.Infrastructure.DB;
using Onis.Infrastructure.Repositories;
using static Onis.Domain.Contracts.IRepository;
using NLog.Web;
using NLog;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    //Beautify this...
    //var constring =builder.Configuration.GetConnectionString("DefaultConnection");
    //builder.Services.AddDbContext<CatalogDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


    builder.Services.AddDbContext<CatalogDBContext>(
     dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("CatalogConnection")));

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API NAME 1.0.0.0"));
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception e)
{
    logger.Error(e, "Program has stopped because of an exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}


