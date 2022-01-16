using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRP.Core.ViewModels.AdminPanel
{

    public class UserViewModel
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "ورود نام الزامی است.")]
        public string Name { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "ورود نام خانوادگی الزامی است.")]
        public string Family { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "ورود کد ملی الزامی است.")]
        [MaxLength(10,ErrorMessage = "کد ملی 10 رقمی می باشد؟!")]
        [MinLength(10,ErrorMessage = "کد ملی 10 رقمی می باشد؟!")]
        [RegularExpression(@"/\d{10}",ErrorMessage = "لطفا کد ملی معتبر وارد نمایید.")]
        public long NationalCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ورود شماره تلفن همراه الزامی است.")]
        [MaxLength(11, ErrorMessage = "شماره تلفن همراه 11 رقمی می باشد؟!")]
        [MinLength(11, ErrorMessage = "شماره تلفن همراه 11 رقمی می باشد؟!")]
        [RegularExpression(@"/\d{11}", ErrorMessage = "لطفا شماره تلفن همراه معتبر وارد نمایید.")]
        [Phone]
        public long Mobile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ورود رمز عبور الزامی است.")]
        [DataType(nameof(Password))]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ورود تکرار رمز عبور الزامی است.")]
        [DataType(nameof(Password))]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "اعلام وضعیت کاربر الزامی است.")]
        public bool? IsActive { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public int PersonID { get; set; }

    }
}
