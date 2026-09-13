using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{

    [Table("PatientFollowups")]
    public class PatientFollowup
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime? FollowupDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string Comment { get; set; }
        public bool? IsDeleted { get; set; }

        public long PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
