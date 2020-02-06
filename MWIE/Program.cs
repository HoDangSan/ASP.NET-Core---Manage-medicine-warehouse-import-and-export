using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MWIE.Encryption;
using MWIE.Models;

namespace MWIE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var host = CreateWebHostBuilder(args).Build();

            using (var services = host.Services.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetRequiredService<MWIEDbContext>();
                var userMgr = services.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                dbContext.Database.Migrate();

                var adminClaim = new Claim("Role", "Admin");
                var managerClaim = new Claim("Role", "Manager");

                if (!dbContext.Users.Any(u => u.UserName == "admin@test.com"))
                {
                    var adminUser = new IdentityUser
                    {   
                        UserName = "admin@test.com",
                        Email = "admin@test.com"
                    };
                    var result = userMgr.CreateAsync(adminUser, "password").GetAwaiter().GetResult();

                    userMgr.AddClaimAsync(adminUser, adminClaim).GetAwaiter().GetResult();
                    userMgr.AddClaimAsync(adminUser, managerClaim).GetAwaiter().GetResult();
                }
                else
                {
                    var adminUser = userMgr.FindByEmailAsync("admin@test.com").GetAwaiter().GetResult();

                    if (!userMgr.GetClaimsAsync(adminUser).GetAwaiter().GetResult().Any())
                    {
                        userMgr.AddClaimAsync(adminUser, adminClaim).GetAwaiter().GetResult();
                        userMgr.AddClaimAsync(adminUser, managerClaim).GetAwaiter().GetResult();
                    }
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}