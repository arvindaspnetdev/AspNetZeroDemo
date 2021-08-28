using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto; 
using Abp.AutoMapper; 

namespace AspnetboilerplateDemo.Countries.Dto
{
    public class CountryDto : EntityDto<int>
    {
        [Required] 
        public string CountryName { get; set; } 
    }
}