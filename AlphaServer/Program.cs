using AlphaServer.Areas.Identity;
using AlphaServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using BootstrapBlazor;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.UI.Services;
using AlphaServer.Servises;

namespace AlphaServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddDefaultUI() 
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddTransient<EmailService>();

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddHttpContextAccessor();
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //.AddCookie(options =>
            //{
            //    options.LoginPath = new PathString("/Identity/Account/Login");
            //    options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
            //    options.SlidingExpiration = true;
            //});

            builder.Services.AddSession(Options =>
            {
                Options.IdleTimeout = TimeSpan.FromMinutes(15);
                Options.Cookie.HttpOnly = true;
                Options.Cookie.IsEssential = true;
            });
            
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.DisableImplicitFromServicesParameters = true;
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
            //           builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //         options.UseNpgsql(
            //           builder.Configuration.GetConnectionString("DefaultConnection")));
            app.UseHttpsRedirection();
            app.UseDefaultFiles();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            
            app.UseAuthorization();
            app.UseSession();
            app.MapControllers();
            
            app.MapDefaultControllerRoute();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}