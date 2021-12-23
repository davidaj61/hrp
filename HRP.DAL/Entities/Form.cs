using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HRP.DAL.Entities
{
    public class Form
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ID { get; set; }
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        [Display(Name ="نام فرم")]
        public string Name { get; set; }

        public virtual ICollection<QuestionsInForm> QuestionsInForms { get; set; }
    }
}
