using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyIdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //.well-known/openid-configuration
            services.AddIdentityServer(options => options.IssuerUri = "https://dps.qikan.com")
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(ConfigData.GetIdentityResources())
                .AddInMemoryApiResources(ConfigData.GetApis())
                .AddInMemoryApiScopes(ConfigData.GetScopes())
                .AddInMemoryClients(ConfigData.GetClients())
                .AddTestUsers(ConfigData.GetUsers());


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseIdentityServer();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(handler =>
            {
                handler.Response.WriteAsync("Hello kititiy.");

                return Task.CompletedTask;
            });
        }
    }
}
