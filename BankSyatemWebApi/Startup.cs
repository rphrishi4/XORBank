using AutoMapper;
using BusinessLayer.Contract;
using BusinessLayer.Implementation;
using EFDataLayer.Contract;
using EFDataLayer.Implementation;
using EFDataLayer.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EFDataLayer.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BankSyatemWebApi
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
                .AddEntityFrameworkStores<Bank_DbContext>();

            //Add Swagger Configuration
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
                {

                    Version = "V1.0",
                    Description = "Bank System Manager"
                });
                var xmlDoc = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlDoc);
                option.IncludeXmlComments(xmlPath);

            });



            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();
            //mapRepo

            services.AddScoped<ICustomerRepo, CustomerRepoImpl>();
            services.AddScoped<ICustomerManager, CustomerManagerImpl>();
            services.AddScoped<IAccountRepo, AccountRepoImpl>();
            services.AddScoped<IAccountManager, AccountManagerImpl>();
            services.AddScoped<ITransactionRepo, TransactionRepoImpl>();
            services.AddScoped<ITransactionManager, TransactionManagerImpl>();

            services.AddControllers();
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseSwagger();
            app.UseSwaggerUI(options => {

                options.SwaggerEndpoint("swagger/V1/swagger.json", "BankSystem  V1.0");
                options.RoutePrefix = string.Empty;
            }
                );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
