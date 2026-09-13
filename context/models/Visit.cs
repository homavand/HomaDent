using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("Visits")]
    public class Visit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Column("StartTime")]
        public string StartTimeRaw { get; set; }

        [NotMapped]
        public TimeSpan StartTime
        {
            get => TimeSpan.TryParse(StartTimeRaw, out var t) ? t : TimeSpan.Zero;
            set => StartTimeRaw = value.ToString();
        }

        [Column("EndTime")]
        public string EndTimeRaw { get; set; }

        [NotMapped]
        public TimeSpan EndTime
        {
            get => TimeSpan.TryParse(EndTimeRaw, out var t) ? t : TimeSpan.Zero;
            set => EndTimeRaw = value.ToString();
        }
        public int? Color { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public long PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int? ServiceGroupId { get; set; }
        public virtual ServiceGroup ServiceGroup { get; set; }
    }
}
