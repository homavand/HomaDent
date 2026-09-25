using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry
{
    public class PatientVisitRow
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int? DoctorId { get; set; }
        public string DoctorTitle { get; set; }
        public int? ServiceGroupId { get; set; }
        public string ServiceGroupTitle { get; set; }
        public string SolarDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string MobilePhone { get; set; }
    }
}
