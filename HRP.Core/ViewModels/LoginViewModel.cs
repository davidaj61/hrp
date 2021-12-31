using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRP.Core.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کاربری وارد نشده است!؟")]
        [MaxLength(10,ErrorMessage ="نام کاربری معتبر نمی باشد.")]
        [RegularExpression(@"/\d{10}",ErrorMessage = "نام کاربری معتبر نمی باشد.")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="کلمه عبور وارد نشده است!؟")]
        [DataType(nameof(Password))]
        public string Password { get; set; }
    }
}
