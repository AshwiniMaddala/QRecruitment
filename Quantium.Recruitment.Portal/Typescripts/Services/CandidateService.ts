﻿
module Recruitment.Services {

    import CandidateDto = Quantium.Recruitment.ODataEntities.CandidateDto; 

    interface ICandidateService {
        getAllCandidates(): ng.IHttpPromise<CandidateDto[]>;
        getCandidatesWithoutActiveTests(): ng.IHttpPromise<CandidateDto[]>;
    }

    export class CandidateService implements ICandidateService {
        

        constructor(private $http: ng.IHttpService, private $q: ng.IQService) {
        }

        public getAllCandidates(): ng.IHttpPromise<CandidateDto[]> {
            return this.$http.get("/Candidate/GetAllCandidates");
        }

        public getCandidatesWithoutActiveTests(): ng.IHttpPromise<CandidateDto[]> {
            return this.$http.get("/Candidate/GetCandidatesWithoutActiveTests");
        }

        public isInformationFilled(): ng.IHttpPromise<boolean> {
            return this.$http.get("/Candidate/IsInformationFilled");
        }

        public fillCandidateInformation(candidateDto: CandidateDto): ng.IHttpPromise<boolean> {
            return this.$http.post("/Candidate/FillCandidateInformation", candidateDto);
        }

        public saveCandidate(candidateDto: CandidateDto): ng.IHttpPromise<boolean> {
            return this.$http.post("/Candidate/SaveCandidate", candidateDto);
        }

        public getCandidateName(): ng.IHttpPromise<string> {
            return this.$http.get("/Candidate/GetCandidateName");
        }
    }
}
