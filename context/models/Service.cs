using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("Services")]
    public class Service
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? Color { get; set; }
        public bool? IsToothNumber { get; set; }
        public bool? IsMoreTooth { get; set; }
        public DateTime? DefineDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Comment { get; set; }
        public bool? IsDeleted { get; set; }

        public int ServiceGroupId { get; set; }
        public virtual ServiceGroup ServiceGroup { get; set; }

        public virtual ICollection<PatientService> PatientServices { get; set; }
        public virtual ICollection<InsurerServiceTarefeChange> InsurerServiceTarefeChanges { get; set; }

        public Service()
        {
            PatientServices = new HashSet<PatientService>();
            InsurerServiceTarefeChanges = new HashSet<InsurerServiceTarefeChange>();
        }
    }
}
