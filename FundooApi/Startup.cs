using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManager.Interfaces;
using BusinessManager.Managers;
using Common.Models.UserModels;
using FundooRepository.Context;
using FundooRepository.Intefaces;
using FundooRepository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace FundooApi
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
            services.Configure<ApplicationSetting>(Configuration.GetSection("ApplicationSetting"));
            services.AddDbContextPool<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDBConncetion")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IAccountRepository, AccountRepository > ();
            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<INotesRepository, NotesRepository>();
            services.AddTransient<INotesManager, NotesManager>();
            services.AddTransient<ILabelRepository, LabelRepository>();
            services.AddTransient<ILabelManager, Labelmanager>();
            services.AddTransient<ICollaboratorsRepository, CollaboratorsRepository>();
            services.AddTransient<ICollaboratorsManager, CollaboraotrsManager>();

            //Swagger servicesConfiguration
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "FUNDOO NOTE API",
                    Description = "ASP.NET Core Web API"
                });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer",new string[0]}
                };
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                { 
                    Description="JWt Authorization header using the bearer scheme",
                    Name="Authorization",
                    In ="header",
                    Type="apiKey"           
                });
                c.AddSecurityRequirement(security);
            });

            //authenticate
            //services.AddDefaultIdentity<UserModel>().AddEntityFrameworkStores<UserContext>();

            //JWtAuthentication
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSetting:JWT_Secret"].ToString());
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false; x.SaveToken = true; x.TokenValidationParameters = new TokenValidationParameters { ValidateIssuerSigningKey = true, IssuerSigningKey = new SymmetricSecurityKey(key), ValidateIssuer = false, ValidateAudience = false };

            //.AddJwtBearer(x=> {
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //       ClockSkew = TimeSpan.Zero
            //        //ValidateIssuer = true,
            //        //ValidateAudience = true,
            //        //ValidateLifetime = true,
            //        //ValidateIssuerSigningKey = true,
            //        //ValidIssuer = Configuration["Jwt:Issuer"],
            //        //ValidAudience = Configuration["Jwt:Audience"],
            //        //IssuerSigningKey = new SymmetricSecurityKey(key)
            //    };
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sachin");
            });
            app.UseCors(x => x
                      .AllowAnyOrigin()
                      .AllowAnyHeader().AllowAnyMethod()
                      );
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
