﻿
namespace Quantium.Recruitment.ApiServices.Models
{
    public class OptionDto
    {
        public long Id { get; set; }

        public long QuestionId { get; set; }

        public string Text { get; set; }

        //public byte[] Image { get; set; }

        public bool IsAnswer { get; set; }

        //public QuestionDto Question { get; set; }
    }
}