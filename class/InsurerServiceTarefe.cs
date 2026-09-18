using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Class
{
    class InsurerServiceTarefe
    {
        public InsurerServiceTarefe()
        {
        }

        public InsurerServiceTarefe(long freePrice, long insurerPrice, int insurerPercent)
        {
            this.FreePrice = freePrice;
            this.InsurerPrice = insurerPrice;
            this.InsurerPercent = insurerPercent;
        }


        public int InsurerServiceTarefeChangeId { get; set; }
        public int InsurerId { get; set; }
        public int? ServiceId { get; set; }
        public string InsurerTitle { get; set; }
        public int InsurerPercent { get; set; }
        public long FreePrice { get; set; }
        public long InsurerPrice { get; set; }
        public long ServicePrice
        {
            get { return FreePrice; }
        }
        public long InsurerShare
        {
            get
            {
                // IMPORTANT: this used to be decimal * int / int, which divides
                // with fractional precision automatically. Now that both
                // operands are integral (long/int), doing the division directly
                // would be an INTEGER division and silently truncate before
                // Math.Ceiling ever got a chance to round anything (e.g.
                // 1000 * 30 / 100 is fine, but the truncation risk shows up the
                // moment the true result isn't a whole number, like
                // 1000 * 33 / 100 = 330 vs. a case that would have rounded up).
                // Casting to double first restores fractional division, then
                // Ceiling + cast back to long gives the correct rounded-up
                // whole-Rial amount.
                var insurerShare = (double)InsurerPrice * InsurerPercent / 100.0;
                return (long)Math.Ceiling(insurerShare);
            }

        }

        public long FranchiseShare
        {
            get
            {
                var franchiseShare = (double)InsurerPrice * (100 - InsurerPercent) / 100;
                return (long)Math.Ceiling(franchiseShare);
            }

        }

        public long FreeShare
        {
            get
            {
                // Plain subtraction of two whole-Rial values - already
                // integral, no division involved, so no precision concern here.
                var freeShare = (FreePrice - InsurerPrice);
                return freeShare;
            }

        }

        public long PatientShare
        {
            get
            {

                return this.FranchiseShare + this.FreeShare;
            }

        }

        public bool IsExpiredContract { get; set; }

        public DateTime? DefineDate { get; set; }
        public DateTime? RunDate { get; set; }
        public string SolarDefineDate
        {
            get
            {
                string date = "";
                if (this.DefineDate != null)
                    date = new PersianDateTime(this.DefineDate.Value).ToString("yyyy/MM/dd");
                return date;
            }
        }
        public string SolarRunDate
        {
            get
            {
                string date = "";
                if (this.RunDate != null)
                    date = new PersianDateTime(this.RunDate.Value).ToString("yyyy/MM/dd");
                return date;

            }
        }
        public bool IsCheck { get; set; }

    }
}
