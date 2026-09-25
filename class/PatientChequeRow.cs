using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry
{
    public class PatientChequeRow
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string ChequeTypeTitle { get; set; }
        public string SolarDateOfMaturity { get; set; }
        public string ChequeNumber { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
    }
}
