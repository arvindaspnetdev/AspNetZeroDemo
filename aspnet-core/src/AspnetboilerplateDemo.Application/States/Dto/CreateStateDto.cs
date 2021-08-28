using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace AspnetboilerplateDemo.States.Dto
{
    public class CreateStateDto
    {
        [Required]
        public string StateName { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
