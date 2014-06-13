'use strict';

angular.module('PresentationLayerApp')
    .controller('TimeSheetCtrl', ['$scope', 'TimeSheetService', 'CommonService', 'growl',
        function ($scope, TimeSheetService, CommonService, growl) {
            $scope.awesomeThings = [
                'HTML5 Boilerplate',
                'AngularJS',
                'Karma'
            ];

            $scope.$root.showLogout = true;

            $scope.Projects;
            $scope.GetProjects = function () {
                CommonService.GetProjects()
                    .success(function (data) {
                        $scope.Projects = data;
                        if (data && data.length > 0) {
                            $scope.selectedProject = $scope.Projects[0];
                            $scope.GetTimeSheets();
                        }
                    })
                    .error(function (err) {
                        growl.addErrorMessage('Unable to get projects.')
                    })
            };

            $scope.GetTimeSheets = function () {
                TimeSheetService.GetTimeSheets($scope.selectedProject.ProjectID)
                    .success(function (data) {
                        $scope.myData = data;
                    })
                    .error(function (err) {
                        growl.addErrorMessage('Unable to get time sheets.')
                    })
            };

            $scope.gridOptions = {
                data: 'myData',
                columnDefs: [
                    {field: 'TaskName', displayName: 'Task'},
                    {field: 'TaskDesc', displayName: 'Task Desc'},
                    {field: 'EstimatedEffort', displayName: 'Planned Effort', width: '120px'},
                    {field: 'ActualEffort', displayName: 'Actual Effort', width: '100px'},
                    {field: 'ActualStartDate', displayName: 'Start Date', cellFilter: 'date:\'MMMM dd, yyyy\'', width: '100px'},
                    {field: 'ActualEndDate', displayName: 'End Date', cellFilter: 'date:\'MMMM dd, yyyy\'', width: '100px'},
                    {field: 'UserName', displayName: 'Developer'}
                ]
            };
        }]);
