using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Attendee;
using NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Conference;
using NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Proposal;

namespace NetCore.Fundamentals.OIC.Client.Web
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
            services.AddControllersWithViews(o =>
            o.Filters.Add(new AuthorizeFilter()));

            services.AddAuthentication(o =>
            {
                o.DefaultScheme =
                CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme =
                OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie()
                .AddOpenIdConnect(options =>
                {
                    options.Authority = "https://localhost:44393";

                    options.ClientId = "netcore_fundamentals_web";
                    //Store in application secrets
                    options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
                    options.CallbackPath = "/signin-oidc";

                    options.Scope.Add("netcore_fundamentals");
                    options.Scope.Add("netcore_fundamentals_conference_api");
                    options.Scope.Add("netcore_fundamentals_attendee_api");
                    options.Scope.Add("netcore_fundamentals_proposal_api");

                    options.SaveTokens = true;

                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClaimActions.MapUniqueJsonKey("CareerStarted","CareerStarted");
                    options.ClaimActions.MapUniqueJsonKey("FullName", "FullName");
                    options.ClaimActions.MapUniqueJsonKey("Role", "role");
                    options.ClaimActions.MapUniqueJsonKey("Permission", "Permission");

                    options.ResponseType = "code";
                    options.ResponseMode = "form_post";

                    options.UsePkce = true;
                    options.TokenValidationParameters.RoleClaimType = "Role";
                });

            services.AddHttpContextAccessor();
            services.AddHttpClient<IConferenceAgent, ConferenceAgent>(
                async (services, client) =>
                {
                    var accessor = services.GetRequiredService<IHttpContextAccessor>();
                    var accessToken = await accessor.HttpContext.GetTokenAsync("access_token");
                    client.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("bearer", accessToken);
                    client.BaseAddress = new Uri("https://localhost:44373");
                });
            services.AddHttpClient<IProposalAgent, ProposalAgent>(
                async (services, client) =>
                {
                    var accessor = services.GetRequiredService<IHttpContextAccessor>();
                    var accessToken = await accessor.HttpContext.GetTokenAsync("access_token");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
                    client.BaseAddress = new Uri("https://localhost:44323");
                });
            services.AddHttpClient<IAttendeeAgent, AttendeeAgent>(
                async (services, client) =>
                {
                    var accessor = services.GetRequiredService<IHttpContextAccessor>();
                    var accessToken = await accessor.HttpContext.GetTokenAsync("access_token");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
                    client.BaseAddress = new Uri("https://localhost:44326");
                });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Conference}/{action=Index}/{id?}");
            });
        }
    }
}
