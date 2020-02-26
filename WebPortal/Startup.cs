using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portal.Infrastructure.DAL.DatabaseContext;
using Portal.Domain.IdentityModels;
using Portal.Infrastructure.DAL.DefaultDataConfiguration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Portal.Infrastructure.Security.IdentityEnhancedHasher;
using Portal.Domain.Interfaces.System;
using Portal.Infrastructure.Services.Network;
using Portal.ApplicationCore.Services.SessionService;
using AutoMapper;
using Portal.Infrastructure.AutoMapperProfiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebPortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // <<************** Configure Application Database Context Here  **************>>
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            // <<************** Set Default Identity  **************>>
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // <<************** Configure Identity Options Here  **************>>
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //options.Lockout.MaxFailedAccessAttempts = 5;
                //options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            // <<************** Configure Identity User Password Encryption Method Here **************>>
            services.Replace(new ServiceDescriptor(
               serviceType: typeof(IPasswordHasher<AppUser>),
               implementationType: typeof(Md5PasswordHasher<AppUser>),
               ServiceLifetime.Scoped));

            // <<************** Configure System Email Sender Here  **************>>
            services.AddTransient<IExtendedEmailSender, EmailSender>(i =>
                new EmailSender(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:UserName"],
                    Configuration["EmailSender:Password"]
                    )
            );


            services.AddIdentityServer()
                .AddApiAuthorization<AppUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllers();

            services.AddControllersWithViews();
            services.AddRazorPages();

            // <<************** register IHttpContextAccessor  **************>>
            services.AddHttpContextAccessor();
            services.AddScoped<SessionManager>();

            // <<************** Configure Auto mapper profiles  **************>>
            services.AddAutoMapper(typeof(MapperProfiles));


            // <<************** Configure MVC Core Version Here **************>>
            // Started as ASP.Net  Core 3.1 on 2020-02-01
            services.AddMvc(options => {

                //**************Add General Policy *********************
                //User need to be a Authorized system user to access pages except allowAnonymous annotation
                var generalPolicy = new AuthorizationPolicyBuilder()
                                           .RequireAuthenticatedUser()
                                           .Build();
                options.Filters.Add(new AuthorizeFilter(generalPolicy));
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());


            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            // <<************** Set Session configuration Here **************>>
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            //Configure ApplicationCookie
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                //options.LoginPath = "/authentication/login"; //Login path (if user is not logged in)
                //options.LogoutPath = "/authentication/logout";
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();


            //Seeding the Database with concrete values.
            DatabaseSeeder.SeedDb(context, roleManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
