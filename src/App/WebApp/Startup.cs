using DataBase;
using DataBase.Data;
using DataBase.Repositories;
using Entity.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace WebApp;

public class Startup {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {
        services.AddControllers().AddMvcOptions(x =>
            x.SuppressAsyncSuffixInActionNames = false);
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<IDbInitializer, EfDbInitializer>();
        services.AddDbContext<DataContext>(x =>
        {
            var temp = Configuration.GetConnectionString("WebParseDb");
            x.UseNpgsql(temp);
        });
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer) {
        app.UseSwagger();
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }
        else {
            app.UseHsts();
        }

        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        dbInitializer.InitializeDb();
    }
}