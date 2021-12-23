using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRP.DAL.Entities
{
    public class QuestionsInForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ID { get; set; }
        public byte FormID { get; set; }
        public short QuestionID { get; set; }
        
        [ForeignKey("FormID")]
        public virtual Form Forms { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Questions { get; set; }
    }
}
