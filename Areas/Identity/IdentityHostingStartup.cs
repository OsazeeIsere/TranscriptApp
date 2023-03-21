using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TranscriptApp.Data;
using TranscriptApp.Models;

[assembly: HostingStartup(typeof(TranscriptApp.Areas.Identity.IdentityHostingStartup))]
namespace TranscriptApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<TranscriptAppContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("TranscriptAppContextConnection")));

                //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<TranscriptAppContext>();
            //});
        }
    }
}
