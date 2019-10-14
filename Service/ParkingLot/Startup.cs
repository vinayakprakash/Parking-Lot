using Authorization.Repository;
using Authorization.Validate;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingLot.Domain.Calculator;
using ParkingLot.Domain.Loaders;
using ParkingLot.Domain.Repository;
using ParkingLot.Domain.Savers;
using ParkingLot.Infra.Configuration;
using ParkingLot.Infra.Mappers;
using ParkingLot.Infra.Repository;
using ParkingLotApi.Service;
using Swashbuckle.AspNetCore.Swagger;

namespace ParkingLotApi
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddTransient<IAppConfiguration, AppConfiguration>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IAuthenticator, Authenticator>();
            services.AddTransient<IAuthorizer, Authorizer>();
            services.AddTransient<IParkingLotOverviewLoader, ParkingLotOverviewLoader>();
            services.AddTransient<IParkingLotOverviewRepository,ParkingLotOverviewRepository>();
            services.AddTransient<IVehicleLogSaver, VehicleLogSaver>();
            services.AddTransient<IPricingModelRepository, PricingModelRepository>();
            services.AddTransient<IParkingChargesCalculator, ParkingChargesCalculator>();
            services.AddTransient<IVehicleLogService, VehicleLogService>();
            services.AddTransient<IVehicleLogLoader, VehicleLogLoader>();
            services.AddTransient<IVehicleLogRepository, VehicleLogRepository>();
            services.AddTransient<IParkingLotOverviewMapper, ParkingLotOverviewMapper>();
            services.AddTransient<IPricingModelMapper, PricingModelMapper>();
            services.AddTransient<IUserRoleMapper, UserRoleMapper>();
            services.AddTransient<IVehicleLogMapper, VehicleLogMapper>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "Parking Lot API", Version = "V1"}); });
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

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parking API V1"); });
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("D:\\FireBase\\perchedpeacockparking-firebase.json"),
            });
        }
    }
}