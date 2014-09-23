using Hangfire;
using Hangfire.SqlServer;
using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HangfirePlayground.Startup))]

namespace HangfirePlayground
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseHangfire(config =>
            {
                config.UseSqlServerStorage("Server=localhost;Database=_HangfirePlayground;Trusted_Connection=True;");
                config.UseServer();
            });
        }

    }
}
