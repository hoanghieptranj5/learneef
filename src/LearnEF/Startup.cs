using System.Reflection;
using LearnEF.Logics.Abstractions;
using LearnEF.Logics.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories.DAL.UnitOfWork;
using Repositories.Models;
using Repositories.StoredProcedures;

namespace LearnEF;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo() {Title = "Customer API"});
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            swagger.IncludeXmlComments(xmlPath);
        });
        
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

        services.AddDbContext<NorthwindContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("Northwind"), serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableDetailedErrors());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IEmployeeLogic, EmployeeLogic>();

        services.AddScoped<CustOrderHistSP>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        
        app.UseSwagger(c =>
        {
            c.RouteTemplate = "swagger/{documentName}/swagger.json";
        });
        
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("v1/swagger.json", "Customer API V1");
            c.RoutePrefix = "swagger";
        });

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/",
                async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
        });
    }
}