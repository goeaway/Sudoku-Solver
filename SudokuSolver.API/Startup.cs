using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using SudokuSolver.API.Behaviors;

namespace SudokuSolver.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMediatR(Assembly.GetAssembly(typeof(Startup)));

            services.AddMemoryCache();
            services.AddLogger();
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddHttpContextAccessor();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseIpRateLimiting();
            app.UseMvc();
        }

        private void ExceptionHandler(IApplicationBuilder app)
        {
            app.Run(ctx =>
            {
                return Task.Run(async () =>
                {
                    ctx.Response.StatusCode = 500;
                    var exHandler = ctx.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exHandler.Error;
                    var uri = ctx.Request.Path;
                    var logger = app.ApplicationServices.GetService<ILogger>();
                    logger.Error(exception, "Error occurred when processing request {uri}", uri);
                    await ctx.Response.WriteAsync($"Error Occurred: {exception.Message}. {exception.InnerException?.Message}");
                });
            });
        }
    }
}
