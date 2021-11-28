using IdentityCore.Context;
using IdentityCore.CustomValidator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
         
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>();

            services.AddIdentity<AppUser, AppRole>(opt=> {
                //Þifre zorunluluklarý kaldýrýlýyor. Büyük küçük harf sayý özel karakter vb. 
                //opt.Password.RequireDigit = false;
                //opt.Password.RequireLowercase = false;
                //opt.Password.RequiredLength = 1;
                //opt.Password.RequireNonAlphanumeric = false;
                //opt.Password.RequireUppercase = false;
                //opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                //opt.Lockout.MaxFailedAccessAttempts = 3; 
            }).AddPasswordValidator<CustomPasswordValidator>() 
            .AddErrorDescriber<CustomIdentityValidator>()
            .AddEntityFrameworkStores<IdentityContext>();
            services.ConfigureApplicationCookie(opt=> {
                opt.Cookie.HttpOnly = true; 
                opt.Cookie.Name = "CookieIdendity";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            });
            services.AddRazorPages();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles(); 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
