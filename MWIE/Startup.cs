using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MWIE.Models;
using MWIE.Models.Entity;
using MWIE.Repository.ClientRepository;
using MWIE.Repository.DetailReceiptExportRepository;
using MWIE.Repository.DetailReceiptImportRepository;
using MWIE.Repository.DetailReceiptLiquidationRepository;
using MWIE.Repository.DrugRepository;
using MWIE.Repository.GenericRepository;
using MWIE.Repository.GroupDrugRepository;
using MWIE.Repository.ProducerRepository;
using MWIE.Repository.ReceiptExportRepository;
using MWIE.Repository.ReceiptImportRepository;
using MWIE.Repository.ReceiptLiquidationRepository;
using MWIE.Repository.UserRepository;
using MWIE.Service.ClientService;
using MWIE.Service.DetailReceiptExportService;
using MWIE.Service.DetailReceiptImportService;
using MWIE.Service.DetailReceiptLiquidationService;
using MWIE.Service.DrugService;
using MWIE.Service.GroupDrugService;
using MWIE.Service.ProducerService;
using MWIE.Service.ReceiptExportService;
using MWIE.Service.ReceiptImportService;
using MWIE.Service.ReceiptLiquidationService;
using MWIE.Service.UserService;
using MWIE.UnitOfWork;

namespace MWIE
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
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                })
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<MWIEDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account");
                    options.LogoutPath = new PathString("/Account");
                });
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account";
                options.SlidingExpiration = true;
            });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"));     
                options.AddPolicy("Manager", policy => policy.RequireClaim("Role", "Manager"));
            });
            
            var config = new AutoMapper.MapperConfiguration(c => { c.AddProfile(new MapProfile()); }
            );
            
            var mapper = config.CreateMapper();
            
            services.AddDbContext<MWIEDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddSingleton(mapper);

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient<IGenericRepository<UserProfile>, GenericRepository<UserProfile>>();
            
            services.AddTransient<IProducerRepository, ProducerRepository>();
            services.AddScoped<IProducerService, ProducerService>();
            services.AddTransient<IGenericRepository<Producer>, GenericRepository<Producer>>();
            
            services.AddTransient<IGroupDrugRepository, GroupDrugRepository>();
            services.AddScoped<IGroupDrugService, GroupDrugService>();
            services.AddTransient<IGenericRepository<GroupDrug>, GenericRepository<GroupDrug>>();
            
            services.AddTransient<IDrugRepository, DrugRepository>();
            services.AddScoped<IDrugService, DrugService>();
            services.AddTransient<IGenericRepository<Drug>, GenericRepository<Drug>>();
            
            services.AddTransient<IReceiptImportRepository, ReceiptImportRepository>();
            services.AddScoped<IReceiptImportService, ReceiptImportService>();
            services.AddTransient<IGenericRepository<ReceiptImport>, GenericRepository<ReceiptImport>>();
            
            services.AddTransient<IDetailReceiptImportRepository, DetailReceiptImportRepository>();
            services.AddScoped<IDetailReceiptImportService, DetailReceiptImportService>();
            services.AddTransient<IGenericRepository<DetailReceiptImport>, GenericRepository<DetailReceiptImport>>();
            
            services.AddTransient<IReceiptExportRepository, ReceiptExportRepository>();
            services.AddScoped<IReceiptExportService, ReceiptExportService>();
            services.AddTransient<IGenericRepository<ReceiptExport>, GenericRepository<ReceiptExport>>();
            
            services.AddTransient<IDetailReceiptExportRepository, DetailReceiptExportRepository>();
            services.AddScoped<IDetailReceiptExportService, DetailReceiptExportService>();
            services.AddTransient<IGenericRepository<DetailReceiptExport>, GenericRepository<DetailReceiptExport>>();
            
            services.AddTransient<IReceiptLiquidationRepository, ReceiptLiquidationRepository>();
            services.AddScoped<IReceiptLiquidationService, ReceiptLiquidationService>();
            services.AddTransient<IGenericRepository<ReceiptLiquidation>, GenericRepository<ReceiptLiquidation>>();
            
            services.AddTransient<IDetailReceiptLiquidationRepository, DetailReceiptLiquidationRepository>();
            services.AddScoped<IDetailReceiptLiquidationService, DetailReceiptLiquidationService>();
            services.AddTransient<IGenericRepository<DetailReceiptLiquidation>, GenericRepository<DetailReceiptLiquidation>>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddTransient<IGenericRepository<Client>, GenericRepository<Client>>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddSessionStateTempDataProvider();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            loggerFactory.AddFile("Logs/mylog-{Date}.txt");
        }
    }
}