using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace AspnetboilerplateDemo.States.Dto
{
    public class StateListDto : EntityDto, IHasCreationTime
    {
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
