using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Startup {
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>();
    }
    public Startup(IHostingEnvironment env) {
        using(var client = new ApplicationDbContext()) {
            client.Database.EnsureCreated();
        }
    }
}