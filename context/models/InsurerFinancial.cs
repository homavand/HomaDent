using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{

    [Table("InsurerFinancials")]
    public class InsurerFinancial
    {
        public int Id { get; set; }
        public int PrescriptionCount { get; set; }
        public DateTime Date { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal RequestedValue { get; set; }
        public decimal? ReceivedValue { get; set; }
        public decimal? DeductionValue { get; set; }
        public decimal? RemainPrice { get; set; }
        public bool? IsSendToInsurer { get; set; }
        public bool? IsPrimaryCheck { get; set; }
        public bool IsFinalCheck { get; set; }
        public bool IsCloseStatus { get; set; }
        public string Comment { get; set; }
        public bool? IsDeleted { get; set; }

        public int InsurerId { get; set; }
        public virtual Insurer Insurer { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
