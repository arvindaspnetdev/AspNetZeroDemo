using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace AspnetboilerplateDemo.Countries.Dto
{
    public class CountryListDto : EntityDto, IHasCreationTime
    {
        public string CountryName { get; set; } 
        public DateTime CreationTime { get; set; }
    }
}
