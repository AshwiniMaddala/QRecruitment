﻿/// <reference path="../viewmodels/candiatesInfoViewModel.ts" />

module Recruitment.Controllers {

    import PreviewCandidatesModel = Quantium.Recruitment.ODataEntities.CandidateDto;

    interface ICandidatesControllerScope extends ng.IScope {
        candidatesArray: any;
        remove: (index: number) => void;
        add: () => void;
        saveCandidate: () => void;
        fileUploadObj: any;
        selectFile: (file: any, errFiles: any) => void;
        uploadedFile: any;
        uploadResult: string;
        fileName: string;
        saveChanges: () => void;
        previewCandidates: () => void;
        previewCandidatesModel: PreviewCandidatesModel[];
        showPrerenderedDialog: (event: any) => void;
        files01: any;
    }

    export class AddCandidatesController {

        constructor(
            private $scope: ICandidatesControllerScope,
            private $log: ng.ILogService,
            private $http: ng.IHttpService,
            private Upload: ng.angularFileUpload.IUploadService,
            private $timeout: ng.ITimeoutService,
            private $connectionService: Recruitment.Services.ConnectionService,
            private $candidateService: Recruitment.Services.CandidateService,
            private $state: ng.ui.IStateService,
            private $mdDialog: ng.material.IDialogService) {
            this.$scope.candidatesArray = {
                 candidates: []
            };
            this.$scope.remove = (index) => this.remove(index);
            this.$scope.add = () => this.add();
            this.$scope.saveCandidate = () => this.saveCandidate();
            this.$scope.selectFile = (file, errFiles) => this.selectFile(file, errFiles);
            this.$scope.saveChanges = () => this.saveChanges();
            this.$scope.previewCandidates = () => this.previewCandidates();
            this.$scope.previewCandidatesModel = [];
            this.$scope.showPrerenderedDialog = (event) => this.showPrerenderedDialog(event);
        }

        private showPrerenderedDialog(ev: any): void {
            this.previewCandidates();
            var dialogOptions: ng.material.IDialogOptions = {
                contentElement: '#myModal',
                clickOutsideToClose: true,
                scope: this.$scope,
                preserveScope: true,
                fullscreen: true
            };

            this.$mdDialog.show(dialogOptions);
        }
       public remove(index: number): void {
           this.$scope.candidatesArray.candidates.splice(index, 1);
        }

       private saveCandidate(): void {
           this.$candidateService.saveCandidate(this.$scope.candidatesArray.candidates).then(
               response => {
                   this.$scope.uploadResult = "Candidates added successfully";
                   this.$state.go("dashboard");
                   console.log(response);
               },
               error => {
                   console.log(error);
               });
       }

        public add(): void {
            this.$scope.candidatesArray.candidates.push({});
        }

        public uploadFile(): void {
            var file: any = this.$scope.files01[0].lfFile;

            if (file) {
                file.upload = this.Upload.upload({
                    url: '/Candidate/Add',
                    data: { file: file },
                    method: 'POST',
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                });

                file.upload.then(response => {
                    this.$timeout(() => {
                        file.result = response.data;
                        this.$scope.uploadResult = "Candidates added successfully";
                    });
                }, error => {
                    if (error.status > 0)
                        this.$scope.uploadResult = error.status + ': ' + error.data;
                }, evt => {
                    file.progress = Math.min(100, parseInt((100.0 * evt.loaded / evt.total) + ''));
                });
            }
        }
         
        public selectFile(file: any, errFiles: any) {
            this.$scope.uploadedFile = file;
            this.$scope.fileName = file.name;
            this.$scope.previewCandidatesModel = [];
        }

        public previewCandidates(): void {
            if (this.$scope.previewCandidatesModel.length < 1) {
                var file = this.$scope.files01[0].lfFile;
                if (file) {
                    var fileReader = new FileReader();
                    fileReader.readAsText(file);

                    fileReader.onload = (event: any) => {
                        var csv = event.target.result;
                        this.processData(csv);
                    }
                }
            }
        }

        public processData(csv: any): void {
            var allLines: string[] = csv.split(/\r|\n/);
            allLines = allLines.filter(line => line.length > 0);
            var supportedOptionCount = 6;
            var headers: string[] = allLines[0].split(",");
            var totalColumnCount = headers.length;

            for (var csvLine = 1; csvLine < allLines.length; csvLine++) {
                var columns: string[] = allLines[csvLine].split(",");
                var questionModel: PreviewCandidatesModel = new PreviewCandidatesModel();
                questionModel.id = Number(columns[0]);
                questionModel.name = columns[1];
                questionModel.email = columns[2];

                this.$scope.previewCandidatesModel.push(questionModel);
                this.$scope.$apply();
            }

            
        }

        public saveChanges(): void {
            this.uploadFile();
        }
    }
}