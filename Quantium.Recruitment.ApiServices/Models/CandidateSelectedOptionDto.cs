﻿using Reinforced.Typings.Attributes;

namespace Quantium.Recruitment.ApiServices.Models
{
    [TsClass]
    public class CandidateSelectedOptionDto
    {
        public long Id { get; set; }

        public long ChallengeId { get; set; }

        public long OptionId { get; set; }

        //public ChallengeDto Challenge { get; set; }

        //public OptionDto Option { get; set; }
    }
}
