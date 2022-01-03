using System;
using System.Collections.Generic;
using System.Text;

namespace HRP.Core.ViewModels
{
    
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Family { get; set; }

        public long NationalCode { get; set; }

        public long Mobile { get; set; }

        public Guid RoleId { get; set; }

        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }

        public bool IsActive { get; set; }
        public int PersonID { get; set; }

    }
}
