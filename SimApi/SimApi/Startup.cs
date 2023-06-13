using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimApi.Base;
using SimApi.Data.Context;
using SimApi.Data.Repository;
using SimApi.Data.Repository.Transaction;
using SimApi.Data.Uow;
using SimApi.Service.Middleware;
using SimApi.Service.RestExtension;

namespace SimApi.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static JwtConfig JwtConfig { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddCustomSwaggerExtension();
            services.AddDbContextExtension(Configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMapperExtension();
            services.AddRepositoryExtension();
            services.AddServiceExtension();
            services.AddJwtExtension();
        }

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sim Company");
                c.DocumentTitle = "SimApi Company";
            });

            app.UseMiddleware<HeartBeatMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            Action<RequestProfilerModel> requestResponseHandler = requestProfilerModel =>
            {
                Serilog.Log.Information("-------------Request-Begin------------");
                Serilog.Log.Information(requestProfilerModel.Request);
                Serilog.Log.Information(System.Environment.NewLine);
                Serilog.Log.Information(requestProfilerModel.Response);
                Serilog.Log.Information("-------------Request-End------------");
            };
            app.UseMiddleware<RequestLoggingMiddleware>(requestResponseHandler);

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
