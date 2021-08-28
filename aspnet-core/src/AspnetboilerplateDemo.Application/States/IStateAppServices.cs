using Abp.Application.Services;
using Abp.Application.Services.Dto; 
using AspnetboilerplateDemo.States.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetboilerplateDemo.States
{
    public interface IStateAppServices : IAsyncCrudAppService<StateDto, int, PagedStateResultRequestDto, CreateStateDto, StateDto>
    {
        Task<List<ComboboxItemDto>> GetContryLookupItems(int? selectedId = null);
        PagedResultDto<StateDto> GetAllState(PagedStateResultRequestDto input);

        Task<StateEditDto> GetStateForEdit(EntityDto input);
    }
}
