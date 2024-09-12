using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SampleProductManagementApp.Data;
using SampleProductManagementApp.Services;

namespace SampleProductManagementApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Add Identity with Roles
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IProductServices, ProductServices>();

            // Set Policy for Page Protection
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy =>
                    policy.RequireRole("Administrator").Build()
                    );
            });

            // Protect Pages
            builder.Services.AddRazorPages( options =>
            {
                options.Conventions.AuthorizePage("/Index");
                options.Conventions.AuthorizeFolder("/ProductPages");
                options.Conventions.AuthorizePage("/ProductPages/Edit", "admin");
                options.Conventions.AuthorizePage("/ProductPages/Create", "admin");
                options.Conventions.AuthorizePage("/ProductPages/Delete", "admin");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllers();

            app.Run();
        }
    }
}
