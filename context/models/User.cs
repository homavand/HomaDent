using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        [Required] public string UserName { get; set; }
        [Required] public string UserPass { get; set; }
        [Required] public string Email { get; set; }
        public bool IsDeleted { get; set; }

        // Column exists on the real Users table but was missing from this
        // model (found while converting GetStaffsX to LINQ).
        public int? StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public virtual ICollection<InsurerServiceTarefeChange> InsurerServiceTarefeChanges { get; set; }
        public virtual ICollection<InsurerFinancial> InsurerFinancials { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }

        public User()
        {
            InsurerServiceTarefeChanges = new HashSet<InsurerServiceTarefeChange>();
            InsurerFinancials = new HashSet<InsurerFinancial>();
            UserPermissions = new HashSet<UserPermission>();
        }
    }
}
