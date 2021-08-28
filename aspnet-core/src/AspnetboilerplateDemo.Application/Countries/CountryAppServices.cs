using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AspnetboilerplateDemo.Authorization;
using AspnetboilerplateDemo.Countries.Dto; 
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

namespace AspnetboilerplateDemo.Countries
{
    [AbpAuthorize(PermissionNames.Pages_Country)]
    public class CountryAppServices : AsyncCrudAppService<Country, CountryDto, int, PagedCountryResultRequestDto, CreateCountryDto, CountryDto>, ICountryAppServices
    {

        private readonly IRepository<Country> _countryRepository;
        public CountryAppServices(IRepository<Country> countryRepository) : base(countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<CountryDto> GetCountryForEdit(EntityDto input)
        {
            Country oCountry = await _countryRepository.GetAsync(input.Id);
            CountryDto countryDto = ObjectMapper.Map<CountryDto>(oCountry);
            return countryDto;
        } 
    }
}
