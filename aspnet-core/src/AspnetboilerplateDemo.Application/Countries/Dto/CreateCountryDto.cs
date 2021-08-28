using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace AspnetboilerplateDemo.Countries.Dto
{
    public class CreateCountryDto
    {
        [Required] 
        public string CountryName { get; set; } 
    }
}
