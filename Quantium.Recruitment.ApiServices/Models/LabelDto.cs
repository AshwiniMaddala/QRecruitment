﻿
namespace Quantium.Recruitment.ApiServices.Models
{
    public class LabelDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long JobId { get; set; }

        public long TestId { get; set; }

        //public JobDto Job { get; set; }

        //public TestDto Test { get; set; }
    }
}