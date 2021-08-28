using Abp.Application.Services.Dto;

namespace AspnetboilerplateDemo.States.Dto
{
    public class PagedStateResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

