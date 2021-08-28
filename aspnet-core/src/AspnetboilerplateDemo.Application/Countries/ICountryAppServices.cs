using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AspnetboilerplateDemo.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetboilerplateDemo.Countries
{
    public interface ICountryAppServices : IAsyncCrudAppService<CountryDto, int, PagedCountryResultRequestDto, CreateCountryDto, CountryDto>
    {
        Task<CountryDto> GetCountryForEdit(EntityDto input);
    }
}
