using FalkenbergsRevyn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FalkenbergsRevyn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure the database context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            // Razor pages
            builder.Services.AddRazorPages();

            // Configure Identity and add roles
            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>() // L�gg till roller i Identity
                .AddEntityFrameworkStores<AppDbContext>();


            var app = builder.Build();

            // Seed roles and admin user at startup
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                IdentitySeeder.SeedRolesAndAdminUser(services).Wait();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //Test

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Redirect root to login page
            app.MapGet("/", async context =>
            {
                context.Response.Redirect("/Identity/Account/Login");
            });

            // MVC routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Ensure Razor Pages are mapped
            app.MapRazorPages();

            app.Run();
        }
    }
}
