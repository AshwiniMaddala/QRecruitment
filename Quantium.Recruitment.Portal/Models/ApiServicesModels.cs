﻿


using System;
using System.Collections.Generic;
namespace Quantium.Recruitment.ApiServiceModels {

     public class AdminDto { 
        public long Id;
        public string FirstName;
        public string LastName;
        public string Email;
        public long Mobile;
        public bool IsActive;
        public long DepartmentId;
        public DepartmentDto Department;

    }

     public class CandidateDto { 
        public long Id;
        public string FirstName;
        public string LastName;
        public string Email;
        public long Mobile;
        public bool IsActive;
        public string City;
        public string State;
        public string Country;
        public string Branch;
        public string College;
        public string PassingYear;
        public Double ExperienceInYears;
        public string CurrentCompany;
        public bool IsInformationFilled;

    }

     public class CandidateSelectedOptionDto { 
        public long Id;
        public long ChallengeId;
        public long OptionId;

    }

     public class ChallengeDto { 
        public long Id;
        public long TestId;
        public long QuestionId;
        public DateTime StartTime;
        public DateTime AnsweredTime;
        public Int32 RemainingChallenges;
        public Int32 currentChallenge;
        public QuestionDto Question;
        public Boolean[] ChallengesAnswered;
        public List<CandidateSelectedOptionDto> CandidateSelectedOptions;

    }

     public class DepartmentDto { 
        public long Id;
        public string Name;

    }

     public class Candidate_JobDto { 
        public long Id;
        public CandidateDto Candidate;
        public JobDto Job;
        public bool IsFinished;

    }

     public class JobDto { 
        public long Id;
        public string Title;
        public string Profile;
        public DepartmentDto Department;
        public List<Job_Difficulty_LabelDto> JobDifficultyLabels;

    }

     public class Question_Difficulty_LabelDto { 
        public long DifficultyId;
        public long LabelId;
        public Int32 QuestionCount;

    }

     public class LabelDto { 
        public long Id;
        public string Name;

    }

     public class Test_LabelDto { 
        public long Id;
        public TestDto Test;
        public LabelDto Label;

    }

     public class OptionDto { 
        public long Id;
        public long QuestionId;
        public string Text;
        public string ImageUrl;
        public bool IsAnswer;

    }

     public class DifficultyDto { 
        public long Id;
        public string Name;
        public List<Job_Difficulty_LabelDto> JobDifficultyLabels;

    }

     public class Job_Difficulty_LabelDto { 
        public long Id;
        public DifficultyDto Difficulty;
        public LabelDto Label;
        public Int32 DisplayQuestionCount;
        public Int32 PassingQuestionCount;

    }

     public class QuestionDto { 
        public long Id;
        public string Text;
        public string ImageUrl;
        public Int32 TimeInSeconds;
        public bool RandomizeOptions;
        public QuestionGroupDto QuestionGroup;
        public List<OptionDto> Options;
        public DifficultyDto Difficulty;
        public LabelDto Label;

    }

     public class QuestionGroupDto { 
        public long Id;
        public string Description;

    }

     public class TestDto { 
        public long Id;
        public string Name;
        public List<ChallengeDto> Challenges;
        public List<Test_LabelDto> TestLabels;
        public CandidateDto Candidate;
        public JobDto Job;
        public bool IsFinished;
        public DateTime FinishedDate;
        public Int32 TotalRightAnswers;
        public Int32 TotalChallengesDisplayed;
        public Int32 TotalChallengesAnswered;
        public bool IsTestPassed;

    }

}
