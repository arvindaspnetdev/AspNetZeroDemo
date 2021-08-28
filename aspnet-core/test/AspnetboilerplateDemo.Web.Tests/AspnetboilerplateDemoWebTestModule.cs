using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspnetboilerplateDemo.EntityFrameworkCore;
using AspnetboilerplateDemo.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AspnetboilerplateDemo.Web.Tests
{
    [DependsOn(
        typeof(AspnetboilerplateDemoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AspnetboilerplateDemoWebTestModule : AbpModule
    {
        public AspnetboilerplateDemoWebTestModule(AspnetboilerplateDemoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspnetboilerplateDemoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AspnetboilerplateDemoWebMvcModule).Assembly);
        }
    }
}