using Abp.Application.Services;
using AspnetboilerplateDemo.MultiTenancy.Dto;

namespace AspnetboilerplateDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

