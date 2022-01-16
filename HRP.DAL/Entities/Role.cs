using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HRP.DAL.Entities
{
    public class Role:IdentityRole
    {

        public string  Title { get; set; }
    }
}
