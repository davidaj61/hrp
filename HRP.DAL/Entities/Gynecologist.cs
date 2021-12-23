using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRP.DAL.Entities
{
    public class Gynecologist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ID { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        [Display(Name ="نام پزشک متخصص")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="فعال/غیرفعال")]
        public bool IsActive { get; set; }

        public virtual PregnancyCase PregnancyCase { get; set; }
    }
}
