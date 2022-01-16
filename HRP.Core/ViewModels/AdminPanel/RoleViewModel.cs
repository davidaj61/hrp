using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRP.Core.ViewModels.AdminPanel
{
    public class RoleViewModel
    {
        [Display(Name = "نام نقش")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ورود نام نقش الزامی است.")]
        public string Name { get; set; }


        [Display(Name = "عنوان نقش")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ورود عنوان نقش الزامی است.")]
        public string Title { get; set; }
    }
}
