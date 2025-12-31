using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Skoruba.IdentityServer8.Admin.Configuration.Test
{
	public class StartupTest : Startup
    {
        public StartupTest(IWebHostEnvironment env, IConfiguration configuration) : base(env, configuration)
        {
        }

        public override void ConfigureUIOptions(IdentityServer8AdminUIOptions options)
        {
            base.ConfigureUIOptions(options);

            // Use staging DbContexts and auth services.
            options.Testing.IsStaging = true;
        }
    }
}
