using System.Threading.Tasks;
using Abp.Application.Services;
using AspnetboilerplateDemo.Authorization.Accounts.Dto;

namespace AspnetboilerplateDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
