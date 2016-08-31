﻿using Quantium.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantium.Recruitment.Infrastructure
{
    public class RecruitmentContext : DbContext
    {

        public RecruitmentContext() : base("name=RecruitmentDBContextConnectionString")
        {
            Database.SetInitializer(new RecruitmentDataSeeder());
            // disable lazy loading
            Configuration.LazyLoadingEnabled = false;

            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }


        //public DbSet<Admin> Admins { get; set; }

        //public DbSet<Candidate> Candidates { get; set; }

        //public DbSet<Job> Jobs { get; set; }

        //public DbSet<Department> Departments { get; set; }

        //public DbSet<Question> Questions { get; set; }

        //public DbSet<Option> Options { get; set; }

        //public DbSet<QuestionGroup> QuestionGroups { get; set; }

        //public DbSet<Test> Tests { get; set; }

        //public DbSet<Label> Labels { get; set; }

        //public DbSet<Challenge> Challenges { get; set; }

        //public DbSet<CandidateSelectedOption> CandidateSelectedOptions { get; set; }
    }
}
