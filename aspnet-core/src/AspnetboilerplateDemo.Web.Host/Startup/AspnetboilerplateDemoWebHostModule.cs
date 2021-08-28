using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspnetboilerplateDemo.Configuration;

namespace AspnetboilerplateDemo.Web.Host.Startup
{
    [DependsOn(
       typeof(AspnetboilerplateDemoWebCoreModule))]
    public class AspnetboilerplateDemoWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AspnetboilerplateDemoWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspnetboilerplateDemoWebHostModule).GetAssembly());
        }
    }
}
