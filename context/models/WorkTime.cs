using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{

    [Table("WorkTimes")]
    public class WorkTime
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        // این پراپرتی‌ها رو به دیتابیس نگاشت می‌کنیم (به‌صورت Ticks)
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

        public string Description { get; set; }
        public bool? IsDeleted { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }


    }
}
