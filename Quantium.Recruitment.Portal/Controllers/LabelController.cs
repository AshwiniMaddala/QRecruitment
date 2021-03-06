﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quantium.Recruitment.Portal.Helpers;
using Quantium.Recruitment.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quantium.Recruitment.Portal.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class LabelController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<QRecruitmentRole> _roleManager;
        private readonly IHttpHelper _helper;

        public LabelController(UserManager<ApplicationUser> userManager, RoleManager<QRecruitmentRole> roleManager, IHttpHelper helper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _helper = helper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _helper.GetData("api/Label/GetAll");

            return Ok(response.Content.ReadAsStringAsync().Result);
        }
    }
}
