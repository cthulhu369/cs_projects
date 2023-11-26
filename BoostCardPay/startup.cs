using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Startup {
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public Startup(IHostingEnvironment env) {
        using(var client = new ApplicationDbContext()) {
            client.Database.EnsureCreated();
        }
    }
}