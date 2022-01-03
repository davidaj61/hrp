using HRP.Core.ViewModels;
using HRP.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRP.SIte.Areas.AdminPanel.Controllers
{
    public class PersonController : Controller
    {
        private readonly UserManager<User> userManager;
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(UserViewModel model)
        {
            return View();
        }
    }
}
