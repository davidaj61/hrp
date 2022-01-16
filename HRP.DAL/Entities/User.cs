using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HRP.DAL.Entities
{
    public class User:IdentityUser
    {
        public int PersonID { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public Boolean? IsActive { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
    }
}
