using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("InsurerServiceTarefeChanges")]
    public class InsurerServiceTarefeChange
    {
        public int Id { get; set; }
        public DateTime DefineDate { get; set; }
        public DateTime RunDate { get; set; }
        // Nullable here to match the real DB schema (FreePrice, InsurerPrice,
        // and UserId all allow NULL) - found while converting
        // DefineInsurersPricingX, whose original SQL explicitly inserted a
        // NULL UserId. Current data happens to have no nulls in FreePrice/
        // InsurerPrice and UserId is always NULL, but the non-nullable
        // declaration that was here before would have blocked replicating
        // that insert.
        public long? FreePrice { get; set; } // was decimal?
        public long? InsurerPrice { get; set; } // was decimal?

        public int InsurerId { get; set; }
        public virtual Insurer Insurer { get; set; }

        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }

}
