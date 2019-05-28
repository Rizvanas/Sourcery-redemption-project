using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using My_IKS.Data.Domain;
using My_IKS.Persistance;
using My_IKS.Data.Repositories;
using My_IKS.Persistance.Repositories;
using My_IKS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using My_IKS.Persistance.Configurations;
using AutoMapper;

namespace My_IKS
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

            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddDbContext<IKSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IKSDatabase")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<IKSContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 6;

                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });

           
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWTSecret"].ToString());
            services.AddAuthentication()
            .AddJwtBearer(options => 
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
           

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors
            (
               builder => builder
               .WithOrigins(Configuration["ApplicationSettings:ClientURL"].ToString())
               .AllowAnyHeader()
               .AllowAnyMethod()
            );
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
