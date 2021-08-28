using System.Threading.Tasks;
using Abp.Application.Services;
using AspnetboilerplateDemo.Sessions.Dto;

namespace AspnetboilerplateDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
