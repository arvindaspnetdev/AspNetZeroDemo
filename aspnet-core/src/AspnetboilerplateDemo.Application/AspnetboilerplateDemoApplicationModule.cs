using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspnetboilerplateDemo.Authorization;

namespace AspnetboilerplateDemo
{
    [DependsOn(
        typeof(AspnetboilerplateDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AspnetboilerplateDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AspnetboilerplateDemoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AspnetboilerplateDemoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
