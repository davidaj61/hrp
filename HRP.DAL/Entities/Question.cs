using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HRP.DAL.Entities
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ID { get; set; }

        [Required]
        [MaxLength]
        [Display(Name ="پرسش")]
        public string Name { get; set; }

        [MaxLength(250)]
        [Display(Name = "راهنمای پرسش")]
        public string  Tooltip { get; set; }

        [Required]
        [Display(Name = "توضیحات دارد/ندارد")]
        public bool HasDescription { get; set; }


        public byte QuestionTypeID { get; set; }

        [ForeignKey("QuestionTypeID")]
        public virtual QuestionType Type { get; set; }

        public virtual ICollection<QuestionsInForm> QuestionsInForms { get; set; }
    }
}
