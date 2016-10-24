﻿using Quantium.Recruitment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Quantium.Recruitment.ApiServices.Models;
using Quantium.Recruitment.Entities;
using Quantium.Recruitment.Infrastructure.Repositories;

namespace Quantium.Recruitment.ApiServices.Controllers
{
    public class CandidateController : ApiController
    {
        private readonly ICandidateRepository _candidateRepository;
        //private readonly IAdminRepository _adminRepository;

        //public UsersController(ICandidateRepository candidateRepository, IAdminRepository adminRepository)
        //{
        //    _candidateRepository = candidateRepository;
        //    _adminRepository = adminRepository;
        //}

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var candidates = _candidateRepository.GetAll().Where(candidate => candidate.IsActive).ToList();

            return Ok(Mapper.Map<IList<CandidateDto>>(candidates));
        }

        [HttpGet]
        public IHttpActionResult GetCandidateByEmail([FromUri]string email)
        {
            var candidate = _candidateRepository.GetAll().SingleOrDefault(item => item.Email == email && item.IsActive == true);

            if(candidate != null)
                return Ok(Mapper.Map<CandidateDto>(candidate));
            else
                return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetSingleCandidate(int key)
        {
            var candidate = _candidateRepository.GetAll().Single(item => item.Id == key);

            return Ok(Mapper.Map<CandidateDto>(candidate));
        }

        [HttpPost]
        public IHttpActionResult AddCandidates([FromBody]List<CandidateDto> candidateDtos)
        {
            var candidates = Mapper.Map<List<Candidate>>(candidateDtos);

            foreach (var candidate in candidates)
            {
                _candidateRepository.Add(candidate);
            }

            return Ok("Candidates Created");
        }

            ////http://localhost:60606/odata/Admins
            //[HttpGet]
            //[ODataRoute("Admins")]
            //public IHttpActionResult GetAdmins()
            //{
            //    var admins = _adminRepository.GetAll().ToList();

            //    return Ok(Mapper.Map<IList<AdminDto>>(admins));
            //}

            ////http://localhost:60606/odata/Admins(1)
            //[HttpGet]
            //[ODataRoute("Admins({key})")]
            //public IHttpActionResult GetAdmin([FromODataUri] int key)
            //{
            //    var admin = _adminRepository.GetAll().Single(item => item.Id == key);

            //    return Ok(Mapper.Map<AdminDto>(admin));
            //}
        }
}