using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("Configs")]
    public class Config
    {
        public int Id { get; set; }
        [Required] public string Key { get; set; }
        public string Value { get; set; }
        public string Tag { get; set; }
    }
}
