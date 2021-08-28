using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspnetboilerplateDemo.Countries;

namespace AspnetboilerplateDemo.States
{
    [Table("AppState")]
    public class State : AuditedEntity
    {
        public const int MaxLength = 256;

        [Required]
        [StringLength(MaxLength)]
        public string StateName { get; set; }

        [Required]
        public virtual int CountryId { get; set; } 

        [ForeignKey("CountryId")]
        public virtual Country Countries { get; set; } 
    }
}
