using System.Collections.Generic;
using System.Globalization;
using System.Reflection; 
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Syriatech.Application.Events.Queries.GetEvent;
using Syriatech.Application.Infrastructure;
using Syriatech.Application.Infrastructure.AutoMapper;
using Syriatech.Application.Interfaces;
using Syriatech.Domain.Entities;
using Syriatech.Persistence;
using Syriatech.WebUI.Services;

namespace Syriatech.WebUI
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
            services.Configure<CookiePolicyOptions>(options =>
            { 
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            services.AddMediatR(typeof(GetEventQueryHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);


            services.AddDbContext<ISyriatechDbContext, SyriatechDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SyriatechDatabase")));
            services.AddDbContext<SyriatechDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SyriatechDatabase")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SyriatechDbContext>()
                .AddDefaultTokenProviders(); 
            services.AddLocalization(options => options.ResourcesPath = "Resources"); 
            services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization().SetCompatibilityVersion(CompatibilityVersion.Version_2_2); 
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en"),
                        new CultureInfo("ar")
                    };

                options.DefaultRequestCulture = new RequestCulture("ar");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            }); 
        }
         
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                 app.UseHsts();
            } 
            var supportedCultures = new[]
{
               new CultureInfo("en"),
               new CultureInfo("ar"),
            }; 
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ar"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles(); 
            app.UseAuthentication();
            app.UseMvc(routes =>
            { 
                routes.MapRoute(
                   name: "myprofile",
                   template: "{id}",
                   defaults: new { controller = "Profile", action = "Index" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
