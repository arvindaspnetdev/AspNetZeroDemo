﻿using Abp.Application.Services.Dto;

namespace AspnetboilerplateDemo.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

