using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AspnetboilerplateDemo.Authorization;
using AspnetboilerplateDemo.States.Dto; 
using Abp.Application.Services.Dto; 
using Abp.Domain.Entities; 
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.UI;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AspnetboilerplateDemo.Countries; 
using System.Linq; 

namespace AspnetboilerplateDemo.States
{
    [AbpAuthorize(PermissionNames.Pages_State)]
    public class StateAppServices : AsyncCrudAppService<State, StateDto, int, PagedStateResultRequestDto, CreateStateDto, StateDto>, IStateAppServices
    {

        private readonly IRepository<State> _StateRepository; 
        private readonly IRepository<Country> _countryRepository;
        public StateAppServices(IRepository<State> StateRepository, IRepository<Country> countryRepository) : base(StateRepository)
        {
            _StateRepository = StateRepository;
            _countryRepository = countryRepository;
        }
        public async Task<List<ComboboxItemDto>> GetContryLookupItems(int? id = null)
        {
            List<Country> oCountry = await _countryRepository.GetAllListAsync(); 
            List<ComboboxItemDto> countryItems = new List<ComboboxItemDto>();

            countryItems = new ListResultDto<ComboboxItemDto>(oCountry.OrderBy(t=>t.CountryName).Select(e => new ComboboxItemDto(e.Id.ToString(), e.CountryName)).ToList()).Items.OrderBy(c => c.DisplayText).ToList();

            if (id.HasValue)
            {
                ComboboxItemDto selectedCenter = countryItems.FirstOrDefault(e => e.Value == id.Value.ToString());
                if (selectedCenter != null)
                {
                    selectedCenter.IsSelected = true;
                }
            } 
            return countryItems;
        }

        public async Task<StateEditDto> GetStateForEdit(EntityDto input)
        { 
            var state = await _StateRepository.GetAsync(input.Id); 
            var stateEditDto = ObjectMapper.Map<StateEditDto>(state);
            return stateEditDto;
        }
        public PagedResultDto<StateDto> GetAllState(PagedStateResultRequestDto input)
        {
            var query = _StateRepository.GetAllIncluding(x => x.Countries)
            .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.StateName.Contains(input.Keyword) || x.Countries.CountryName.Contains(input.Keyword));

            var totalCount = query.Count();

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            var states = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            var lstState = states.Select(t => new StateDto { StateName = t.StateName, CountryId = t.CountryId, CountryName = t.Countries.CountryName }).ToList();

            var dto = new PagedResultDto<StateDto>(
                 totalCount,
                  ObjectMapper.Map<List<StateDto>>(states)
                 );
            return dto;
        }
           
    }
}
