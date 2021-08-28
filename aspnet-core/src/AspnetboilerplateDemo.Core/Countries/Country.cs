using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspnetboilerplateDemo.States;

namespace AspnetboilerplateDemo.Countries
{
    [Table("AppCountry")]
    public class Country : AuditedEntity
    {
        public const int MaxLength = 256; 

        [Required]
        [StringLength(MaxLength)]
        public string CountryName { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
