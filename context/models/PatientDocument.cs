using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{

    [Table("PatientDocuments")]
    public class PatientDocument
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public byte[] Image { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }

        public long PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
