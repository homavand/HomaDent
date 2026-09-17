using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{

    [Table("PatientSpecialComments")]
    public class PatientSpecialComment
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int SpecialCommentTypeId { get; set; }
        public virtual SpecialCommentType SpecialCommentType { get; set; }
    }
}
