using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto; 

namespace AspnetboilerplateDemo.States.Dto
{
    public class StateEditDto : EntityDto<int>
    {
        [Required]
        public string StateName { get; set; }

        [Required]
        public int CountryId { get; set; }

    }
}