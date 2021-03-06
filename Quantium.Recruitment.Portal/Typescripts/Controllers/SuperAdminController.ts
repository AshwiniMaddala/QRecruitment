﻿
module Recruitment.Controllers {

    interface ISuperAdminControllerScope extends ng.IScope {
        questions: any[];
        getQuestions: () => void;
    }
    export class SuperAdminController {

        constructor(private $scope: ISuperAdminControllerScope, private $log: ng.ILogService, private $http: ng.IHttpService) {
            this.$scope.getQuestions = () => this.getQuestions();
        }

        private getQuestions(): void {
            this.$http.get('http://localhost:60606/api/temp')
                .then(result => {
                    this.$scope.questions = <any[]>result.data;
                }, reason => {
                    this.$log.info('my recruitment get failed');
                    console.log(reason);
                });
        }
    }
}