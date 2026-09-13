using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    // Pure junction table (User <-> AppAction) plus a Value flag. No surrogate
    // Id column exists in the database - the composite key (UserId, AppActionId)
    // is configured in DentalContext.OnModelCreating.
    [Table("UserPermissions")]
    public class UserPermission
    {
        public bool Value { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int AppActionId { get; set; }
        public virtual AppAction AppAction { get; set; }
    }
}
