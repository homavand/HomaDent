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

        public InsurerServiceTarefe(decimal freePrice, decimal insurerPrice, int insurerPercent)
        {
            this.FreePrice = freePrice ;
            this.InsurerPrice = insurerPrice ;
            this.InsurerPercent = insurerPercent ;
        }


        public int InsurerServiceTarefeChangeId { get; set; }
        public int InsurerId { get; set; }
        public int? ServiceId { get; set; }
        public string InsurerTitle { get; set; }
        public int InsurerPercent { get; set; }
        public decimal FreePrice { get; set; }
        public decimal InsurerPrice { get; set; }
        public decimal ServicePrice
        {
            get { return FreePrice; }
        }
        public decimal InsurerShare
        {
            get
            {
                var insurerShare = (InsurerPrice) * (InsurerPercent) / 100;
                return Math.Ceiling(insurerShare);
            }

        }

        public decimal FranchiseShare
        {
            get
            {
                var franchiseShare = (InsurerPrice) * (100 - InsurerPercent) / 100;
                return Math.Ceiling(franchiseShare);
            }

        }

        public decimal FreeShare
        {
            get
            {
                var freeShare = (FreePrice - InsurerPrice);
                return Math.Ceiling(freeShare);
            }

        }

        public decimal PatientShare
        {
            get
            {

                return this.FranchiseShare + this.FreeShare;
            }

        }

        public bool IsExpiredContract { get; set; }

        public DateTime? DefineDate { get; set; }
        public DateTime? RunDate { get; set; }
        public string SolarDefineDate {
            get
            {
                string date = "";
                if (this.DefineDate != null)
                    date =  new PersianDateTime(this.DefineDate.Value).ToString("yyyy/MM/dd");
                return date;
            }
        }
        public string SolarRunDate {
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
