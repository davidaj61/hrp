using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HRP.DAL.Entities
{
    public class PregnancyCase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PersonId { get; set; }

        public DateTime CreationDate { get; set; }

        public short FamilyPhysicianID { get; set; }

        public Byte GynocologistId { get; set; }



        [Display(Name = "تاریخ آخرین قاعدگی")]
        [Required]
        public DateTime LastLMP { get; set; }

        [Display(Name = "سن بارداری")]
        public string PregnancyAge => ((DateTime.Now - LastLMP).Days / 7).ToString() + "هفته و" +
                                              ((DateTime.Now - LastLMP).Days % 7).ToString() + "روز";

        [Display(Name = "تاریخ احتمالی زایمان")]
        public string DeliveryTime => LastLMP.AddDays(280).ToString();

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

    }
}

