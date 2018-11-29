using System;
using CST465Lab8.Areas.Identity.Data;
using CST465Lab8.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CST465Lab8.Areas.Identity.IdentityHostingStartup))]
namespace CST465Lab8.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CST465Lab8Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CST465Lab8ContextConnection")));

                services.AddDefaultIdentity<CST465Lab8User>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<CST465Lab8Context>();

                services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                });
            });
        }
    }
}