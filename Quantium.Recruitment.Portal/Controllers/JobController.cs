﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quantium.Recruitment.Models;
using Quantium.Recruitment.Portal.Helpers;
using Quantium.Recruitment.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Quantium.Recruitment.Portal.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class JobController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<QRecruitmentRole> _roleManager;
        private readonly IHttpHelper _helper;

        public JobController(UserManager<ApplicationUser> userManager, RoleManager<QRecruitmentRole> roleManager, IHttpHelper helper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _helper = helper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _helper.GetData("api/Job/GetAllJobs");

            return Ok(response.Content.ReadAsStringAsync().Result);
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody]JobDto job)
        {
            var response = _helper.Post("api/Job/Create", job);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception("Job creation failed");

            return response;
        }

    }
}
