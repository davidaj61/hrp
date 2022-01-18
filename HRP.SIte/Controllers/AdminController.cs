using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRP.SIte.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return Content("به مرکز مدیریت سامانه ثبت مادران پرخطر خوش آمدید \n از منو کناری به بخشهای گوناگون دسترسی خواهید داشت. ");
        }
    }
}
