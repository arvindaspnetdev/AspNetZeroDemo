using Abp.MultiTenancy;
using AspnetboilerplateDemo.Authorization.Users;

namespace AspnetboilerplateDemo.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
