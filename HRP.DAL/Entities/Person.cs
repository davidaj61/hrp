using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRP.DAL.Entities
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "کد ملی")]
        [Required]
        public long NationalId { get; set; }

        [Display(Name="نام")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Display(Name="نام خانوادگی")]
        [Required]
        public string Famiy { get; set; }

        [Display(Name="تلفن همراه")]
        [Required]
        public long Mobile { get; set; }

        
        public virtual User User { get; set; }

        public virtual ICollection<PregnancyCase> Pregnant { get; set; }
    }
}
