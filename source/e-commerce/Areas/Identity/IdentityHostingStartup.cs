
using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(e_commerce.Areas.Identity.IdentityHostingStartup))]
namespace e_commerce.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
