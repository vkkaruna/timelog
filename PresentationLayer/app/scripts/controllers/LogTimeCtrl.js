'use strict';

angular.module('PresentationLayerApp')
    .controller('LogTimeCtrl', ['$scope', 'LogTimeService', 'CommonService', 'growl',
        function ($scope, LogTimeService, CommonService, growl) {
            $scope.awesomeThings = [
                'HTML5 Boilerplate',
                'AngularJS',
                'Karma'
            ];
            var clearFormValues = function () {
                $scope.dtActualStart = '';
                $scope.dtActualEnd = '';
                $scope.actualEffort = '';
            };

            $scope.Projects;
            $scope.GetProjects = function () {
                CommonService.GetProjects()
                    .success(function (data) {
                        $scope.Projects = data;
                        if (data && data.length > 0)
                            $scope.selectedProject = $scope.Projects[0];
                        $scope.GetTasks()
                    })
                    .error(function (err) {
                        growl.addErrorMessage('Unable to get projects.')
                    })
            };

            $scope.Tasks;
            $scope.GetTasks = function () {
                CommonService.Get('api/Project/Tasks?projectID=' + $scope.selectedProject.ProjectID)
                    .success(function (data) {
                        $scope.Tasks = data;
                        if (data && data.length > 0)
                            $scope.selectedTask = $scope.Tasks[0];
                    })
                    .error(function (err) {
                        growl.addErrorMessage('Unable to get Tasks.')
                    })
            };
            $scope.LogTime = function () {
                LogTimeService.LogTime($scope.selectedProject.ProjectID, $scope.selectedTask.TaskID, $scope.dtActualStart, $scope.dtActualEnd, $scope.actualEffort)
                    .success(function (result) {
                        growl.addSuccessMessage('Thank you! You effort has been logged into our time sheet.');
                        clearFormValues();
                    })
                    .error(function (err) {
                        console.error(err);
                        growl.addErrorMessage('Unable to log your time. Please try again after some time.')
                    })
            }
        }]);
