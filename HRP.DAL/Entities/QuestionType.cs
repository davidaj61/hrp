using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HRP.DAL.Entities
{
    public class QuestionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ID { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [Display(Name ="نوع سوال")]
        public string Name { get; set; }

        public virtual Question Question { get; set; }
    }
}
