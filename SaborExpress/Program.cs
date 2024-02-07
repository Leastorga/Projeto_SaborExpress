using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SaborExpress.Context;
using SaborExpress.Models;
using SaborExpress.Repositories.Interfaces;
using SaborExpress.Repositories;
using SaborExpress.Services;
using SaborExpress.Areas.Admin.Services;

var builder = WebApplication.CreateBuilder(args);

//ConfigureServices
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(connection));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<ConfigurationImages>(builder.Configuration.GetSection("ConfigurationFolderImage"));

builder.Services.AddTransient<ISnackRepository, SnackRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
builder.Services.AddScoped<SalesServiceReport>();
builder.Services.AddScoped<SalesServiceChart>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
        politica =>
        {
            politica.RequireRole("Admin");
        });
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShoppingCart.GetCart(sp));

builder.Services.AddControllersWithViews();

builder.Services.AddPaging(options =>
{
    options.ViewName = "Bootstrap4";
    options.PageParameterName = "pageindex";
});

builder.Services.AddMemoryCache();
builder.Services.AddSession();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

CreateUserProfiles(app);

////cria os perfis
//seedUserRoleInitial.SeedRoles();
////cria os usuários e atribui ao perfil
//seedUserRoleInitial.SeedUsers();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
       name: "categoryFilter",
       pattern: "Snack/{action}/{category?}",
       defaults: new { Controller = "Snack", action = "List" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

void CreateUserProfiles(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        service.SeedUsers();
        service.SeedRoles();
    }
}