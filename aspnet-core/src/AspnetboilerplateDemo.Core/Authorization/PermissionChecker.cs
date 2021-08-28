using Abp.Authorization;
using AspnetboilerplateDemo.Authorization.Roles;
using AspnetboilerplateDemo.Authorization.Users;

namespace AspnetboilerplateDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
