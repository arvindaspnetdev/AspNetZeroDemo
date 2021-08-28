using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AspnetboilerplateDemo.Authorization.Roles;
using AspnetboilerplateDemo.Authorization.Users;
using AspnetboilerplateDemo.MultiTenancy;
using AspnetboilerplateDemo.Countries;
using AspnetboilerplateDemo.States;

namespace AspnetboilerplateDemo.EntityFrameworkCore
{
    public class AspnetboilerplateDemoDbContext : AbpZeroDbContext<Tenant, Role, User, AspnetboilerplateDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public AspnetboilerplateDemoDbContext(DbContextOptions<AspnetboilerplateDemoDbContext> options)
            : base(options)
        {
        }
    }
}
