using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("AppActions")]
    public class AppAction
    {
        public int Id { get; set; }

        [Required] public string FormTitle { get; set; }
        public string GroupTitle { get; set; }
        public string ActionTitle { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }

        public AppAction()
        {
            UserPermissions = new HashSet<UserPermission>();
        }
    }
}
