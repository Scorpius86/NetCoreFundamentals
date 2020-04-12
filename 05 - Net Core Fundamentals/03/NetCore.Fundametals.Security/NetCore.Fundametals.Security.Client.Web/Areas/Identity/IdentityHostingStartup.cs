using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Fundametals.Security.Client.Web.Data;
using NetCore.Fundametals.Security.Client.Web.Models;

[assembly: HostingStartup(typeof(NetCore.Fundametals.Security.Client.Web.Areas.Identity.IdentityHostingStartup))]
namespace NetCore.Fundametals.Security.Client.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NetCoreFundametalsSecurityClientWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NetCoreFundametalsSecurityClientWebContextConnection")));

                //Sin Roles
                //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<NetCoreFundametalsSecurityClientWebContext>();

                services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<NetCoreFundametalsSecurityClientWebContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
                //Email
                services.AddTransient<IEmailSender, EmailSender>();
                //External Provider
                services.AddAuthentication()
                .AddGoogle(opt =>
                {
                    opt.ClientId = "634778650579-ii5iqvioo6ln1si1v44af52qdi8urinj.apps.googleusercontent.com";
                    opt.ClientSecret = context.Configuration["Google:ClientSecret"];
                });
            });
        }
    }
}