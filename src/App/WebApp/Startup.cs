using DataBase;
using DataBase.Data;
using DataBase.Repositories;
using Entity.Abstraction;
using Microsoft.EntityFrameworkCore;

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
            x.UseNpgsql(Configuration.GetConnectionString("WebParseDb"));
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer) {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }
        else {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        dbInitializer.InitializeDb();
    }
}