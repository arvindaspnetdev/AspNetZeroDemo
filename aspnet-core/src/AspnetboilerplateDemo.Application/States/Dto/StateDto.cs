using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto; 
using Abp.AutoMapper; 

namespace AspnetboilerplateDemo.States.Dto
{
    public class StateDto : EntityDto<int>
    {
        [Required] 
        public string StateName { get; set; }

        [Required]
        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}