using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RailwaySystem.API.Data;
using RailwaySystem.API.Repository;
using RailwaySystem.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RailwaySystem.API
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
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:44389",
                        ClockSkew = TimeSpan.Zero,
                        ValidAudiences = new List<string>
                        {
                            "https://localhost:44389",
                            "https://localhost:4200"
                        },
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("55f6UmNJfrbdi8It"))
                    };
                });
            services.AddDbContext<TrainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            #region Transients

            services.AddTransient<ITrain, TrainRepo>();
            services.AddTransient<TrainS, TrainS>();
            services.AddTransient<ITicket, TicketRepo>();
            services.AddTransient<TicketS, TicketS>();
            services.AddTransient<IQuota, QuotaRepo>();
            services.AddTransient<QuotaS, QuotaS>();
            services.AddTransient<IPassenger, PassengerRepo>();
            services.AddTransient<PassengerS, PassengerS>();
            services.AddTransient<IBooking, BookingRepo>();
            services.AddTransient<BookingS, BookingS>();
            services.AddTransient<IUser, UserRepo>();
            services.AddTransient<UserS, UserS>();
            services.AddTransient<IBankCred, BankCredRepo>();
            services.AddTransient<BankCredS, BankCredS>();
            services.AddTransient<ISeat, SeatRepo>();
            services.AddTransient<SeatS, SeatS>();
            services.AddTransient<ITransaction, TransactionRepo>();
            services.AddTransient<TransactionS, TransactionS>();
            #endregion

            services.AddCors();
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
                options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Railway_System", Version = "v1" });
            });
           
       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Railway_System v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
