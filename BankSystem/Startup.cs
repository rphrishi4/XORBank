using AutoMapper;
using BusinessLayer.Contract;
using BusinessLayer.Implementation;
using EFDataLayer.Contract;
using EFDataLayer.Implementation;
using EFDataLayer.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EFDataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;

namespace BankSystem
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


            //EF Confi

            services.AddDbContext<Bank_DbContext>(
                option => option.UseSqlServer(Configuration.GetConnectionString("Default"))
                );

            //Identity Service
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores <Bank_DbContext> ().AddDefaultTokenProviders();

            services.AddControllersWithViews();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //mapRepo

            services.AddScoped<ICustomerRepo,CustomerRepoImpl>();
            services.AddScoped<ICustomerManager, CustomerManagerImpl>();
            services.AddScoped<IAccountRepo, AccountRepoImpl>();
            services.AddScoped<IAccountManager, AccountManagerImpl>();
            services.AddScoped<ITransactionRepo, TransactionRepoImpl>();
            services.AddScoped<ITransactionManager, TransactionManagerImpl>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
