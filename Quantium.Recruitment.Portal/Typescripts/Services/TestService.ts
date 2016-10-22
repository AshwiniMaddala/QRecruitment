﻿
module Recruitment.Services {

    import TestDto = Quantium.Recruitment.ODataEntities.TestDto;
    import ChallengeDto = Quantium.Recruitment.ODataEntities.ChallengeDto;

    interface ITestService {
        getTest(testId: number): ng.IHttpPromise<TestDto>;
        getNextChallenge(): ng.IHttpPromise<ChallengeDto>;
        postChallenge(challenge: ChallengeDto): ng.IHttpPromise<any>;
    }

    export class TestService implements ITestService {
        constructor(private $http: ng.IHttpService) {
        }

        public getTest(testId: number): ng.IHttpPromise<TestDto> {
            return this.$http.get("http://localhost:60606/odata/test(" + testId + ")");
        }

        public getNextChallenge(): ng.IHttpPromise<ChallengeDto> {
            return this.$http.get("/Test/GetNextChallenge");
        }

        public postChallenge(challenge: ChallengeDto): ng.IHttpPromise<any> {
            return this.$http.post("/Test/PostChallenge", challenge);
        }
    }
}
