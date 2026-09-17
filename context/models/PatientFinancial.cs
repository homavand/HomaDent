using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{

    [Table("PatientFinancials")]
    public class PatientFinancial
    {
        public int Id { get; set; }

        [Column("Date")]
        public string DateRaw { get; set; }

        [NotMapped]
        public DateTime Date
        {
            get => DateTime.TryParseExact(DateRaw, new[] { "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm" },
                       System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var d)
                   ? d : DateTime.MinValue;
            set => DateRaw = value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public decimal Amount { get; set; }
        public decimal? Discount { get; set; }
        public string TransactionCode { get; set; }
        public string ChequeNumber { get; set; }

        [Column("DateOfIssuance")]
        public string DateOfIssuanceRaw { get; set; }

        [NotMapped]
        public DateTime? DateOfIssuance
        {
            get => DateTime.TryParseExact(DateOfIssuanceRaw, new[] { "yyyy/MM/dd HH:mm", "yyyy/MM/dd" },
                       System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var d)
                   ? d : (DateTime?)null;
            set => DateOfIssuanceRaw = value.HasValue ? value.Value.ToString("yyyy/MM/dd HH:mm") : null;
        }

        [Column("DateOfMaturity")]
        public string DateOfMaturityRaw { get; set; }

        [NotMapped]
        public DateTime? DateOfMaturity
        {
            get => DateTime.TryParseExact(DateOfMaturityRaw, new[] { "yyyy/MM/dd HH:mm", "yyyy/MM/dd" },
                       System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var d)
                   ? d : (DateTime?)null;
            set => DateOfMaturityRaw = value.HasValue ? value.Value.ToString("yyyy/MM/dd HH:mm") : null;
        }

        public string Comment { get; set; }
        public bool? IsDeleted { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int PayTypeId { get; set; }
        public virtual PayType PayType { get; set; }

        public int? BankId { get; set; }
        public virtual Bank Bank { get; set; }

        public int? ChequeStatusId { get; set; }
        [ForeignKey("ChequeStatusId")]
        public virtual ChequeStatus ChequeStatu { get; set; } // name kept as in original model (typo)
    }
}
