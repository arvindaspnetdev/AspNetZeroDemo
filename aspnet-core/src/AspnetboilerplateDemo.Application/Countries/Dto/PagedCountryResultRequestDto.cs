using Abp.Application.Services.Dto;

namespace AspnetboilerplateDemo.Countries.Dto
{
    public class PagedCountryResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

