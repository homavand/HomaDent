using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("Offices")]
    public class Office
    {
        public int Id { get; set; }
        public string OfficeName { get; set; }
        public string DoctorName { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeType { get; set; }
        public string NezamPezeshki { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficeAddress { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DefaultDoctorId { get; set; }
        public int? DefaultBasicInsurerId { get; set; }
        public int? DefaultMaritalStatusId { get; set; }
        public int? DefaultEducationLevelId { get; set; }
        public int? DefaultNationalityId { get; set; }
        public string BackupPath { get; set; }
    }
}
