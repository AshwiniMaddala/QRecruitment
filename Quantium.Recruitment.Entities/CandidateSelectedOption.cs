﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quantium.Recruitment.Entities
{
    [Table(name: "CandidateSelectedOption")]
    public class CandidateSelectedOption : Identifiable
    {
        public virtual long ChallengeId { get; set; }

        public virtual long OptionId { get; set; }

        [ForeignKey("ChallengeId")]
        public virtual Challenge Challenge { get; set; }

        [ForeignKey("OptionId")]
        public virtual Option Option { get; set; }
    }
}
