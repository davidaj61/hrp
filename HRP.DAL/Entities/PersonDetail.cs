using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRP.DAL.Entities
{
    public class PersonDetail
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        [MaxLength(150)]
        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "تلفن ثابت")]
        public long PhoneNumber { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
