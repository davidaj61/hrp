using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRP.Core.ViewModels.AdminPanel
{
    public class GynecologistViewModel
    {
        [Display(Name = "نام متخصص")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ورود نام الزامی است.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "اعلام وضعیت فعالیت متخصص الزامی است.")]
        public bool? IsActive { get; set; }


    }
}
