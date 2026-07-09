using Autofac;
using Autofac.Extensions.DependencyInjection;
using Cortex.Mediator.DependencyInjection;
using DevSkill.Shop.Application.Features.Categories.Command;
using DevSkill.Shop.Infrastructure.Data;
using DevSkill.Shop.Infrastructure.Extensions;
using DevSkill.Shop.Web;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/web-log-.log", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var migrationAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));

    #region Dependency Injection

    builder.Services.AddInfrastructureDependency();

    #endregion

    #region serilog Configuration

    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(context.Configuration)
    );

    #endregion

    #region Autofac Configuration

    //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    //builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    //{
    //    containerBuilder.RegisterModule(new WebModule(connectionString));
    //});

    #endregion

    #region Cortex Mediator Configuration

    builder.Services.AddCortexMediator(
        new[] {typeof(Program), typeof(CategoryAddCommand)},
        options => options.AddDefaultBehaviors()
        );

    #endregion

    #region Mapster Configuration

    //Custom Configuration for Mapster
    var config = TypeAdapterConfig.GlobalSettings;
    config.Scan(typeof(MapsterConfiguration).Assembly);
    builder.Services.AddSingleton(config);
    builder.Services.AddScoped<IMapper, ServiceMapper>();

    #endregion

    #region DbContext Configuration

    builder.Services.AddDbContext(connectionString, migrationAssembly);

    #endregion

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();

    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "area",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.MapRazorPages()
       .WithStaticAssets();

    Log.Information("Starting application");

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "application crashed");
}
finally
{
    Log.CloseAndFlush();
}