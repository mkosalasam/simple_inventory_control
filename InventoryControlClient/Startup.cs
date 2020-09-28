using System.IdentityModel.Tokens.Jwt;
using InventoryControlClient.Data;
using InventoryControlClient.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InventoryControlClient
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
            services.AddControllersWithViews();

            services.AddDbContext<InventoryDbContext>(opt => opt.UseInMemoryDatabase("inventory"));

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            var oidcSetting = new OidcSetting();
            Configuration.GetSection("OidcSettings").Bind(oidcSetting);
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = oidcSetting.Authority;
                    options.RequireHttpsMetadata = false;

                    options.ClientId = oidcSetting.ClientId;
                    options.ClientSecret = oidcSetting.ClientSecret;
                    options.ResponseType = "code";

                    options.SaveTokens = true;
                });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("CreatorOnly", policy => policy.RequireClaim("creator"));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStatusCodePages();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
            });
        }
    }
}
