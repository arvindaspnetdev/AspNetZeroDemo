using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto; 

namespace AspnetboilerplateDemo.Countries.Dto
{
    public class CountryEditDto : EntityDto<int>
    {
        [Required]
        public string CountryName { get; set; }
         
    }
}