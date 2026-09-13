using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("Costs")]
    public class Cost
    {
        public int Id { get; set; }

        [Required] public string Title { get; set; }
        public decimal Amount { get; set; }
        public string FactorNumber { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateOfIssuance { get; set; }
        public DateTime? DateOfMaturity { get; set; }
        public string Comment { get; set; }
        public bool? IsDeleted { get; set; }

        public int CostTypeId { get; set; }
        public virtual CostType CostType { get; set; }

        public int PayTypeId { get; set; }
        public virtual PayType PayType { get; set; }

        public int? BargainSideId { get; set; }
        public virtual BargainSide BargainSide { get; set; }

        public int? BankId { get; set; }
        public virtual Bank Bank { get; set; }

        // Column exists on the real Costs table but was missing from this
        // model (found while converting GetCostFinancialsX to LINQ).
        public int? ChequeStatusId { get; set; }
        public virtual ChequeStatus ChequeStatus { get; set; }
    }
}
